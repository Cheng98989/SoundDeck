using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Echo.Sorting;
using ReaLTaiizor.Forms;

namespace Echo.Forms
{
    public partial class SortForm : PoisonForm
    {
        private TrackMetaData.AudioTrack[] audioTrackArray;
        private int num;

        public SortForm(ref TrackMetaData.AudioTrack[] playlist, int num)
        {
            InitializeComponent();
            pcbAscedent.SelectedIndex = 0;
            pcbSortType.SelectedIndex = 0;
            audioTrackArray = playlist;
            this.num = num;
        }

        private void pbtOrdina_Click(object sender, EventArgs e)
        {
            bool ascedent = true;

            switch (pcbAscedent.SelectedIndex)
            {
                case 0:
                    ascedent = true;
                    break;
                case 1:
                    ascedent = false;
                    break;

            }
            Sorter.SortType sortType;
            switch (pcbSortType.SelectedIndex)
            {
                case 0:
                    sortType = Sorter.SortType.Title;
                    Sorter.SortAudioTracks(audioTrackArray, num, sortType, ascedent);
                    break;
                case 1:
                    sortType = Sorter.SortType.Artist;
                    Sorter.SortAudioTracks(audioTrackArray, num, sortType, ascedent);
                    break;
                case 2:
                    sortType = Sorter.SortType.Album;
                    Sorter.SortAudioTracks(audioTrackArray, num, sortType, ascedent);
                    break;
                case 3:
                    sortType = Sorter.SortType.Duration;
                    Sorter.SortAudioTracks(audioTrackArray, num, sortType, ascedent);
                    break;
                case 4:
                    sortType = Sorter.SortType.FilePath;
                    Sorter.SortAudioTracks(audioTrackArray, num, sortType, ascedent);
                    break;
                case 5:
                    sortType = Sorter.SortType.VolumeMultiplier;
                    Sorter.SortAudioTracks(audioTrackArray, num, sortType, ascedent);
                    break;
            }
            this.Close();

        }
    }
}
