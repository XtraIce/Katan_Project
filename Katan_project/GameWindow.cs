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
/// <summary>
/// RIKER QUINTANA
/// 816823248
/// </summary>
namespace Katan_project
{
    public partial class GameWindow : Form
    {
        public static bool randomizeCheck;
        public static bool enableCheat;
        public static bool enableMusic;
        public static bool buildSettlement;
        public static bool buildCity;
        public static bool buildRoad;
        public static SoundPlayer audio = new SoundPlayer(Katan_project.Properties.Resources.KatanMusic); // here Katan_project is the namespace and KatanMusic is the audio file name
        private Map GameMap = new Map(randomizeCheck);
        private Player RedPlayer = new Player("Red",1);
        private Player BluePlayer = new Player("Blue",2);
        private Player OrangePlayer = new Player("Orange",3);
        private Player WhitePlayer = new Player("White",4);
        private Player[] PlayerOrder = new Player[5];
        private PictureBox[] roadImages = new PictureBox[72];
        private int[,] availRoads;

        public static Image RedCityImage = Properties.Resources.RedCity;
        public static Image RedSettlementImage = Properties.Resources.RedSettlement;
        public static Image BlueCityImage = Properties.Resources.BlueCity;
        public static Image BlueSettlementImage = Properties.Resources.BlueSettlement;
        public static Image OrangeCityImage = Properties.Resources.OrangeCIty;
        public static Image OrangeSettlementImage = Properties.Resources.OrangeSettlement;
        public static Image WhiteCityImage = Properties.Resources.WhiteCity;
        public static Image WhiteSettlementImage = Properties.Resources.WhiteSettlement;
        public static Image RedRoadVert = Properties.Resources.RedRoadVert;
        public static Image BlueRoadVert = Properties.Resources.BlueRoadVert;
        public static Image OrangeRoadVert = Properties.Resources.OrangeRoadVert;
        public static Image WhiteRoadVert = Properties.Resources.WhiteRoadVert;
        public static Image RedRoadRight = Properties.Resources.RedRoadRight;
        public static Image BlueRoadRight = Properties.Resources.BlueRoadRight;
        public static Image OrangeRoadRight = Properties.Resources.OrangeRoadRight;
        public static Image WhiteRoadRight = Properties.Resources.WhiteRoadRight;
        public static Image RedRoadLeft = Properties.Resources.RedRoadLeft;
        public static Image BlueRoadLeft = Properties.Resources.BlueRoadLeft;
        public static Image OrangeRoadLeft = Properties.Resources.OrangeRoadLeft;
        public static Image WhiteRoadLeft = Properties.Resources.WhiteRoadLeft;



        public GameWindow()
        {
            InitializeComponent();
            UIPlacement();
            if (!enableMusic)
            {
                audio.PlayLooping();
            }
            AssignTileImages(GameMap);
            AssignDiceImages(GameMap);
            AssignRoadImages();
            SetupTurns();
            UpdateUI();
            InformationBox.Text += "Welcome to Project Katan."+Environment.NewLine;

            //This don't work
            /*
            TransparentControl TileA = new TransparentControl();
            TileA.Image = System.Drawing.Image.FromFile(@"C:\Users\Riker\OneDrive\CatanMaterials\BrickTileSmall.png");
            TileA.Location = new Point(500, 500);
            TileA.Show();
            TileA.BringToFront();
            */
        }
        /// <summary>
        /// Assigns the tile images on the game board to the correct tile type of the Tile array MapTile
        /// </summary>
        /// <param name="map"></param>
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
        private void AssignRoadImages()
        {
            roadImages = new PictureBox[]{ road00,road01,road04,road05,road10,road11,road14,road15,road20,road21,road23,road24,road25,road30,road31,road33,road34,road35,road40,road41,road42,road43,road44,road45,
                                                          road50,road51,road52,road53,road55,road60,road61,road62,road63,road65,road70,road71,road72,road75,road80,road81,road82,road85,road90,road91,road95,road100,road101,
                                                          road105,road110,road111,road115,road120,road121,road125,road130,road131,road135,road140,road141,road145,road150,road151,road155,road160,road161,road165,road170,road171,road175,road180,road181,road185};
            availRoads = new int[19, 6];
        }
        /// <summary>
        /// Assignes integer value labels over the tile images corresponding to their designated Dice Value
        /// Changes each labels font size depending on their probability of being rolled (highest are Color.Red)
        /// </summary>
        /// <param name="map"></param>
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

