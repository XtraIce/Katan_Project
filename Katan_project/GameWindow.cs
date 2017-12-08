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
        public static bool buildSettlement;
        public static bool buildCity;
        private Map GameMap = new Map(randomizeCheck);
        private Player RedPlayer = new Player("Red",1);
        private Player BluePlayer = new Player("Blue",2);
        private Player OrangePlayer = new Player("Orange",3);
        private Player WhitePlayer = new Player("White",4);
        private Player[] PlayerOrder = new Player[5];

        public static Image RedCityImage = Properties.Resources.RedCity;
        public static Image RedSettlementImage = Properties.Resources.RedSettlement;
        public static Image BlueCityImage = Properties.Resources.BlueCity;
        public static Image BlueSettlementImage = Properties.Resources.BlueSettlement;
        public static Image OrangeCityImage = Properties.Resources.OrangeCIty;
        public static Image OrangeSettlementImage = Properties.Resources.OrangeSettlement;
        public static Image WhiteCityImage = Properties.Resources.WhiteCity;
        public static Image WhiteSettlementImage = Properties.Resources.WhiteSettlement;



        public GameWindow()
        {
            InitializeComponent();
            UIPlacement();

            SoundPlayer audio = new SoundPlayer(Katan_project.Properties.Resources.KatanMusic); // here Katan_project is the namespace and KatanMusic is the audio file name
            audio.PlayLooping();
            AssignTileImages(GameMap);
            AssignDiceImages(GameMap);
            SetupTurns();
            UpdateUI();

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

        private void Continue_button_Click(object sender, EventArgs e)
        {
            if (!buildSettlement && !buildCity)
            {
                NextTurn();
                UpdateUI();
            }
        }

        private void settlement_button_Click(object sender, EventArgs e)
        {
            ShowPlots();
            buildSettlement = !buildSettlement;
        }
        private void City_button_Click(object sender, EventArgs e)
        {
            buildCity = !buildCity;
            ShowUpgradableSettlements(PlayerOrder[0]);
        }

        /// <summary>
        /// show the available plots that a place can place settlements on
        /// </summary>
        private void ShowPlots()
        {
            PictureBox[] BuildPlots = new PictureBox[54] {Vertice00,Vertice01,Vertice02,Vertice03,Vertice04,Vertice05,Vertice12,Vertice13,Vertice14,Vertice15,Vertice22,Vertice23,Vertice24,Vertice25,
                                                            Vertice31,Vertice32,Vertice33,Vertice34,Vertice41,Vertice42,Vertice43,Vertice44,Vertice50,Vertice51,Vertice52,Vertice53,Vertice60,Vertice61,
                                                            Vertice62,Vertice63,Vertice70,Vertice71,Vertice72,Vertice75,Vertice80,Vertice81,Vertice82,Vertice85,Vertice90,Vertice91,Vertice94,Vertice95,
                                                            Vertice100,Vertice101,Vertice104,Vertice105,Vertice110,Vertice113,Vertice122,Vertice131,Vertice140,Vertice155,Vertice164,Vertice173};
            int v = 0;
            for(int i=0;i<17;i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j <= 5; j++)
                    {
                        if (GameMap.MapTile[i].Vertice[j] == 0)
                        {
                            ToggleVisiblity(BuildPlots[v]);
                            v++;
                        }
                        else v++;
                    }
                }
                if (i == 1 || i == 2)
                {
                    for (int j = 2; j <= 5; j++)
                    {
                        if (GameMap.MapTile[i].Vertice[j] == 0)
                        {
                            ToggleVisiblity(BuildPlots[v]);
                            v++;
                        }
                        else v++;
                    }
                }
                if (i == 3 || i == 4)
                {
                    for (int j = 1; j <= 4; j++)
                    {
                        if (GameMap.MapTile[i].Vertice[j] == 0)
                        {
                            ToggleVisiblity(BuildPlots[v]);
                            v++;
                        }
                        else v++;
                    }
                }
                if (i == 5 || i == 6)
                {
                    for (int j = 0; j <= 3; j++)
                    {
                        if (GameMap.MapTile[i].Vertice[j] == 0)
                        {
                            ToggleVisiblity(BuildPlots[v]);
                            v++;
                        }
                        else v++;
                    }
                }
                if (i == 7 || i == 8)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        if (GameMap.MapTile[i].Vertice[j] == 0)
                        {
                            ToggleVisiblity(BuildPlots[v]);
                            v++;
                        }
                        else v++;
                    }
                    if (GameMap.MapTile[i].Vertice[5] == 0)
                    {
                        ToggleVisiblity(BuildPlots[v]);
                        v++;
                    }
                    else v++;
                }
                if (i == 9 || i == 10)
                {
                    for (int j = 0; j <= 1; j++)
                    {
                        if (GameMap.MapTile[i].Vertice[j] == 0)
                        {
                            ToggleVisiblity(BuildPlots[v]);
                            v++;
                        }
                        else v++;
                    }
                    for (int j = 4; j <= 5; j++)
                    {
                        if (GameMap.MapTile[i].Vertice[j] == 0)
                        {
                            ToggleVisiblity(BuildPlots[v]);
                            v++;
                        }
                        else v++;
                    }
                }
                if(i==11)
                {
                    if (GameMap.MapTile[i].Vertice[0] == 0|| GameMap.MapTile[i].Vertice[3]==0)
                    {
                        ToggleVisiblity(BuildPlots[v]);
                        v++;
                    }
                    else v++;
                }
                if (i == 12)
                    if (GameMap.MapTile[i].Vertice[2] == 0)
                    {
                        ToggleVisiblity(BuildPlots[v]);
                        v++;
                    }
                    else v++;
                if (i == 13)
                    if (GameMap.MapTile[i].Vertice[1] == 0)
                    {
                        ToggleVisiblity(BuildPlots[v]);
                        v++;
                    }
                    else v++;
                if (i == 14)
                    if (GameMap.MapTile[i].Vertice[0] == 0)
                    {
                        ToggleVisiblity(BuildPlots[v]);
                        v++;
                    }
                    else v++;
                if (i == 15)
                    if (GameMap.MapTile[i].Vertice[5] == 0)
                    {
                        ToggleVisiblity(BuildPlots[v]);
                        v++;
                    }
                    else v++;
                if (i == 16)
                    if (GameMap.MapTile[i].Vertice[4] == 0)
                    {
                        ToggleVisiblity(BuildPlots[v]);
                        v++;
                    }
                    else v++;
                if (i == 17)
                    if (GameMap.MapTile[i].Vertice[3] == 0)
                    {
                        ToggleVisiblity(BuildPlots[v]);
                        v++;
                    }
                    else v++;


            }
            
        }
        private void ShowUpgradableSettlements(Player currentPlayer)
        {
            PictureBox[] BuildPlots = new PictureBox[54] {Vertice00,Vertice01,Vertice02,Vertice03,Vertice04,Vertice05,Vertice12,Vertice13,Vertice14,Vertice15,Vertice22,Vertice23,Vertice24,Vertice25,
                                                            Vertice31,Vertice32,Vertice33,Vertice34,Vertice41,Vertice42,Vertice43,Vertice44,Vertice50,Vertice51,Vertice52,Vertice53,Vertice60,Vertice61,
                                                            Vertice62,Vertice63,Vertice70,Vertice71,Vertice72,Vertice75,Vertice80,Vertice81,Vertice82,Vertice85,Vertice90,Vertice91,Vertice94,Vertice95,
                                                            Vertice100,Vertice101,Vertice104,Vertice105,Vertice110,Vertice113,Vertice122,Vertice131,Vertice140,Vertice155,Vertice164,Vertice173};
            foreach (var element in BuildPlots)
            {
                if (buildCity)
                {
                    if (currentPlayer.PlayerNumber == 1)
                    {
                        if (element.Image == RedSettlementImage)
                            element.BackColor = Color.LightGoldenrodYellow;
                    }
                    else if (currentPlayer.PlayerNumber == 2)
                    {
                        if (element.Image == BlueSettlementImage)
                            element.BackColor = Color.LightGoldenrodYellow;
                    }
                    else if (currentPlayer.PlayerNumber == 3)
                    {
                        if (element.Image == OrangeSettlementImage)
                            element.BackColor = Color.LightGoldenrodYellow;
                    }
                    else if (currentPlayer.PlayerNumber == 4)
                    {
                        if (element.Image == WhiteSettlementImage)
                            element.BackColor = Color.LightGoldenrodYellow;
                    }
                }
                else
                    element.BackColor = Color.White;
            }
        }
        /// <summary>
        /// Toggle visibility of a picturebox form
        /// </summary>
        /// <param name="a"></param>
        private void ToggleVisiblity( PictureBox a)
        {
            if (a.Visible == true)
            {
                a.Hide();
            }
            else
            {
                a.Show();
            }

        }

        private void Vertice00_Click(object sender, EventArgs e)
        {
            if(buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice00, 0, 0);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0],Vertice00, 0, 0);
                buildCity = !buildCity;
                ShowUpgradableSettlements(PlayerOrder[0]);
            }
        }
        private void PlaceSettlement(Map GameMap, Player currentPlayer,PictureBox BuildPlot, int tile, int vertice)
        {
            if(GameMaster.DistanceRule(GameMap,tile,vertice))
            {
                GameMaster.BuildSettlement(GameMap, PlayerOrder[0], 0, 0);
                if (GameMap.MapTile[tile].Vertice[vertice]== RedPlayer.PlayerNumber)
                    BuildPlot.Image = RedSettlementImage;
                else if (GameMap.MapTile[tile].Vertice[vertice] == BluePlayer.PlayerNumber)
                    BuildPlot.Image = BlueSettlementImage;
                else if (GameMap.MapTile[tile].Vertice[vertice] == OrangePlayer.PlayerNumber)
                    BuildPlot.Image = OrangeSettlementImage;
                else if(GameMap.MapTile[tile].Vertice[vertice] == WhitePlayer.PlayerNumber)
                    BuildPlot.Image = WhiteSettlementImage;
                ShowPlots();
            }
        }
        private void PlaceCity(Map GameMap, Player currentPlayer, PictureBox Settlement, int tile, int vertice)
        {
                GameMaster.BuildSettlement(GameMap, PlayerOrder[0], 0, 0);
                if (GameMap.MapTile[tile].Vertice[vertice] == RedPlayer.PlayerNumber+RedPlayer.PlayerNumber*10)
                    Settlement.Image = RedCityImage;
                else if (GameMap.MapTile[tile].Vertice[vertice] == BluePlayer.PlayerNumber+BluePlayer.PlayerNumber*10)
                    Settlement.Image = BlueCityImage;
                else if (GameMap.MapTile[tile].Vertice[vertice] == OrangePlayer.PlayerNumber+OrangePlayer.PlayerNumber*10)
                    Settlement.Image = OrangeCityImage;
                else if (GameMap.MapTile[tile].Vertice[vertice] == WhitePlayer.PlayerNumber+WhitePlayer.PlayerNumber*10)
                    Settlement.Image = WhiteCityImage;
        }
        /// <summary>
        /// Initial Setup turns
        /// </summary>
        private void SetupTurns()
        {
            for(int i=0;i<=4;i++)
            {
                PlayerOrder[i] = new Player("Pointer",0);
            }
            PlayerOrder[0] = RedPlayer;
            PlayerOrder[1] = BluePlayer;
            PlayerOrder[2] = OrangePlayer;
            PlayerOrder[3] = WhitePlayer;

            foreach(var element in PlayerOrder)
            {
                element.BrickHeld.Value++;
                element.GrainHeld.Value++;
                element.SheepHeld.Value++;
                element.WoodHeld.Value++;
            }
        }
        private void NextTurn()
        {
            PlayerOrder[4] = PlayerOrder[0];//Player[4] is not a used player
            PlayerOrder[0] = PlayerOrder[1];
            PlayerOrder[1] = PlayerOrder[2];
            PlayerOrder[2] = PlayerOrder[3];
            PlayerOrder[3] = PlayerOrder[4];
        }
        /// <summary>
        /// Update the UI objects in the form corresponding to players
        /// </summary>
        private void UpdateUI()
        {
            Last_player_label.Text = PlayerOrder[3].PlayerName;
            TextPlayerColor(Last_player_label, PlayerOrder[3]);
            LoadPlayerIcons(Last_player_city, Last_player_settlement, PlayerOrder[3].PlayerNumber);

            Second_player_label.Text = PlayerOrder[2].PlayerName;
            TextPlayerColor(Second_player_label, PlayerOrder[2]);
            LoadPlayerIcons(Second_player_city, Second_player_settlement, PlayerOrder[2].PlayerNumber);

            Next_player_label2.Text = PlayerOrder[1].PlayerName;
            TextPlayerColor(Next_player_label2, PlayerOrder[1]);
            LoadPlayerIcons(Next_player_city, Next_player_settlement, PlayerOrder[1].PlayerNumber);

            Current_player_label.Text = PlayerOrder[0].PlayerName;
            TextPlayerColor(Current_player_label, PlayerOrder[0]);
            LoadPlayerIcons(Current_player_city, Current_player_settlement, PlayerOrder[0].PlayerNumber);

        }
        /// <summary>
        /// Change the color of the Player labels in the form depending on which player is currently assigned
        /// to that label.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private void TextPlayerColor(Label a,Player b)
        {
            if (b.PlayerNumber == 1)
                a.ForeColor = Color.Red;
            else if (b.PlayerNumber == 2)
                a.ForeColor = Color.LightBlue;
            else if (b.PlayerNumber == 3)
                a.ForeColor = Color.Orange;
            else
                a.ForeColor = Color.White;
        }
        /// <summary>
        /// Change the images of the Player settlement and city icons in the form depending on which player is
        /// currently assigned to that label.
        /// </summary>
        /// <param name="city"></param>
        /// <param name="settlement"></param>
        /// <param name="PlayerNumber"></param>
        private void LoadPlayerIcons(PictureBox city, PictureBox settlement, int PlayerNumber)
        {
            switch(PlayerNumber)
            {
                case 1:
                    city.Image = GameWindow.RedCityImage;
                    settlement.Image = GameWindow.RedSettlementImage;
                    break;
                case 2:
                    city.Image = GameWindow.BlueCityImage;
                    settlement.Image = GameWindow.BlueSettlementImage;
                    break;
                case 3:
                    city.Image = GameWindow.OrangeCityImage;
                    settlement.Image = GameWindow.OrangeSettlementImage;
                    break;
                case 4:
                    city.Image = GameWindow.WhiteCityImage;
                    settlement.Image = GameWindow.WhiteSettlementImage;
                    break;
            }
        }
        /// <summary>
        /// Holds all "transparency" calls, and locations within child objects' corresponding parent objects
        /// </summary>
        private void UIPlacement()
        {
            pictureBox1.Controls.Add(pictureBox2);
            pictureBox2.Location = new Point(400, 25);
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Controls.Add(tile0);
            tile0.Location = new Point(199, 64);
            tile0.BackColor = Color.Transparent;
            pictureBox2.Controls.Add(tile1);
            tile1.BackColor = Color.Transparent;
            tile1.Location = new Point(145, 157);

            pictureBox2.Controls.Add(tile11);
            tile11.BackColor = Color.Transparent;
            tile11.Location = new Point(310, 64);

            pictureBox2.Controls.Add(tile10);
            tile10.BackColor = Color.Transparent;
            tile10.Location = new Point(421, 64);

            RightPanel.Controls.Add(Next_player_city);
            Next_player_city.BackColor = Color.Transparent;
            Next_player_city.Location = new Point(210, 450);

            RightPanel.Controls.Add(Next_player_settlement);
            Next_player_settlement.BackColor = Color.Transparent;
            Next_player_settlement.Location = new Point(300, 450);

            RightPanel.Controls.Add(Second_player_city);
            Second_player_city.BackColor = Color.Transparent;
            Second_player_city.Location = new Point(210, 175);

            RightPanel.Controls.Add(Second_player_settlement);
            Second_player_settlement.BackColor = Color.Transparent;
            Second_player_settlement.Location = new Point(300, 175);

            LeftPanel.Controls.Add(Last_player_city);
            Last_player_city.BackColor = Color.Transparent;
            Last_player_city.Location = new Point(210, 175);

            LeftPanel.Controls.Add(Last_player_settlement);
            Last_player_settlement.BackColor = Color.Transparent;
            Last_player_settlement.Location = new Point(300, 175);

            BottomPanel.Controls.Add(Current_player_city);
            Current_player_city.BackColor = Color.Transparent;
            Current_player_city.Location = new Point(50, 60);

            BottomPanel.Controls.Add(Current_player_settlement);
            Current_player_settlement.BackColor = Color.Transparent;
            Current_player_settlement.Location = new Point(50, 130);
        }


    }
}
