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
        public static bool randomizeCheck=true;        
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
            SoundPlayer audio = new SoundPlayer(Katan_project.Properties.Resources.KatanMusic); // here Katan_project is the namespace and KatanMusic is the audio file name
            audio.PlayLooping();

            Map GameMap = new Map(randomizeCheck);
            AssignTileImages(GameMap);
            AssignDiceImages(GameMap);

            //This don't work
            /*
            TransparentControl TileA = new TransparentControl();
            TileA.Image = System.Drawing.Image.FromFile(@"C:\Users\Riker\OneDrive\CatanMaterials\BrickTileSmall.png");
            TileA.Location = new Point(500, 500);
            TileA.Show();
            TileA.BringToFront();
            */
        }

        private void AssignTileImages(Map map)
        {
            PictureBox[] TileImageArray = new PictureBox[19] { tile0, tile1, tile2, tile3, tile4, tile5, tile6, tile7, tile8, tile9, tile10, tile11, tile12, tile13, tile14, tile15, tile16, tile17, tile18 };
            for(int i =0;i<=18;i++)
            {
                if (map.MapTile[i] is TForest)
                    TileImageArray[i].Image = Properties.Resources.Catan_ForestTile;
                else if (map.MapTile[i] is THill)
                    TileImageArray[i].Image = Properties.Resources.Catan_HillTile;
                else if (map.MapTile[i] is TPasture)
                    TileImageArray[i].Image = Properties.Resources.Catan_PastureTile;
                else if (map.MapTile[i] is TMountain)
                    TileImageArray[i].Image = Properties.Resources.Catan_MountainTile;
                else if (map.MapTile[i] is TField)
                    TileImageArray[i].Image = Properties.Resources.Catan_FieldTile;
                else if (map.MapTile[i] is TDesert)
                    TileImageArray[i].Image = Properties.Resources.Catan_DesertTile;
                else
                {
                    TileImageArray[i].Image = Properties.Resources.Catan_DefaultTile;
                }
            }
        }
        private void AssignDiceImages(Map map)
        {
            Label[] DiceImageArray = new Label[19] { Dice0, Dice1, Dice2, Dice3, Dice4, Dice5, Dice6, Dice7, Dice8, Dice9, Dice10, Dice11, Dice12, Dice13, Dice14, Dice15, Dice16, Dice17, Dice18 };
            for (int i = 0; i <= 18; i++)
            {
                if(map.MapTile[i].getDiceValue()==0)
                {
                    DiceImageArray[i].Text = "";
                }
                else
                DiceImageArray[i].Text = map.MapTile[i].getDiceValue().ToString();
            }
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

        private void Continue_button_Click(object sender, EventArgs e)
        {

        }

        private void tile0_Click(object sender, EventArgs e)
        {

        }
    }
}
