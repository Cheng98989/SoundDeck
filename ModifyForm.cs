using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundDeck
{
    public partial class ModifyForm : PoisonForm
    {
        public ModifyForm(TrackMetaData.AudioTrack audio)
        {
            InitializeComponent();

            audioTrack = audio;


        }

        public TrackMetaData.AudioTrack audioTrack = default;
    }
}
