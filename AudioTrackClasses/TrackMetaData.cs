using NAudio.Dmo;
using NAudio.Wave;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using TagLib;
using TagLib.WavPack;

namespace Echo
{
    public static class TrackMetaData
    {
        public struct AudioTrack
        {
            //MetaDatas
            public string Title;
            public string Artist;
            public string Album;
            public Image AlbumArt;

            //Informazioni di servizio
            public string FilePath;
            public float VolumeMultiplier;
            public TimeSpan Duration;
        }

        /// <summary>
        /// Crea un <see cref="AudioTrack"/> leggendo metadati, copertina e durata da un file audio.
        /// Se alcuni campi non sono presenti o si verifica un errore, applica valori di fallback.
        /// </summary>
        /// <remarks>
        /// Fallback usati:
        /// <list type="bullet">
        /// <item><description>Titolo: nome file senza estensione.</description></item>
        /// <item><description>Artista: "Autore sconosciuto" (metadato mancante) oppure "Sconosciuto" (in caso di eccezione).</description></item>
        /// <item><description>Album: "Album sconosciuto" (metadato mancante) oppure "Sconosciuto" (in caso di eccezione).</description></item>
        /// <item><description>Copertina: <see langword="null"/> se assente o in caso di errore.</description></item>
        /// <item><description>Durata: <see cref="TimeSpan.Zero"/> in caso di eccezione.</description></item>
        /// <item><description>Volume iniziale: valore di <paramref name="volume"/>.</description></item>
        /// </list>
        /// </remarks>
        /// <param name="filePath">Percorso del file audio da analizzare.</param>
        /// <param name="volume">Volume iniziale assegnato alla traccia caricata (default: <see cref="AppDefaults.DefaultVolumeMultiplier"/>).</param>
        /// <returns>Un <see cref="AudioTrack"/> popolato con le informazioni lette dal file.</returns>
        /// <exception cref="FileNotFoundException">Generata quando il file non esiste.</exception>
        public static AudioTrack FromFile(string filePath, float volume = AppDefaults.DefaultVolumeMultiplier)
        {
            if (!System.IO.File.Exists(filePath))
                throw new System.IO.FileNotFoundException();

            float safeDefaultVolume = Math.Max(AppDefaults.MinDeviceVolume, Math.Min(AppDefaults.MaxDeviceVolume, volume));

            AudioTrack newTrack;
            newTrack.FilePath = filePath;

            try
            {
                // Nota: `TagLib.File` implementa `IDisposable`.
                // In .NET Framework conviene sempre racchiuderlo in `using` per rilasciare handle/file lock.
                using (TagLib.File fileTag = TagLib.File.Create(filePath))
                {
                    // ----------------------------
                    // Lettura metadati testuali
                    // ----------------------------
                    newTrack.Title = !string.IsNullOrEmpty(fileTag.Tag.Title)
                        ? fileTag.Tag.Title.Trim()
                        : Path.GetFileNameWithoutExtension(filePath);

                    newTrack.Artist = !string.IsNullOrEmpty(fileTag.Tag.FirstPerformer)
                        ? fileTag.Tag.FirstPerformer.Trim()
                        : AppDefaults.AudioTrackArtistNotAvailable;

                    newTrack.Album = !string.IsNullOrEmpty(fileTag.Tag.Album)
                        ? fileTag.Tag.Album.Trim()
                        : AppDefaults.AudioTrackAlbumNotAvailable;

                    

                    // ----------------------------
                    // Root cause reale del bug GDI+
                    // ----------------------------
                    // Errore originale:
                    //   System.Runtime.InteropServices.ExternalException
                    //   "Errore generico in GDI+."
                    // durante `albumArt.Save(ms, format)`.
                    //
                    // Causa profonda:
                    // - Se si usa `Image.FromStream(ms)` e poi si chiude `ms`,
                    //   l'oggetto `Image` può rimanere internamente legato allo stream sorgente.
                    // - In un momento successivo (qui durante salvataggio tag), GDI+ deve riaccedere ai dati
                    //   originali dell'immagine per ricodificarla e fallisce con errore generico.
                    //
                    // Soluzione robusta:
                    // - creare un'immagine "indipendente" dallo stream facendo una copia fisica (`new Bitmap(img)`).
                    // - in questo modo, quando il `MemoryStream` viene chiuso, `AlbumArt` resta perfettamente valida.
                    if (fileTag.Tag.Pictures != null && fileTag.Tag.Pictures.Length >= 1)
                    {
                        byte[] bin = fileTag.Tag.Pictures[0].Data.Data;

                        using (var ms = new MemoryStream(bin))
                        using (var img = Image.FromStream(ms, true, true))
                        {
                            // Copia disaccoppiata dallo stream: evita il classico ExternalException GDI+ in Save().
                            newTrack.AlbumArt = new Bitmap(img);
                        }
                    }
                    else
                    {
                        newTrack.AlbumArt = null;
                    }

                    newTrack.VolumeMultiplier = safeDefaultVolume;
                }

                // Nota: anche `AudioFileReader` è `IDisposable`.
                // Evita leak di handle file e comportamenti intermittenti.
                using (AudioFileReader audioFileReader = new AudioFileReader(filePath))
                {
                    newTrack.Duration = audioFileReader.TotalTime;
                }
            }
            catch
            {
                newTrack.Title = Path.GetFileNameWithoutExtension(filePath);
                newTrack.Artist = AppDefaults.AudioTrackError;
                newTrack.Album = AppDefaults.AudioTrackError;
                newTrack.Duration = TimeSpan.Zero;
                newTrack.AlbumArt = null;
                newTrack.VolumeMultiplier = safeDefaultVolume;
            }

            return newTrack;
        }

