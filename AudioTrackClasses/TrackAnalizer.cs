using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echo.AudioTrackClasses
{
    public static class TrackAnalizer
    {
        public static TimeSpan PlaylistTotalDuration(TrackMetaData.AudioTrack[] audioTracks, int num)
        {
            TimeSpan sum = TimeSpan.Zero;
            for (int i = 0; i < num && i < audioTracks.Length; i++)
            {
                sum += audioTracks[i].Duration;
            }
            return sum;
        }
        public static double PlaylistAverageDuration(TrackMetaData.AudioTrack[] audioTracks, int num)
        {
            if (audioTracks.Length == 0) return 0;
            TimeSpan totalDuration = PlaylistTotalDuration(audioTracks, num);
            return totalDuration.TotalSeconds / num;
        }

        public static string[] PlaylistArtists(TrackMetaData.AudioTrack[] audioTracks, int num)
        {
            string[] strings = new string[num];
            strings[0] = audioTracks[0].Artist;
            int stringCount = 1;

            for (int i = 1; i < num && i < audioTracks.Length; i++)
            {
                if(strings.Contains(audioTracks[i].Artist))
                    continue;
                
                strings[stringCount] = audioTracks[i].Artist;
                stringCount++;
            }
            string[] output = new string[stringCount];
            Array.Copy(strings, output, stringCount);

            return output;
        }


        public static string[] PlaylistAlbums(TrackMetaData.AudioTrack[] audioTracks, int num)
        {
            string[] strings = new string[num];
            strings[0] = audioTracks[0].Album;
            int stringCount = 1;

            for (int i = 1; i < num && i < audioTracks.Length; i++)
            {
                if (strings.Contains(audioTracks[i].Album))
                    continue;

                strings[stringCount] = audioTracks[i].Album;
                stringCount++;
            }
            string[] output = new string[stringCount];
            Array.Copy(strings, output, stringCount);

            return output;
        }
    }
}
