using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Echo.Forms
{
    public partial class AnaliysisForm : PoisonForm
    {

        public AnaliysisForm(TrackMetaData.AudioTrack[] playlist, int num)
        {
            InitializeComponent();
            displayAnalysis(playlist, num);
        }

        private void displayAnalysis(TrackMetaData.AudioTrack[] audioTracks, int num)
        {
            TimeSpan totalDuration = AudioTrackClasses.TrackAnalizer.PlaylistTotalDuration(audioTracks, num);
            double averageDuration = AudioTrackClasses.TrackAnalizer.PlaylistAverageDuration(audioTracks, num);
            string[] artists = AudioTrackClasses.TrackAnalizer.PlaylistArtists(audioTracks, num);
            string[] albums = AudioTrackClasses.TrackAnalizer.PlaylistAlbums(audioTracks, num);
            plbPlaylistCount.Text = $"{num}";
            plbTotalDuration.Text = $"{TrackMetaData.FormatTrackTime((int)totalDuration.TotalSeconds)}";
            plbAverageDuration.Text = $"{TrackMetaData.FormatTrackTime((int)averageDuration)}";
            plvArtists.Items.Clear();
            foreach (string artist in artists)
            {
                plvArtists.Items.Add(artist);
            }
            plvAlbums.Items.Clear();
            foreach (string album in albums)
            {
                plvAlbums.Items.Add(album);
            }

        }
    }
}