        public static bool OverwriteMP3MetaTags(string mp3Path, AudioTrack audioTrack)
        {
            if (!System.IO.File.Exists(mp3Path) || Path.GetExtension(mp3Path) != ".mp3")
                return false;

            try
            {
                // Anche qui usare `using` è consigliato:
                // garantisce flush e rilascio corretto risorse native/file.
                using (TagLib.File mp3 = TagLib.File.Create(mp3Path))
                {
                    mp3.Tag.Title = audioTrack.Title;
                    mp3.Tag.Performers = new string[] { audioTrack.Artist };
                    mp3.Tag.Album = audioTrack.Album;

                    // Questo punto prima falliva quando `audioTrack.AlbumArt` proveniva da uno stream già chiuso.
                    // Dopo la correzione in `FromFile`, l'immagine è autonoma e serializzabile.
                    mp3.Tag.Pictures = ImageHelper.BuildTagPicturesFromImage(audioTrack.AlbumArt);

                    mp3.Save();
                }

                return true;
            }
            catch
            {
                // IMPORTANTISSIMO:
                // NON fare `throw new Exception(ex.Message);`
                // perché:
                // 1) perdi tipo eccezione originale (`ExternalException`, ecc.),
                // 2) perdi stack trace originale,
                // 3) rendi il debugging molto più difficile.
                //
                // `throw;` preserva integralmente il contesto reale del guasto.
                throw;
            }
        }

