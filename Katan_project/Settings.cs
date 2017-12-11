using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// RIKER QUINTANA
/// 816823248
/// </summary>
namespace Katan_project
{
    public partial class Settings : Form
    {
        static bool notSavedCheat = false;
        static bool oldMusicbool = false;
        static bool notSavedMusic = false;
        static bool notSavedRandom = false;
        public Settings()
        {
            InitializeComponent();
            if (GameWindow.enableCheat)
                CheatModeCheck.CheckState = CheckState.Checked;
            if (notSavedMusic)
                MusicCheck.CheckState = CheckState.Checked;
            if (GameWindow.randomizeCheck)
                RandomCheck.CheckState = CheckState.Checked;
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RandomCheck_CheckedChanged(object sender, EventArgs e)
        {
            notSavedRandom = !notSavedRandom;
        }

        private void CheatModeCheck_CheckedChanged(object sender, EventArgs e)
        {
            notSavedCheat = !notSavedCheat;
        }

        private void MusicCheck_CheckedChanged(object sender, EventArgs e)
        {
            notSavedMusic = !notSavedMusic;
        }
        private void Save_button_Click(object sender, EventArgs e)
        {
            GameWindow.randomizeCheck = !GameWindow.randomizeCheck;
            GameWindow.enableCheat = notSavedCheat;

            GameWindow.enableMusic = notSavedMusic;
            MainMenu.MenuMusic = notSavedMusic;
            if(!GameWindow.enableMusic)
            {
                oldMusicbool = GameWindow.enableMusic;
                GameWindow.audio.Stop();
                MainMenu.audio.Stop();
            }
            if(!oldMusicbool && GameWindow.enableCheat )
            {
                GameWindow.audio.PlayLooping();
            }

            this.Close();
        }
    }
}