                if (map.MapTile[i].getDiceValue() == 6 || map.MapTile[i].getDiceValue() == 8)
                {
                    DiceImageArray[i].Font = new Font(FontFamily.GenericSansSerif, 22);
                    DiceImageArray[i].ForeColor = Color.Red;
                }
                else if (map.MapTile[i].getDiceValue() == 4 || map.MapTile[i].getDiceValue() == 10)
                {
                    DiceImageArray[i].Font = new Font(FontFamily.GenericSansSerif, 16);
                }
                else if (map.MapTile[i].getDiceValue() == 3 || map.MapTile[i].getDiceValue() == 11)
                {
                    DiceImageArray[i].Font = new Font(FontFamily.GenericSansSerif, 13);
                }
                else if (map.MapTile[i].getDiceValue() == 2 || map.MapTile[i].getDiceValue() == 12)
                {
                    DiceImageArray[i].Font = new Font(FontFamily.GenericSansSerif, 10);
                }
                else
                    DiceImageArray[i].Font = new Font(FontFamily.GenericSansSerif, 19);
                    
            }
        }

        // Calls NextTurn method. updates UI
        private void Continue_button_Click(object sender, EventArgs e)
        {
            if (!buildSettlement && !buildCity && !buildRoad)
            {
                NextTurn();
                UpdateUI();
            }
        }

        // calls ShowPlots method and toggles buildSettlement bool
        private void settlement_button_Click(object sender, EventArgs e)
        {
            if (!buildRoad && !buildCity)
            {
                ShowPlots();
                buildSettlement = !buildSettlement;
            }
        }
        // calls ShowUpgradeableSettlements method and toggles buildCity bool
        private void City_button_Click(object sender, EventArgs e)
        {
            if (!buildSettlement && !buildRoad)
            {
                buildCity = !buildCity;
                ShowUpgradableSettlements(PlayerOrder[0]);
            }
        }
        private void Road_button_Click(object sender, EventArgs e)
        {
            if(!buildSettlement && !buildCity)
            {
                buildRoad = !buildRoad;
                ShowRoads(PlayerOrder[0]);
            }
        }

        /// <summary>
        /// Displays resource cards equal to the current player's resources. If any type of resources exceeds 5, an integer value is displayed over it.
        /// </summary>
        private void ShowCurrentPlayerResources()
        {
            Label [] resourceNumbers = new Label[5] { BrickNumber,OreNumber,SheepNumber,GrainNumber,WoodNumber};
            PictureBox[,] resourcesImages = new PictureBox[5, 5] { { brick1, brick2, brick3, brick4, brick5 },{ ore1, ore2, ore3, ore4, ore5 },{ sheep1, sheep2, sheep3, sheep4, sheep5 },{ grain1, grain2, grain3, grain4, grain5 },{ wood1, wood2, wood3, wood4, wood5 } };
            int[] currentResources = new int[5] { PlayerOrder[0].BrickHeld.Value, PlayerOrder[0].OreHeld.Value, PlayerOrder[0].SheepHeld.Value, PlayerOrder[0].GrainHeld.Value, PlayerOrder[0].WoodHeld.Value };

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (j < currentResources[i])
                        resourcesImages[i, j].Show();
                    else
                    {
                        resourcesImages[i, j].Hide();
                    }
                }
                if (currentResources[i] > 5)
                {
                    resourceNumbers[i].Show();
                    resourceNumbers[i].Text = currentResources[i].ToString();
                }
                else
                    resourceNumbers[i].Hide();
            }
        }
        /// <summary>
        /// Displays integer values of all non-current player resources, overlayed on their resource type image
        /// </summary>
        private void ShowOtherPlayerResources()
        {
            LastBrickNum.Text = PlayerOrder[3].BrickHeld.Value.ToString();
            LastSheepNum.Text = PlayerOrder[3].SheepHeld.Value.ToString();
            LastOreNum.Text = PlayerOrder[3].OreHeld.Value.ToString();
            LastWoodNum.Text = PlayerOrder[3].WoodHeld.Value.ToString();
            LastGrainNum.Text = PlayerOrder[3].GrainHeld.Value.ToString();

            SecBrickNum.Text = PlayerOrder[2].BrickHeld.Value.ToString();
            SecSheepNum.Text = PlayerOrder[2].SheepHeld.Value.ToString();
            SecOreNum.Text = PlayerOrder[2].OreHeld.Value.ToString();
            SecWoodNum.Text = PlayerOrder[2].WoodHeld.Value.ToString();
            SecGrainNum.Text = PlayerOrder[2].GrainHeld.Value.ToString();

            NexBrickNum.Text = PlayerOrder[1].BrickHeld.Value.ToString();
            NexSheepNum.Text = PlayerOrder[1].SheepHeld.Value.ToString();
            NexOreNum.Text = PlayerOrder[1].OreHeld.Value.ToString();
            NexWoodNum.Text = PlayerOrder[1].WoodHeld.Value.ToString();
            NexGrainNum.Text = PlayerOrder[1].GrainHeld.Value.ToString();
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
            for(int i=0;i<=17;i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j <= 5; j++)//0-5
                    {
                        if (GameMap.MapTile[i].Vertice[j] == 0)
                        {
                            ToggleVisiblity(BuildPlots[v]);
                            v++;
                        }
                        else v++;
                    }
                }
                if (i == 1 || i == 2)//6-13
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
                if (i == 3 || i == 4)//14-21
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
                if (i == 5 || i == 6)//22-29
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
                    for (int j = 0; j <= 2; j++)//30-32,34-36
                    {
                        if (GameMap.MapTile[i].Vertice[j] == 0)
                        {
                            ToggleVisiblity(BuildPlots[v]);
                            v++;
                        }
                        else v++;
                    }
                    if (GameMap.MapTile[i].Vertice[5] == 0)//33,37
                    {
                        ToggleVisiblity(BuildPlots[v]);
                        v++;
                    }
                    else v++;
                }
                if (i == 9 || i == 10)
                {
                    for (int j = 0; j <= 1; j++)//38-39,42-43
                    {
                        if (GameMap.MapTile[i].Vertice[j] == 0)
                        {
                            ToggleVisiblity(BuildPlots[v]);
                            v++;
                        }
                        else v++;
                    }
                    for (int j = 4; j <= 5; j++)//40-41,44-45
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
                    if (GameMap.MapTile[i].Vertice[0] == 0)//46
                    {
                        ToggleVisiblity(BuildPlots[v]);
                        v++;
                    }
                    else v++;
                    if (GameMap.MapTile[i].Vertice[3] == 0)//47
                    {
                        ToggleVisiblity(BuildPlots[v]);
                        v++;
                    }
                    else v++;
                }
                if (i == 12)
                    if (GameMap.MapTile[i].Vertice[2] == 0)//48
                    {
                        ToggleVisiblity(BuildPlots[v]);
                        v++;
                    }
                    else v++;
                if (i == 13)
                    if (GameMap.MapTile[i].Vertice[1] == 0)//49
                    {
                        ToggleVisiblity(BuildPlots[v]);
                        v++;
                    }
                    else v++;
                if (i == 14)
                    if (GameMap.MapTile[i].Vertice[0] == 0)//50
                    {
                        ToggleVisiblity(BuildPlots[v]);
                        v++;
                    }
                    else v++;
                if (i == 15)
                    if (GameMap.MapTile[i].Vertice[5] == 0)//51
                    {
                        ToggleVisiblity(BuildPlots[v]);
                        v++;
                    }
                    else v++;
                if (i == 16)
                    if (GameMap.MapTile[i].Vertice[4] == 0)//52
                    {
                        ToggleVisiblity(BuildPlots[v]);
                        v++;
                    }
                    else v++;
                if (i == 17)
                    if (GameMap.MapTile[i].Vertice[3] == 0)//53
                    {
                        ToggleVisiblity(BuildPlots[v]);
                        v++;
                    }
                   


            }
            
        }

        private void ShowRoads(Player currentPlayer)
        {
            int v = 0;
            if(buildRoad)
            { GameMaster.AvailableRoads(GameMap, currentPlayer, availRoads); }

            for (int i = 0; i <= 18; i++)
            {
                if (i == 0 || i == 1)
                {
                    for (int j = 0; j <= 1; j++)
                    {
                        if (availRoads[i, j] == currentPlayer.PlayerNumber && GameMap.MapTile[i].Edge[j] == 0)
                        {
                            ToggleVisiblity(roadImages[v]);
                            v++;
                        }
                        else v++;
                    }
                    for (int j = 4; j <= 5; j++)
                    {
                        if (availRoads[i, j] == currentPlayer.PlayerNumber && GameMap.MapTile[i].Edge[j] == 0)
                        {
                            ToggleVisiblity(roadImages[v]);
                            v++;
                        }
                        else v++;
                    }
                }
                if (i == 2 || i == 3)
                {
                    for (int j = 0; j <= 1; j++)
                    {
                        if (availRoads[i, j] == currentPlayer.PlayerNumber && GameMap.MapTile[i].Edge[j] == 0)
                        {
                            ToggleVisiblity(roadImages[v]);
                            v++;
                        }
                        else v++;
                    }
                    for (int j = 3; j <= 5; j++)
                    {
                        if (availRoads[i, j] == currentPlayer.PlayerNumber && GameMap.MapTile[i].Edge[j] == 0)
                        {
                            ToggleVisiblity(roadImages[v]);
                            v++;
                        }
                        else v++;
                    }

                }
                if (i == 4)
                {
                    for (int j = 0; j <= 5; j++)
                    {
                        if (availRoads[i, j] == currentPlayer.PlayerNumber && GameMap.MapTile[i].Edge[j] == 0)
                        {
                            ToggleVisiblity(roadImages[v]);
                            v++;
                        }
                        else v++;
                    }
                }
                if (i == 5 || i == 6)
                {
                    for (int j = 0; j <= 3; j++)
                    {
                        if (availRoads[i, j] == currentPlayer.PlayerNumber && GameMap.MapTile[i].Edge[j] == 0)
                        {
                            ToggleVisiblity(roadImages[v]);
                            v++;
                        }
                        else v++;
                    }
                    if(availRoads[i,5] == currentPlayer.PlayerNumber && GameMap.MapTile[i].Edge[5] == 0)
                    {
                            ToggleVisiblity(roadImages[v]);
                            v++;
                    }
                    else v++;
                }
                if (i == 7 || i == 8)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        if (availRoads[i, j] == currentPlayer.PlayerNumber && GameMap.MapTile[i].Edge[j] == 0)
                        {
                            ToggleVisiblity(roadImages[v]);
                            v++;
                        }
                        else v++;
                    }
                    if (availRoads[i, 5] == currentPlayer.PlayerNumber && GameMap.MapTile[i].Edge[5] == 0)
                    {
                        ToggleVisiblity(roadImages[v]);
                        v++;
                    }
                    else v++;
                }
                if (i == 9 || i == 10 || i == 11 || i == 12 || i == 13 || i == 14 || i == 15 || i == 16 || i == 17 || i == 18)
                {
                    for (int j = 0; j <= 1; j++)
                    {
                        if (availRoads[i, j] == currentPlayer.PlayerNumber && GameMap.MapTile[i].Edge[j] == 0)
                        {
                            ToggleVisiblity(roadImages[v]);
                            v++;
                        }
                        else v++;
                    }
                    if (availRoads[i, 5] == currentPlayer.PlayerNumber && GameMap.MapTile[i].Edge[5] == 0)
                    {
                        ToggleVisiblity(roadImages[v]);
                        v++;
                    }
                    else v++;
                }
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
                            element.BackColor = Color.LightBlue;
                    }
                    else if (currentPlayer.PlayerNumber == 2)
                    {
                        if (element.Image == BlueSettlementImage)
                            element.BackColor = Color.LightBlue;
                    }
                    else if (currentPlayer.PlayerNumber == 3)
                    {
                        if (element.Image == OrangeSettlementImage)
                            element.BackColor = Color.LightBlue;
                    }
                    else if (currentPlayer.PlayerNumber == 4)
                    {
                        if (element.Image == WhiteSettlementImage)
                            element.BackColor = Color.LightBlue;
                    }
                }
                else
                    element.BackColor = Color.Khaki;
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

        /// <summary>
        /// Method calls the DistanceRule to check for a legal position to build a settlement.
        /// BuildSettlement method is called.
        /// Assigns the image of the designated vertice buildplot to be current player color's settlement
        /// Hides all remaining BuildPlot
        /// calls UpdateUI method to check for changes in user resources
        /// </summary>
        /// <param name="GameMap"></param>
        /// <param name="currentPlayer"></param>
        /// <param name="BuildPlot"></param>
        /// <param name="tile"></param>
        /// <param name="vertice"></param>
        private void PlaceSettlement(Map GameMap, Player currentPlayer,PictureBox BuildPlot, int tile, int vertice)
        {
            if (GameMaster.DistanceRule(GameMap, tile, vertice))
            {
                GameMaster.BuildSettlement(GameMap, currentPlayer, tile, vertice);
                if (GameMap.MapTile[tile].Vertice[vertice] == RedPlayer.PlayerNumber)
                    BuildPlot.Image = RedSettlementImage;
                else if (GameMap.MapTile[tile].Vertice[vertice] == BluePlayer.PlayerNumber)
                    BuildPlot.Image = BlueSettlementImage;
                else if (GameMap.MapTile[tile].Vertice[vertice] == OrangePlayer.PlayerNumber)
                    BuildPlot.Image = OrangeSettlementImage;
                else if (GameMap.MapTile[tile].Vertice[vertice] == WhitePlayer.PlayerNumber)
                    BuildPlot.Image = WhiteSettlementImage;
                BuildPlot.SizeMode = PictureBoxSizeMode.StretchImage;
                BuildPlot.BackColor = Color.Azure;
                BuildPlot.Height = 30;
                BuildPlot.Width = 30;
                ShowPlots();
                UpdateUI();
            }
            else
            {
                ShowPlots();
                buildSettlement = false;
            }
            CheckWin(GameMaster.ScorePoints(RedPlayer, BluePlayer, OrangePlayer, WhitePlayer));
        }

        /// <summary>
        /// Checks if the selected vertice has a value between 1-4, meaning it is not empty nor currently a city
        /// Checks if the selected vertice settlement is own by the current player, as to not allow upgrading opponent settlements
        /// Calls UpgradeToCity method
        /// Assigns the image of the designated vertce settlement to be current player color's city
        /// calls UpdateUI method to check for changes in user resources
        /// </summary>
        /// <param name="GameMap"></param>
        /// <param name="currentPlayer"></param>
        /// <param name="Settlement"></param>
        /// <param name="tile"></param>
        /// <param name="vertice"></param>
        private void PlaceCity(Map GameMap, Player currentPlayer, PictureBox Settlement, int tile, int vertice)
        {
            if (GameMap.MapTile[tile].Vertice[vertice] > 0 && GameMap.MapTile[tile].Vertice[vertice] <= 4)
            {
                if (GameMap.MapTile[tile].Vertice[vertice] == currentPlayer.PlayerNumber)
                {
                    GameMaster.UpgradeToCity(GameMap, PlayerOrder[0], tile, vertice);
                    if (GameMap.MapTile[tile].Vertice[vertice] == RedPlayer.PlayerNumber + RedPlayer.PlayerNumber * 10)
                        Settlement.Image = RedCityImage;
                    else if (GameMap.MapTile[tile].Vertice[vertice] == BluePlayer.PlayerNumber + BluePlayer.PlayerNumber * 10)
                        Settlement.Image = BlueCityImage;
                    else if (GameMap.MapTile[tile].Vertice[vertice] == OrangePlayer.PlayerNumber + OrangePlayer.PlayerNumber * 10)
                        Settlement.Image = OrangeCityImage;
                    else if (GameMap.MapTile[tile].Vertice[vertice] == WhitePlayer.PlayerNumber + WhitePlayer.PlayerNumber * 10)
                        Settlement.Image = WhiteCityImage;
                    UpdateUI();
                }
            }
            buildCity = false;
            ShowUpgradableSettlements(PlayerOrder[0]);
            CheckWin(GameMaster.ScorePoints(RedPlayer, BluePlayer, OrangePlayer, WhitePlayer));

        }
        private void PlaceRoad(Map GameMap, Player currentPlayer, PictureBox Road, int tile, int edge)
        {
            if (GameMap.MapTile[tile].Edge[edge] == 0)
            {
                GameMaster.BuildRoad(GameMap, PlayerOrder[0], tile, edge);
                if (edge == 0 || edge == 3)
                {
                    if (GameMap.MapTile[tile].Edge[edge] == RedPlayer.PlayerNumber)
                        Road.Image = RedRoadLeft;
                    else if (GameMap.MapTile[tile].Edge[edge] == BluePlayer.PlayerNumber)
                        Road.Image = BlueRoadLeft;
                    else if (GameMap.MapTile[tile].Edge[edge] == OrangePlayer.PlayerNumber)
                        Road.Image = OrangeRoadLeft;
                    else if (GameMap.MapTile[tile].Edge[edge] == WhitePlayer.PlayerNumber)
                        Road.Image = WhiteRoadLeft;
                }
                else if (edge == 1 || edge == 4)
                {
                    if (GameMap.MapTile[tile].Edge[edge] == RedPlayer.PlayerNumber)
                        Road.Image = RedRoadVert;
                    else if (GameMap.MapTile[tile].Edge[edge] == BluePlayer.PlayerNumber)
                        Road.Image = BlueRoadVert;
                    else if (GameMap.MapTile[tile].Edge[edge] == OrangePlayer.PlayerNumber)
                        Road.Image = OrangeRoadVert;
                    else if (GameMap.MapTile[tile].Edge[edge] == WhitePlayer.PlayerNumber)
                        Road.Image = WhiteRoadVert;
                }
                else
                {
                    if (GameMap.MapTile[tile].Edge[edge] == RedPlayer.PlayerNumber)
                        Road.Image = RedRoadRight;
                    else if (GameMap.MapTile[tile].Edge[edge] == BluePlayer.PlayerNumber)
                        Road.Image = BlueRoadRight;
                    else if (GameMap.MapTile[tile].Edge[edge] == OrangePlayer.PlayerNumber)
                        Road.Image = OrangeRoadRight;
                    else if (GameMap.MapTile[tile].Edge[edge] == WhitePlayer.PlayerNumber)
                        Road.Image = WhiteRoadRight;
                }
                buildRoad = false;
                ShowRoads(PlayerOrder[0]);
                UpdateUI();
            }
            else
            {
                buildRoad = false;
                ShowRoads(PlayerOrder[0]);
            }
            GameMaster.ScorePoints(RedPlayer, BluePlayer, OrangePlayer, WhitePlayer);
        }

        /// <summary>
        /// Initial Setup turns
        /// </summary>
        private void SetupTurns()
        {
            buildCity = false;
            buildRoad = false;
            buildSettlement = false;
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
                element.BrickHeld.Value = 4;
                element.GrainHeld.Value = 2;
                element.SheepHeld.Value = 2;
                element.WoodHeld.Value = 4;
                element.OreHeld.Value = 0;
            }
            if(enableCheat)
            {
                foreach(var element in PlayerOrder)
                {
                    element.BrickHeld.Value = 99;
                    element.GrainHeld.Value = 99;
                    element.SheepHeld.Value = 99;
                    element.WoodHeld.Value  = 99;
                    element.OreHeld.Value   = 99;
                }
            }
        }

        /// <summary>
        /// rotates the current player order
        /// </summary>
        private void NextTurn()
        {
            PlayerOrder[4] = PlayerOrder[0];//Player[4] is not a used player
            PlayerOrder[0] = PlayerOrder[1];
            PlayerOrder[1] = PlayerOrder[2];
            PlayerOrder[2] = PlayerOrder[3];
            PlayerOrder[3] = PlayerOrder[4];

            InformationBox.Text += $"The Dice are rolled and the value is {GameMaster.GenerateResource(GameMap,RedPlayer,BluePlayer,OrangePlayer,WhitePlayer)}\n"+Environment.NewLine;
            CheckWin(GameMaster.ScorePoints(RedPlayer, BluePlayer, OrangePlayer, WhitePlayer));
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

            ShowCurrentPlayerResources();
            ShowOtherPlayerResources();

            LastCityNum.Text = PlayerOrder[3].OwnedCities.ToString();
            LastSettlementNum.Text = PlayerOrder[3].OwnedCities.ToString();
            SecCityNum.Text = PlayerOrder[2].OwnedCities.ToString();
            SecSettlementNum.Text = PlayerOrder[2].OwnedSettlements.ToString();
            NextCityNum.Text = PlayerOrder[1].OwnedCities.ToString();
            NextSettlementNum.Text = PlayerOrder[1].OwnedSettlements.ToString();
            CurrentCityNum.Text = PlayerOrder[0].OwnedCities.ToString();
            CurrentSettlementNum.Text = PlayerOrder[0].OwnedSettlements.ToString();
        }
        private void CheckWin(int winVar)
        {
            Player Winner = new Player("Winner",0);
            switch (winVar)
            {
                case 1:
                    Winner = RedPlayer;
                    break;
                case 2: Winner = BluePlayer;
                    break;
                case 3: Winner = OrangePlayer;
                    break;
                case 4: Winner = WhitePlayer;
                    break;
                default:
                    break;
            }
            if(winVar!=0)
            {
                string message = $"Congratulations! {Winner.PlayerName} is victorious! Katan is their dwelling!" + Environment.NewLine + "Shall we play again?" ;
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
                if(result == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                    GameWindow newGame = new GameWindow();
                    newGame.Show();
                }
                else
                {
                    this.Close();
                }
            }

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

            nexBrick.Controls.Add(NexBrickNum);
            NexBrickNum.BackColor = Color.Transparent;
            NexBrickNum.Location = new Point(0, 0);

            nexOre.Controls.Add(NexOreNum);
            NexOreNum.BackColor = Color.Transparent;
            NexOreNum.Location = new Point(0, 0);

            nexSheep.Controls.Add(NexSheepNum);
            NexSheepNum.BackColor = Color.Transparent;
            NexSheepNum.Location = new Point(0, 0);

            nexGrain.Controls.Add(NexGrainNum);
            NexGrainNum.BackColor = Color.Transparent;
            NexGrainNum.Location = new Point(0, 0);

            nexWood.Controls.Add(NexWoodNum);
            NexWoodNum.BackColor = Color.Transparent;
            NexWoodNum.Location = new Point(0, 0);

            secBrick.Controls.Add(SecBrickNum);
            SecBrickNum.BackColor = Color.Transparent;
            SecBrickNum.Location = new Point(0, 0);

            secOre.Controls.Add(SecOreNum);
            SecOreNum.BackColor = Color.Transparent;
            SecOreNum.Location = new Point(0, 0);

            secSheep.Controls.Add(SecSheepNum);
            SecSheepNum.BackColor = Color.Transparent;
            SecSheepNum.Location = new Point(0, 0);

            secGrain.Controls.Add(SecGrainNum);
            SecGrainNum.BackColor = Color.Transparent;
            SecGrainNum.Location = new Point(0, 0);

            secWood.Controls.Add(SecWoodNum);
            SecWoodNum.BackColor = Color.Transparent;
            SecWoodNum.Location = new Point(0, 0);

            lastBrick.Controls.Add(LastBrickNum);
            LastBrickNum.BackColor = Color.Transparent;
            LastBrickNum.Location = new Point(0, 0);

            lastOre.Controls.Add(LastOreNum);
            LastOreNum.BackColor = Color.Transparent;
            LastOreNum.Location = new Point(0, 0);

            lastSheep.Controls.Add(LastSheepNum);
            LastSheepNum.BackColor = Color.Transparent;
            LastSheepNum.Location = new Point(0,0);

            lastGrain.Controls.Add(LastGrainNum);
            LastGrainNum.BackColor = Color.Transparent;
            LastGrainNum.Location = new Point(0,0);

            lastWood.Controls.Add(LastWoodNum);
            LastWoodNum.BackColor = Color.Transparent;
            LastWoodNum.Location = new Point(0,0);

            Last_player_city.Controls.Add(LastCityNum);
            LastCityNum.BackColor = Color.Transparent;
            LastCityNum.Location = new Point(0, 0);

            Last_player_settlement.Controls.Add(LastSettlementNum);
            LastSettlementNum.BackColor = Color.Transparent;
            LastSettlementNum.Location = new Point(0, 0);

            Second_player_city.Controls.Add(SecCityNum);
            SecCityNum.BackColor = Color.Transparent;
            SecCityNum.Location = new Point(0, 0);

            Second_player_settlement.Controls.Add(SecSettlementNum);
            SecSettlementNum.BackColor = Color.Transparent;
            SecSettlementNum.Location = new Point(0, 0);

            Next_player_city.Controls.Add(NextCityNum);
            NextCityNum.BackColor = Color.Transparent;
            NextCityNum.Location = new Point(0, 0);

            Next_player_settlement.Controls.Add(NextSettlementNum);
            NextSettlementNum.BackColor = Color.Transparent;
            NextSettlementNum.Location = new Point(0, 0);

            Current_player_city.Controls.Add(CurrentCityNum);
            CurrentCityNum.BackColor = Color.Transparent;
            CurrentCityNum.Location = new Point(0, 0);

            Current_player_settlement.Controls.Add(CurrentSettlementNum);
            CurrentSettlementNum.BackColor = Color.Transparent;
            CurrentSettlementNum.Location = new Point(0, 0);
        }

        /// <summary>
        /// ALL ON CLICK EVENTS FOR PICTURE BOXES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Vertice00_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice00, 0, 0);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice00, 0, 0);
                
                
            }
        }

        private void Vertice01_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice01, 0, 1);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice01, 0, 1);
                
                
            }
        }

        private void Vertice02_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice02, 0, 2);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice02, 0, 2);
                
                
            }
        }

        private void Vertice03_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice03, 0, 3);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice03, 0, 3);
                
                
            }
        }

        private void Vertice04_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice04, 0, 4);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice04, 0, 0);
                
                
            }
        }
        private void Vertice05_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice05, 0, 5);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice05, 0, 0);
                
                
            }
        }

        private void Vertice12_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice12, 1, 2);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice12, 1, 2);
                
                
            }
        }

        private void Vertice13_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice13, 1, 3);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice13, 1, 3);
                
                
            }
        }

        private void Vertice14_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice14, 1, 4);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice14, 1, 4);
                
                
            }
        }

        private void Vertice15_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice15, 1, 5);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice15, 1, 5);
                
                
            }
        }

        private void Vertice22_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice22, 2, 2);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice22, 2, 2);
                
                
            }
        }

        private void Vertice23_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice23, 2, 3);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice23, 2, 3);
                
                
            }
        }

        private void Vertice24_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice24, 2, 4);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice24, 2, 4);
                
                
            }
        }

        private void Vertice25_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice25, 2, 5);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice25, 2, 5);
                
                
            }
        }

        private void Vertice31_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice31, 3, 1);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice31, 3, 1);
                
            }
        }

        private void Vertice32_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice32, 3, 2);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice32, 3, 2);
                
                
            }
        }

        private void Vertice33_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice33, 3, 3);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice33, 3, 3);
                
                
            }
        }

        private void Vertice34_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice34, 3, 4);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice34, 3, 4);
                
                
            }
        }

        private void Vertice41_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice41, 4, 1);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice41, 4, 1);
                
                
            }
        }

        private void Vertice42_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice42, 4,2);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice42, 4,2);
                
                
            }
        }

        private void Vertice43_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice43, 4, 3);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice43, 4, 3);
                
                
            }
        }

        private void Vertice44_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice44, 4, 4);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice44, 4, 4);
                
                
            }
        }

        private void Vertice50_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice50, 5, 0);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice50, 5, 0);
                
                
            }
        }

        private void Vertice51_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice51, 5, 1);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice51, 5, 1);
                
                
            }
        }

        private void Vertice52_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice52, 5, 2);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice52, 5, 2);
                
                
            }
        }

        private void Vertice53_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice53, 5, 3);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice53, 5,3);
                
                
            }
        }

        private void Vertice60_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice60, 6, 0);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice60, 6, 0);
                
                
            }
        }

        private void Vertice61_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice61, 6, 1);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice61, 6, 1);
                
                
            }
        }

        private void Vertice62_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice62, 6, 2);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice62, 6, 2);
                
                
            }
        }

        private void Vertice63_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice63, 6, 3);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice63, 6, 3);
                
                
            }
        }

        private void Vertice75_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice75, 7, 5);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice75, 7, 5);
                
                
            }
        }

        private void Vertice70_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice70, 7, 0);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice70, 7, 0);
                
                
            }
        }

        private void Vertice71_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice71, 7, 1);

            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice71, 7, 1);
                
                
            }
        }

        private void Vertice72_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice72, 7, 2);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice72, 7, 2);
                
                
            }
        }

        private void Vertice85_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice85, 8, 5);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice85, 8, 5);
                
                
            }
        }

        private void Vertice80_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice80, 8, 0);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice80, 8, 0);
                
                
            }
        }

        private void Vertice81_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice81, 8, 1);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice81, 8, 1);
                
                
            }
        }

        private void Vertice82_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice82, 8, 2);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice82, 8, 2);
                
                
            }
        }

        private void Vertice94_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice94, 9, 4);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice94, 9, 4);
                
                
            }
        }

        private void Vertice95_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice95, 9, 5);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice95, 9, 5);
                
                
            }
        }

        private void Vertice90_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice90, 9, 0);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice90, 9, 0);
                
                
            }
        }

        private void Vertice91_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice91, 9, 1);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice91, 9, 1);
                
                
            }
        }

        private void Vertice104_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice104, 10, 4);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice104, 10, 4);
                
                
            }
        }

        private void Vertice105_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice105, 10, 5);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice105, 10, 5);
                
                
            }
        }

        private void Vertice100_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice100, 10, 0);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice100, 10, 0);
                
                
            }
        }

        private void Vertice101_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice101, 10, 1);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice101, 10, 12);
                
                
            }
        }

        private void Vertice110_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice110, 11, 0);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice110, 11, 0);
                
                
            }
        }

        private void Vertice113_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice113, 11, 3);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice113, 11, 3);
                
                
            }
        }

        private void Vertice122_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice122, 12, 2);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice122, 12, 2);
                
                
            }
        }

        private void Vertice131_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice131, 13, 1);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice131, 13, 1);
                
                
            }
        }

        private void Vertice140_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice140, 14, 0);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice140, 14, 0);
                
                
            }
        }

        private void Vertice155_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice155, 15, 5);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice155, 15, 5);
                
                
            }
        }

        private void Vertice164_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice164, 16, 4);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice164, 16, 4);
                
                
            }
        }

        private void Vertice173_Click(object sender, EventArgs e)
        {
            if (buildSettlement)
            {
                PlaceSettlement(GameMap, PlayerOrder[0], Vertice173, 17, 3);
            }
            else if (buildCity)
            {
                PlaceCity(GameMap, PlayerOrder[0], Vertice173, 17, 3);
            }
        }
        private void road00_Click(object sender, EventArgs e)
        {
            if(buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road00, 0, 0);
            }
        }
        private void road05_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road05,0,5);
            }
        }

        private void road01_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road01,0,1);
            }
        }

        private void road04_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road04,0,4);
            }
        }
        private void road10_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road10,1,0);
            }
        }

        private void road11_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road11,1,1);
            }
        }

        private void road14_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road14,1,4);
            }
        }

        private void road15_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road15,1,5);
            }
        }

        private void road20_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road20,2,0);
            }
        }

        private void road21_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road21,2,1);
            }
        }

        private void road23_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road23,2,3);
            }
        }

        private void road24_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road24,2,4);
            }
        }

        private void road25_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road25,2,5);
            }
        }

        private void road35_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road35,3,5);
            }
        }

        private void road30_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road30,3,0);
            }
        }

        private void road31_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road31,3,1);
            }
        }

        private void road33_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road33,3,3);
            }
        }

        private void road34_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road34,3,4);
            }
        }

        private void road45_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road45,4,5);
            }
        }

        private void road40_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road40,4,0);
            }
        }

        private void road41_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road41,4,1);
            }
        }

        private void road42_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road42,4,2);
            }
        }

        private void road43_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road43,4,3);
            }
        }

        private void road44_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road44,4,4);
            }
        }

        private void road55_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road55,5,5);
            }
        }

        private void road50_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road50,5,0);
            }
        }

        private void road51_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road51,5,1);
            }
        }

        private void road52_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road52,5,2);
            }
        }

        private void road53_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road53,5,3);
            }
        }

        private void road60_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road60,6,0);
            }
        }

        private void road61_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road61,6,1);
            }
        }

        private void road62_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road62,6,2);
            }
        }

        private void road63_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road63,6,3);
            }
        }

        private void road65_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road65,6,5);
            }
        }

        private void road70_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road70,7,0);
            }
        }

        private void road71_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road71,7,1);
            }
        }

        private void road72_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road72,7,2);
            }
        }

        private void road75_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road75,7,5);
            }
        }

        private void road85_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road85,8,5);
            }
        }

        private void road80_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road80,8,0);
            }
        }

        private void road81_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road81,8,1);
            }
        }

        private void road82_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road82,8,2);
            }
        }

        private void road95_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road95,9,5);
            }
        }

        private void road90_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road90,9,0);
            }
        }

        private void road91_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road91,9,1);
            }
        }

        private void road105_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road105,10,5);
            }
        }

        private void road100_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road100,10,0);
            }
        }

        private void road101_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road101,10,1);
            }
        }

        private void road110_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road110,11,0);
            }
        }

        private void road111_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road111,11,1);
            }
        }

        private void road115_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road115,11,5);
            }
        }

        private void road120_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road120,12,0);
            }
        }

        private void road121_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road121,12,1);
            }
        }
        private void road125_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road125, 12, 5);
            }
        }

        private void road130_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road130,13,0);
            }
        }

        private void road131_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road131,13,1);
            }
        }

        private void road135_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road135,13,5);
            }
        }

        private void road140_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road140,14,0);
            }
        }

        private void road141_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road141,14,1);
            }
        }

        private void road145_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road145,14,5);
            }
        }

        private void road150_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road150,15,0);
            }
        }

        private void road151_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road151,15,1);
            }
        }

        private void road155_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road155,15,5);
            }
        }

        private void road160_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road160,16,0);
            }
        }

        private void road161_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road161,16,1);
            }
        }

        private void road165_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road165,16,5);
            }
        }

        private void road170_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road170,17,0);
            }
        }

        private void road171_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road171,17,1);
            }
        }

        private void road175_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road175,17,5);
            }
        }

        private void road180_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road180,18,0);
            }
        }

        private void road181_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road181,18,1);
            }
        }

        private void road185_Click(object sender, EventArgs e)
        {
            if (buildRoad)
            {
                PlaceRoad(GameMap, PlayerOrder[0], road185,18,5);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings n = new Settings();
            n.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
            audio.Stop();
            
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.catan.com/service/game-rules");
        }
    }
}