        public static int FindTrackIndexByTitleAndArtist(string title,  string artist, AudioTrack[] audioTrackArray, int audioTrackArrayCount)
        {
            for (int i = 0; i < audioTrackArrayCount; i++)
            {
                if (audioTrackArray[i].Title == title && audioTrackArray[i].Artist == artist)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Restituisce una stringa formattata "mm:ss" per il numero di secondi specificato.
        /// </summary>
        /// <param name="seconds">Numero di secondi da convertire.</param>
        /// <returns>Stringa formattata come "mm:ss".</returns>
        public static string FormatTrackTime(int seconds)
        {
            return TimeSpan
                .FromSeconds(seconds)
                .ToString("mm\\:ss");
        }
        public static void DeleteAudioTrackFromArray(int toDeleteIndex,AudioTrack[] array, ref int arrayCount, bool keepOrder = true)
        {
            if(array == null)
            {
                throw new NullReferenceException($"{nameof(array)} is null or empty");
            }
            if(keepOrder)
            {
                arrayCount--;
                array[toDeleteIndex] = array[arrayCount];
            }
            else
            {
                while(toDeleteIndex < arrayCount - 1)
                {
                    array[toDeleteIndex] = array[toDeleteIndex + 1];
                    toDeleteIndex++;
                }
            }
        }

        public static int SavePlaylistInEch(string softwareDirectory,string playlistName, AudioTrack[] playlist, int playlistCount, out int[] filePathError)
        {
            int errorsCount = 0;
            int[] errors = new int[playlistCount];
            for (int i = 0; i < playlistCount; i++)
            {
                if (!System.IO.File.Exists(playlist[i].FilePath))
                {
                    errors[errorsCount] = i;
                    errorsCount++;
                }
            }

            filePathError = new int[errorsCount];
            for(int i  = 0; i < errorsCount; i++)
            {
                filePathError[i] = errors[i];
            }
            if (filePathError.Length > 0)
                return -1;

            if (!System.IO.Directory.Exists(softwareDirectory))
                Directory.CreateDirectory(softwareDirectory);
            if(!StringHelper.CanBeADirectoryOrFileName(ref playlistName,AppDefaults.SubstituteToSpaceInDirectoryOrFileName))
                return -2;
            string playlistDirectory = Path.Combine(softwareDirectory, playlistName);
            bool tempDirectory = false;
            string actPlaylistDirectory = playlistDirectory;
            if (System.IO.Directory.Exists(playlistDirectory))
            {
                actPlaylistDirectory = playlistDirectory + "_tmp";
                tempDirectory = true;
            }
            
            Directory.CreateDirectory(actPlaylistDirectory);
            string echPath = Path.Combine(actPlaylistDirectory, Path.ChangeExtension(playlistName,".ech"));
            StreamWriter echFile = new StreamWriter(echPath);
            string audioTracksDirectory = Path.Combine(actPlaylistDirectory, "audioTracks");
            Directory.CreateDirectory(audioTracksDirectory);
            string realAudioTrackDirectory = tempDirectory ? Path.Combine(playlistDirectory, "audioTracks"): default;
            try
            {
                //Scrittura nome playlist
                echFile.WriteLine(playlistName);
                echFile.WriteLine(playlistCount);
                for(int i =  0; i < playlistCount; i++)
                {
                    string fileName = Path.GetFileName(playlist[i].FilePath);
                    string destination = Path.Combine(audioTracksDirectory, fileName);
                    //Spostamento File in caso di percorsi diversi
                    System.IO.File.Copy(playlist[i].FilePath, destination, true);
                    if (tempDirectory)
                        echFile.WriteLine(Path.Combine(realAudioTrackDirectory, fileName));
                    else
                        echFile.WriteLine(destination);

                    echFile.WriteLine(playlist[i].VolumeMultiplier.ToString());
                    OverwriteMP3MetaTags(destination, playlist[i]);
                }
                return 0;
            }
            catch
            {
                return -3;
            }
            finally
            {
                echFile.Close();
                if (tempDirectory)
                {
                    Directory.Delete(playlistDirectory, true);
                    Directory.Move(actPlaylistDirectory, playlistDirectory);
                }
            }
        }

        public static bool IsPlaylist(string echPath)
        {
            if(Path.GetExtension(echPath) != ".ech")
                return false;
            if(!System.IO.File.Exists(echPath))
                return false;
            if(!System.IO.Directory.Exists(Path.Combine(Path.GetDirectoryName(echPath),"audioTracks")))
                return false;
            return true;              
        }

        public static int LoadPlaylistFromEch(string echPath, ref string playlistName,ref AudioTrack[] playlist)
        {
            playlist = new AudioTrack[0];
            if(!IsPlaylist(echPath))
                return -1;
            StreamReader reader = new StreamReader(echPath);
            try
            {
                playlistName = reader.ReadLine();
                int count = (int)MathHelper.Clamp(int.Parse(reader.ReadLine()),0,AppDefaults.MaxLoadedTracks);
                AudioTrack[] tmp_playlist = new AudioTrack[count];
                for(int i = 0; i < count && !reader.EndOfStream; i++)
                {
                    string trackPath = reader.ReadLine();
                    float volume = float.Parse(reader.ReadLine());
                    tmp_playlist[i] = FromFile(trackPath, volume);
                }
                playlist = tmp_playlist;
                return 0;
            }
            catch
            {
                return -2;
            }
            finally
            {
                reader.Close();
            }
        }
    }

    
}
