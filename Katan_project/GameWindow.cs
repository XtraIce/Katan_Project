using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Katan_project
{
    public partial class GameWindow : Form
    {
        public GameWindow()
        {
            InitializeComponent();
            pictureBox1.Controls.Add(pictureBox2);
            pictureBox2.Location = new Point(400, 25);
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Controls.Add(tile0);
            tile0.Location = new Point(199, 64);
            tile0.BackColor = Color.Transparent;

            pictureBox2.Controls.Add(tile1);
            tile1.BackColor = Color.Transparent;
            tile1.Location = new Point(145,157);

            pictureBox2.Controls.Add(tile11);
            tile11.BackColor = Color.Transparent;
            tile11.Location = new Point(310, 64);

            pictureBox2.Controls.Add(tile10);
            tile10.BackColor = Color.Transparent;
            tile10.Location = new Point(421, 64);
            SoundPlayer Player = new SoundPlayer();
            Player.SoundLocation = @"C:\Users\Riker\OneDrive\CatanMaterials\KatanMusic.wav";
            Player.PlayLooping();

            TransparentControl TileA = new TransparentControl();
            TileA.Image = System.Drawing.Image.FromFile(@"C:\Users\Riker\OneDrive\CatanMaterials\BrickTileSmall.png");
            TileA.Location = new Point(500, 500);
            TileA.Show();
            TileA.BringToFront();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //empty implementation
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Next_player_label1_Click(object sender, EventArgs e)
        {

        }
    }
}
