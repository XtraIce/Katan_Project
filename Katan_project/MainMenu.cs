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

namespace Katan_project
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            SoundPlayer Player = new SoundPlayer();
            SoundPlayer audio = new SoundPlayer(Katan_project.Properties.Resources.Fanfare_for_Space); // here Katan_project is the namespace and Fanfare_for_Space is the audio file name
            audio.PlayLooping();
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            GameWindow m = new GameWindow();
            m.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void settings_button_Click(object sender, EventArgs e)
        {
            Settings n = new Settings();
            n.Show();
        }
    }
}
