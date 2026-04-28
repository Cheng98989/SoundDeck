using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echo.Sorting
{
    public static class Sorter
    {
            public enum SortType
            {
                Title,
                Artist,
                Album,
                Duration,
                FilePath,
                VolumeMultiplier,
        }

        public static void SortAudioTracks(TrackMetaData.AudioTrack[] audioTracks, int num, SortType sortType, bool ascending = true)
        {
            if (audioTracks == null) throw new ArgumentNullException(nameof(audioTracks));
            if (num < 0 || num > audioTracks.Length) throw new ArgumentOutOfRangeException(nameof(num));

            //Comparison e' un delegato, un tipo di dato che contiene funzioni.
            //Comparisonn e' compatibile con funzioni che vogliono due parametri di tipo 'qualcosa' e restituisce in intero

            //(a,b) => { ... } e' una lambda expression, crea una funzione anonima che viene definita al volo (dentro le graffe).
            //In questo caso, prende due parametri 'a' e 'b' di tipo TrackMetaData.AudioTrack e restituisce un intero che rappresent
            // il risultato del confronto tra i due oggetti in base al sortType specificato.

            //La lambda viene assegnata alla variabile 'comparison', che poi viene utilizzata per ordinare l'array di audioTracks con Array.Sort.
            Comparison<TrackMetaData.AudioTrack> comparison = (a, b) =>
            {
                int result = 0;
                switch (sortType)
                {
                    case SortType.Title:
                        result = string.Compare(a.Title, b.Title, StringComparison.InvariantCulture);
                        break;
                    case SortType.Artist:
                        result = string.Compare(a.Artist, b.Artist, StringComparison.InvariantCulture);
                        break;
                    case SortType.Album:
                        result = string.Compare(a.Album, b.Album, StringComparison.InvariantCulture);
                        break;
                    case SortType.Duration:
                        result = a.Duration.CompareTo(b.Duration);
                        break;
                    case SortType.FilePath:
                        result = string.Compare(a.FilePath, b.FilePath, StringComparison.InvariantCulture);
                        break;
                    case SortType.VolumeMultiplier:
                        result = a.VolumeMultiplier.CompareTo(b.VolumeMultiplier);
                        break;
                }
                return ascending ? result : -result;
            };
            //Uso Array.Sort per ordinare l'array di audioTracks in base alla funzione di confronto definita nella lambda.
            Array.Sort(audioTracks, 0, num, Comparer<TrackMetaData.AudioTrack>.Create(comparison));
        }

        
    }
}
