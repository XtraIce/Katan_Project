using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// RIKER QUINTANA
/// 816823248
/// </summary>
namespace Katan_project
{
    public partial class MainMenu : Form
    {
        public static SoundPlayer audio = new SoundPlayer(Katan_project.Properties.Resources.Fanfare_for_Space); // here Katan_project is the namespace and Fanfare_for_Space is the audio file name
        static public bool MenuMusic = true;
        public MainMenu()
        {
            InitializeComponent();

            if (MenuMusic)
                audio.PlayLooping();
            else
                audio.Stop();
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            GameWindow m = new GameWindow();
            m.Show();
        }

        private void settings_button_Click(object sender, EventArgs e)
        {
            Settings n = new Settings();
            n.Show();
        }
        public void MusicCheck()
        {
            if (MenuMusic)
                audio.PlayLooping();
            else
                audio.Stop();
        }

        private void Help_button_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.catan.com/service/game-rules");
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
