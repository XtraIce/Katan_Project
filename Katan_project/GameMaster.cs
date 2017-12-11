using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katan_project
{
    public static class GameMaster
    {
        /// <summary>
        /// player 1 settlement: 1
        /// "      " city: 11
        /// player 2 settlement: 2
        /// "      " city: 22
        /// player 3 settlement: 3
        /// "      " city: 33   
        /// player 4 settlement: 4
        /// "      " city: 44
        /// /// </summary>
        public static int GenerateResource(Map Map, Player P1, Player P2, Player P3, Player P4)
        {
            Random rnd = new Random();
            int dice1, dice2,diceTotal;
            dice1 = rnd.Next(1, 6);
            dice2 = rnd.Next(1, 6);
            diceTotal = dice1 + dice2;
            
            for (int i = 0; i <= 18; i++)
            {
                if (Map.MapTile[i].getDiceValue() == diceTotal)
                {
                    for (int j = 0; j <= 5; j++)
                    {
                        if (Map.MapTile[i].Vertice[j] == 1)
                        {
                            if (Map.MapTile[i] is TPasture)
                                P1.SheepHeld.Value += 1;
                            if (Map.MapTile[i] is THill)
                                P1.BrickHeld.Value += 1;
                            if (Map.MapTile[i] is TMountain)
                                P1.OreHeld.Value += 1;
                            if (Map.MapTile[i] is TForest)
                                P1.WoodHeld.Value += 1;
                            if (Map.MapTile[i] is TField)
                                P1.GrainHeld.Value += 1;
                        }
                        else if (Map.MapTile[i].Vertice[j] == 11)
                        {
                            if (Map.MapTile[i] is TPasture)
                                P1.SheepHeld.Value += 2;
                            if (Map.MapTile[i] is THill)
                                P1.BrickHeld.Value += 2;
                            if (Map.MapTile[i] is TMountain)
                                P1.OreHeld.Value += 2;
                            if (Map.MapTile[i] is TForest)
                                P1.WoodHeld.Value += 2;
                            if (Map.MapTile[i] is TField)
                                P1.GrainHeld.Value += 2;
                        }
                        if (Map.MapTile[i].Vertice[j] == 2)
                        {
                            if (Map.MapTile[i] is TPasture)
                                P2.SheepHeld.Value += 1;
                            if (Map.MapTile[i] is THill)
                                P2.BrickHeld.Value += 1;
                            if (Map.MapTile[i] is TMountain)
                                P2.OreHeld.Value += 1;
                            if (Map.MapTile[i] is TForest)
                                P2.WoodHeld.Value += 1;
                            if (Map.MapTile[i] is TField)
                                P2.GrainHeld.Value += 1;
                        }
                        else if (Map.MapTile[i].Vertice[j] == 22)
                        {
                            if (Map.MapTile[i] is TPasture)
                                P2.SheepHeld.Value += 2;
                            if (Map.MapTile[i] is THill)
                                P2.BrickHeld.Value += 2;
                            if (Map.MapTile[i] is TMountain)
                                P2.OreHeld.Value += 2;
                            if (Map.MapTile[i] is TForest)
                                P2.WoodHeld.Value += 2;
                            if (Map.MapTile[i] is TField)
                                P2.GrainHeld.Value += 2;
                        }
                        if (Map.MapTile[i].Vertice[j] == 3)
                        {
                            if (Map.MapTile[i] is TPasture)
                                P3.SheepHeld.Value += 1;
                            if (Map.MapTile[i] is THill)
                                P3.BrickHeld.Value += 1;
                            if (Map.MapTile[i] is TMountain)
                                P3.OreHeld.Value += 1;
                            if (Map.MapTile[i] is TForest)
                                P3.WoodHeld.Value += 1;
                            if (Map.MapTile[i] is TField)
                                P3.GrainHeld.Value += 1;
                        }
                        else if (Map.MapTile[i].Vertice[j] == 33)
                        {
                            if (Map.MapTile[i] is TPasture)
                                P3.SheepHeld.Value += 2;
                            if (Map.MapTile[i] is THill)
                                P3.BrickHeld.Value += 2;
                            if (Map.MapTile[i] is TMountain)
                                P3.OreHeld.Value += 2;
                            if (Map.MapTile[i] is TForest)
                                P3.WoodHeld.Value += 2;
                            if (Map.MapTile[i] is TField)
                                P3.GrainHeld.Value += 2;
                        }
                        if (Map.MapTile[i].Vertice[j] == 4)
                        {
                            if (Map.MapTile[i] is TPasture)
                                P4.SheepHeld.Value += 1;
                            if (Map.MapTile[i] is THill)
                                P4.BrickHeld.Value += 1;
                            if (Map.MapTile[i] is TMountain)
                                P4.OreHeld.Value += 1;
                            if (Map.MapTile[i] is TForest)
                                P4.WoodHeld.Value += 1;
                            if (Map.MapTile[i] is TField)
                                P4.GrainHeld.Value += 1;
                        }
                        else if (Map.MapTile[i].Vertice[j] == 44)
                        {
                            if (Map.MapTile[i] is TPasture)
                                P4.SheepHeld.Value += 2;
                            if (Map.MapTile[i] is THill)
                                P4.BrickHeld.Value += 2;
                            if (Map.MapTile[i] is TMountain)
                                P4.OreHeld.Value += 2;
                            if (Map.MapTile[i] is TForest)
                                P4.WoodHeld.Value += 2;
                            if (Map.MapTile[i] is TField)
                                P4.GrainHeld.Value += 2;
                        }
                    }
                }
            }
            return diceTotal;
        }
        /// <summary>
        /// Method checks if requested player has enough resources to build a settlement
        /// Checks if selected vertice is empty
        /// removes resources from player
        /// builds a settlement of the player's color on the vertice specified (Designated by number assigned, 1-4)
        /// adds 1 to player's settlement total
        /// </summary>
        /// <param name="Map"></param>
        /// <param name="currentPlayer"></param>
        /// <param name="selTile"></param>
        /// <param name="selVer"></param>
        public static void BuildSettlement(Map Map, Player currentPlayer, int selTile, int selVer)
        {
            if (currentPlayer.WoodHeld.Value >= 1 && currentPlayer.GrainHeld.Value >= 1 &&
               currentPlayer.BrickHeld.Value >= 1 && currentPlayer.SheepHeld.Value >= 1)
            {
                if (Map.MapTile[selTile].Vertice[selVer] == 0)
                {
                    currentPlayer.BrickHeld.Value--;
                    currentPlayer.GrainHeld.Value--;
                    currentPlayer.SheepHeld.Value--;
                    currentPlayer.WoodHeld.Value--;

                    Map.MapTile[selTile].Vertice[selVer] = currentPlayer.PlayerNumber;
                    currentPlayer.OwnedSettlements += 1;

                    UpdateVertices(Map);
                    GameWindow.buildSettlement = false;

                }
                else
                {
                    Console.WriteLine("That spot has already been built upon.");
                    GameWindow.buildSettlement = false;
                }
            }
            else
            {

                Console.WriteLine("Insufficient resources.");
                GameWindow.buildSettlement = false;
            }
        }
        /// <summary>
        /// Method checks if requested player has enough resources to build a city
        /// removes resources from player
        /// builds a city of the player's color on the vertice specified
        /// removes 1 from player's settlement total
        /// adds 1 to player's city total
        /// </summary>
        /// <param name="Map"></param>
        /// <param name="currentPlayer"></param>
        /// <param name="selTile"></param>
        /// <param name="selVer"></param>
        public static void UpgradeToCity(Map Map, Player currentPlayer, int selTile, int selVer)
        {
            if (currentPlayer.GrainHeld.Value >= 2 && currentPlayer.OreHeld.Value >= 3)
            {
                currentPlayer.GrainHeld.Value -= 2;
                currentPlayer.OreHeld.Value -= 3;
                Map.MapTile[selTile].Vertice[selVer] = (currentPlayer.PlayerNumber + currentPlayer.PlayerNumber * 10);
                currentPlayer.OwnedSettlements -= 1;
                currentPlayer.OwnedCities += 1;
                UpdateVertices(Map);
            }
        }
        /// <summary>
        /// Method checks if requested palyer has enough resources to build a road
        /// removes resources from player
        /// builds a road of the player's color on the vertice specified
        /// adds 1 to player's road total
        /// </summary>
        /// <param name="Map"></param>
        /// <param name="currentPlayer"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public static void BuildRoad(Map Map, Player currentPlayer, int i, int j)
        {
            if (Map.MapTile[i].Edge[j] == 0 && currentPlayer.WoodHeld.Value >= 1 && currentPlayer.BrickHeld.Value >= 1)
            {
                currentPlayer.WoodHeld.Value--;
                currentPlayer.BrickHeld.Value--;
                Map.MapTile[i].Edge[j] = currentPlayer.PlayerNumber;
                currentPlayer.OwnedRoads += 1;
                UpdateEdges(Map);
            }
        }
        public static int ScorePoints(Player P1,Player P2,Player P3,Player P4)
        {
            if (P1.VictoryPoints() >= 10)
                return 1;
            else if (P2.VictoryPoints() >= 10)
                return 2;
            else if (P3.VictoryPoints() >= 10)
                return 3;
            else if (P4.VictoryPoints() >= 10)
                return 4;
            else
                return 0;

        }
        public static void BasicTrade()
        {

        }
        public static void PortTrade()
        {

        }
        /// <summary>
        /// A Complex Algorithm
        /// DistanceRule checks the vertice selected to see if neighboring vertices are occupied
        /// If occupied, returns false
        /// If unoccupied, returns true
        /// </summary>
        /// <param name="selTile"></param>
        /// <param name="selVer"></param>
        /// <returns></returns>
        public static bool DistanceRule(Map Map, int selTile, int selVer)
        {

            /// REFERENCE MAP
            /// 
            ///                0    11    10
            ///
            ///            1    12     17    9
            ///            
            ///        2     13     18    16     8
            ///        
            ///            3     14    15     7
            ///            
            ///                4     5    6
            /// REFERENCE MAP

            int k = 0;
            int o = 0;
            int caseNum = selVer;
            // All the proper offsets for tiles and their relationships to neighboring tiles
            switch (selTile)
            {
                case 1: break;
                case 2: break;
                case 3: k = 1; caseNum += 1; break;
                case 4: k = 2; caseNum += 1; break;
                case 5: k = 2; caseNum += 2; break;
                case 6: k = 3; caseNum += 2; break;
                case 7: k = 3; caseNum += 3; break;
                case 8: k = 4; caseNum += 3; break;
                case 9: k = 4; caseNum += 4; break;
                case 10: k = 5; caseNum += 4; break;
                case 13: k = 12; o = 5; break;
                case 14: k = 11; o = 4; caseNum += 1; break;
                case 15: k = 10; o = 3; caseNum += 2; break;
                case 16: k = 9; o = 2; caseNum += 3; break;
            }
            // If the maxVert number (5) is exceeded, then it resets
            switch (caseNum)
            {
                case 6: caseNum = 0; break;
                case 7: caseNum = 1; break;
                case 8: caseNum = 2; break;
                case 9: caseNum = 3; break;
            }
            //m is the previous vertice
            int m = selVer - 1;
            if (m == -1)
                m = 5;
            //n is the following vertice
            int n = selVer + 1;
            if (n == 6)
                n = 0;
            //j variable is the neighboring relationship to the inner tile from the outer tile
            int j = 12 - selTile + k;
            //Tiles 2,4,6,8,10 have same relationships as 1,3,5,7,9
            //except for vertice 4 is bordering the ocean & only
            //neighbor one inner tile, so this:
            //sets a vert4 case to a vert5
            //sets a vert2 case to a vert3 
            if (selTile != 0 && selTile % 2 == 0 && selTile <= 10)
            {
                if (caseNum == 4)
                    caseNum = 5;
                if (caseNum == 2 || caseNum == 3)
                {
                    caseNum = 3;
                    //m = n;
                }
            }
            //Tile 0 is unique in neighboring-tile relationships
            if (selTile == 0)
            {
                switch (caseNum)
                {
                    case 0:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0)
                            return true;
                        break;
                    case 1:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[11].Vertice[m] == 0)
                            return true;
                        break;
                    case 2:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[12].Vertice[n] == 0)
                            return true;
                        break;
                    case 3:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[1].Vertice[m] == 0)
                            return true;
                        break;
                    case 4:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[1].Vertice[m] == 0)
                            return true;
                        break;
                    case 5:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0)
                            return true;
                        break;
                    default: return false;
                }
            }
            else if (selTile == 1 || selTile == 2 || selTile == 3 || selTile == 4 || selTile == 5 || selTile == 6 || selTile == 7 || selTile == 8 || selTile == 9 || selTile == 10)
            {
                switch (caseNum)
                {
                    case 0:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[selTile - 1].Vertice[m] == 0)
                            return true;
                        break;
                    case 1:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[selTile + j].Vertice[m] == 0)
                            return true;
                        break;
                    case 2:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[selTile + j + 1].Vertice[m] == 0)
                            return true;
                        break;
                    case 3:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[selTile + 1].Vertice[m] == 0)
                            return true;
                        break;
                    case 4:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[selTile + 1].Vertice[n] == 0)
                            return true;
                        break;
                    case 5:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0)
                            return true;
                        break;
                    default: return false;
                }
            }
            //Tile 11 is unique in neighboring-tile relationships
            else if (selTile == 11)
            {
                switch (caseNum)
                {
                    case 0:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0)
                            return true;
                        break;
                    case 1:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[10].Vertice[m] == 0)
                            return true;
                        break;
                    case 2:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[17].Vertice[m] == 0)
                            return true;
                        break;
                    case 3:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[12].Vertice[m] == 0)
                            return true;
                        break;
                    case 4:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[0].Vertice[m] == 0)
                            return true;
                        break;
                    case 5:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[0].Vertice[n] == 0)
                            return true;
                        break;
                    default: return false;
                }
            }
            //Tile 11 is unique in neighboring-tile relationships
            else if (selTile == 12)
            {
                switch (caseNum)
                {
                    case 0:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[0].Vertice[n] == 0)
                            return true;
                        break;
                    case 1:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[11].Vertice[m] == 0)
                            return true;
                        break;
                    case 2:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[17].Vertice[n] == 0)
                            return true;
                        break;
                    case 3:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[18].Vertice[n] == 0)
                            return true;
                        break;
                    case 4:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[13].Vertice[m] == 0)
                            return true;
                        break;
                    case 5:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[1].Vertice[n] == 0)
                            return true;
                        break;
                    default: return false;
                }
            }
            //Tiles 13,14,15,16 share the same tile #neighboring-tile relationships in reference to its own, but 14,15,16 are rotated from 13
            //because the map is circular. variable k and o account for this rotation.
            else if (selTile == 13 || selTile == 14 || selTile == 15 || selTile == 16)//11 should be excluded
            {
                switch (caseNum)
                {
                    case 0:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[selTile - k].Vertice[m] == 0)
                            return true;
                        break;
                    case 1:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[selTile - 1].Vertice[n] == 0)
                            return true;
                        break;
                    case 2:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[selTile + o].Vertice[n] == 0)
                            return true;
                        break;
                    case 3:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[selTile + 1].Vertice[n] == 0)
                            return true;
                        break;
                    case 4:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[selTile - k + 2].Vertice[m] == 0)
                            return true;
                        break;
                    case 5:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[selTile - k + 1].Vertice[n] == 0)
                            return true;
                        break;
                    default: return false;
                }
            }
            //Tile 17 is unique in neighboring-tile relationships
            else if (selTile == 17)
            {
                switch (caseNum)
                {
                    case 0:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[11].Vertice[n] == 0)
                            return true;
                        break;
                    case 1:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[10].Vertice[m] == 0)
                            return true;
                        break;
                    case 2:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[9].Vertice[n] == 0)
                            return true;
                        break;
                    case 3:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[16].Vertice[n] == 0)
                            return true;
                        break;
                    case 4:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[18].Vertice[m] == 0)
                            return true;
                        break;
                    case 5:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[12].Vertice[n] == 0)
                            return true;
                        break;
                    default: return false;
                }
            }
            Console.WriteLine("Not a valid path on CatanMap");
            return false;
        }
        /// <summary>
        /// A modified version of the DistanceRule to check for all available road placements for the current player
        /// sets AvailableRoad array to = currentPlayer.PlayerNumber if available
        /// Modified from distance rule because roads have 4 possible neighbors compared to a settlement's 3.
        /// A road can be build adjacent to any current road, settlement, or city a player owns
        /// </summary>
        /// <param name="Map"></param>
        /// <param name="currentPlayer"></param>
        /// <param name="availableRoad"></param>
        public static void AvailableRoads(Map Map, Player currentPlayer, int[,] availableRoad)
        {
            /// REFERENCE MAP
            /// 
            ///                0    11    10
            ///
            ///            1    12     17    9
            ///            
            ///        2     13     18    16     8
            ///        
            ///            3     14    15     7
            ///            
            ///                4     5    6
            /// REFERENCE MAP
            for (int selTile = 0; selTile <= 17; selTile++)
            {
                //This checks for currently owned roads
                for (int selEdge = 0; selEdge <= 5; selEdge++)
                {
                    if (Map.MapTile[selTile].Edge[selEdge] == currentPlayer.PlayerNumber)
                    {
                        int k = 0;
                        int o = 0;
                        int caseNum = selEdge;
                        // All the proper offsets for tiles and their relationships to neighboring tiles
                        switch (selTile)
                        {
                            case 1: break;
                            case 2: break;
                            case 3: k = 1; caseNum += 1; break;
                            case 4: k = 2; caseNum += 1; break;
                            case 5: k = 2; caseNum += 2; break;
                            case 6: k = 3; caseNum += 2; break;
                            case 7: k = 3; caseNum += 3; break;
                            case 8: k = 4; caseNum += 3; break;
                            case 9: k = 4; caseNum += 4; break;
                            case 10: k = 5; caseNum += 4; break;
                            case 13: k = 12; o = 5; break;
                            case 14: k = 11; o = 4; caseNum += 1; break;
                            case 15: k = 10; o = 3; caseNum += 2; break;
                            case 16: k = 9; o = 2; caseNum += 3; break;
                        }
                        // If the maxVert number (5) is exceeded, then it resets
                        switch (caseNum)
                        {
                            case 6: caseNum = 0; break;
                            case 7: caseNum = 1; break;
                            case 8: caseNum = 2; break;
                            case 9: caseNum = 3; break;
                        }
                        //m is the previous edge
                        int m = selEdge - 1;
                        if (m == -1)
                            m = 5;
                        //a is the previous previous edge
                        int a = m - 1;
                        if (a == -1)
                            a = 5;
                        //n is the current edge
                        int n = selEdge + 1;
                        if (n == 6)
                            n = 0;
                        //b is the following edge
                        int b = n + 1;
                        if (b == 6)
                            b = 0;

                        //j variable is the neighboring relationship to the inner tile from the outer tile
                        int j = 12 - selTile + k;
                        //Tiles 2,4,6,8,10 have same relationships as 1,3,5,7,9
                        //except for vertice 4 is bordering the ocean & only
                        //neighbor one inner tile, so this:
                        //sets a vert4 case to a vert5
                        //sets a vert2 case to a vert3 
                        if (selTile != 0 && selTile % 2 == 0 && selTile <= 10)
                        {
                            if (caseNum == 2)
                                caseNum = 3;
                            else if (caseNum == 3)
                                caseNum = 4;
                            else if (caseNum == 4)
                                caseNum = 6;
                        }
                        //Tile 0 is unique in neighboring-tile relationships
                        if (selTile == 0)
                        {
                            switch (caseNum)
                            {
                                case 0:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[11, m] = currentPlayer.PlayerNumber;
                                    break;
                                case 1:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[11, a] = currentPlayer.PlayerNumber;
                                    availableRoad[11, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 2:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[12, a] = currentPlayer.PlayerNumber;
                                    availableRoad[12, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 3:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[1, a] = currentPlayer.PlayerNumber;
                                    availableRoad[1, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 4:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[1, n] = currentPlayer.PlayerNumber;
                                    break;
                                case 5:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    break;

                            }
                        }
                        else if (selTile == 1 || selTile == 2 || selTile == 3 || selTile == 4 || selTile == 5 || selTile == 6 || selTile == 7 || selTile == 8 || selTile == 9 || selTile == 10)
                        {
                            switch (caseNum)
                            {
                                case 0:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile - 1, a] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile - 1, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 1:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile + j, a] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile + j, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 2:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile + j + 1, a] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile + j + 1, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 3:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile + 1, a] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile + 1, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 4:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile + 1, n] = currentPlayer.PlayerNumber;
                                    break;
                                case 5:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile - 1, m] = currentPlayer.PlayerNumber;
                                    break;
                                //only for even numbered tiles
                                case 6:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    break;
                            }
                        }
                        //Tile 11 is unique in neighboring-tile relationships
                        else if (selTile == 11)
                        {
                            switch (caseNum)
                            {
                                case 0:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[10, m] = currentPlayer.PlayerNumber;
                                    break;
                                case 1:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[10, a] = currentPlayer.PlayerNumber;
                                    availableRoad[10, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 2:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[17, a] = currentPlayer.PlayerNumber;
                                    availableRoad[17, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 3:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[12, a] = currentPlayer.PlayerNumber;
                                    availableRoad[12, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 4:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[0, a] = currentPlayer.PlayerNumber;
                                    availableRoad[0, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 5:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[0, n] = currentPlayer.PlayerNumber;
                                    break;
                            }
                        }
                        //Tile 11 is unique in neighboring-tile relationships
                        else if (selTile == 12)
                        {
                            switch (caseNum)
                            {
                                case 0:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[11, a] = currentPlayer.PlayerNumber;
                                    availableRoad[11, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 1:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[17, a] = currentPlayer.PlayerNumber;
                                    availableRoad[17, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 2:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[18, a] = currentPlayer.PlayerNumber;
                                    availableRoad[18, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 3:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[13, a] = currentPlayer.PlayerNumber;
                                    availableRoad[13, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 4:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[1, a] = currentPlayer.PlayerNumber;
                                    availableRoad[1, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 5:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[0, a] = currentPlayer.PlayerNumber;
                                    availableRoad[0, b] = currentPlayer.PlayerNumber;
                                    break;
                            }
                        }
                        //Tiles 13,14,15,16 share the same tile #neighboring-tile relationships in reference to its own, but 14,15,16 are rotated from 13
                        //because the map is circular. variable k and o account for this rotation.
                        else if (selTile == 13 || selTile == 14 || selTile == 15 || selTile == 16)//11 should be excluded
                        {
                            switch (caseNum)
                            {
                                case 0:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile - 1, a] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile - 1, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 1:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile + o, a] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile + o, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 2:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile + 1, a] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile + 1, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 3:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile - k + 2, a] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile - k + 2, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 4:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile - k + 1, a] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile - k + 1, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 5:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile - k, a] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile - k, b] = currentPlayer.PlayerNumber;
                                    break;
                            }
                        }
                        //Tile 17 is unique in neighboring-tile relationships
                        else if (selTile == 17)
                        {
                            switch (caseNum)
                            {
                                case 0:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[10, a] = currentPlayer.PlayerNumber;
                                    availableRoad[10, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 1:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[9, a] = currentPlayer.PlayerNumber;
                                    availableRoad[9, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 2:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[16, a] = currentPlayer.PlayerNumber;
                                    availableRoad[16, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 3:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[18, a] = currentPlayer.PlayerNumber;
                                    availableRoad[18, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 4:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[12, a] = currentPlayer.PlayerNumber;
                                    availableRoad[12, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 5:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[11, a] = currentPlayer.PlayerNumber;
                                    availableRoad[11, b] = currentPlayer.PlayerNumber;
                                    break;
                            }
                        }
                        else
                            Console.WriteLine("Not a valid path on CatanMap");
                    }
                }
                //This checks for currently owned settlements or cities
                for (int selVertice = 0; selVertice <= 5; selVertice++)
                {
                    if (Map.MapTile[selTile].Vertice[selVertice] == currentPlayer.PlayerNumber || Map.MapTile[selTile].Vertice[selVertice] == (currentPlayer.PlayerNumber + currentPlayer.PlayerNumber * 10))
                    {
                        int k = 0;
                        int o = 0;
                        int caseNum = selVertice;
                        // All the proper offsets for tiles and their relationships to neighboring tiles
                        switch (selTile)
                        {
                            case 1: break;
                            case 2: break;
                            case 3: k = 1; caseNum += 1; break;
                            case 4: k = 2; caseNum += 1; break;
                            case 5: k = 2; caseNum += 2; break;
                            case 6: k = 3; caseNum += 2; break;
                            case 7: k = 3; caseNum += 3; break;
                            case 8: k = 4; caseNum += 3; break;
                            case 9: k = 4; caseNum += 4; break;
                            case 10: k = 5; caseNum += 4; break;
                            case 13: k = 12; o = 5; break;
                            case 14: k = 11; o = 4; caseNum += 1; break;
                            case 15: k = 10; o = 3; caseNum += 2; break;
                            case 16: k = 9; o = 2; caseNum += 3; break;
                        }
                        // If the maxVert number (5) is exceeded, then it resets
                        switch (caseNum)
                        {
                            case 6: caseNum = 0; break;
                            case 7: caseNum = 1; break;
                            case 8: caseNum = 2; break;
                            case 9: caseNum = 3; break;
                        }
                        //m is the previous edge
                        int m = selVertice - 1;
                        if (m == -1)
                            m = 5;
                        //a is the previous previous edge
                        int a = m - 1;
                        if (a == -1)
                            a = 5;
                        //n is the current edge
                        int n = selVertice;
                        if (n == 6)
                            n = 0;
                        //b is the following edge
                        int b = n + 1;
                        if (b == 6)
                            b = 0;
                        //j variable is the neighboring relationship to the inner tile from the outer tile
                        int j = 12 - selTile + k;
                        //Tiles 2,4,6,8,10 have same relationships as 1,3,5,7,9
                        //except for vertice 4 is bordering the ocean & only
                        //neighbor one inner tile, so this:
                        //sets a vert4 case to a vert5
                        //sets a vert2 case to a vert3 
                        if (selTile != 0 && selTile % 2 == 0 && selTile <= 10)
                        {
                            if (caseNum == 2)
                                caseNum = 3;
                            else if (caseNum == 3)
                                caseNum = 4;
                            else if (caseNum == 4)
                                caseNum = 5;
                        }
                        //Tile 0 is unique in neighboring-tile relationships
                        if (selTile == 0)
                        {
                            switch (caseNum)
                            {
                                case 0:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    break;
                                case 1:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[11, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 2:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[12, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 3:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[1, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 4:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[1, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 5:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    break;

                            }
                        }
                        else if (selTile == 1 || selTile == 2 || selTile == 3 || selTile == 4 || selTile == 5 || selTile == 6 || selTile == 7 || selTile == 8 || selTile == 9 || selTile == 10)
                        {
                            switch (caseNum)
                            {
                                case 0:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile - 1, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 1:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile + j, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 2:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile + j + 1, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 3:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile + 1, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 4:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile + 1, b] = currentPlayer.PlayerNumber;
                                    break;
                                case 5:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    break;
                            }
                        }
                        //Tile 11 is unique in neighboring-tile relationships
                        else if (selTile == 11)
                        {
                            switch (caseNum)
                            {
                                case 0:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    break;
                                case 1:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[10, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 2:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[17, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 3:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[12, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 4:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[0, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 5:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[0, b] = currentPlayer.PlayerNumber;
                                    break;
                            }
                        }
                        //Tile 11 is unique in neighboring-tile relationships
                        else if (selTile == 12)
                        {
                            switch (caseNum)
                            {
                                case 0:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[11, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 1:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[17, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 2:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[18, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 3:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[13, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 4:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[1, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 5:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[0, b] = currentPlayer.PlayerNumber;
                                    break;
                            }
                        }
                        //Tiles 13,14,15,16 share the same tile #neighboring-tile relationships in reference to its own, but 14,15,16 are rotated from 13
                        //because the map is circular. variable k and o account for this rotation.
                        else if (selTile == 13 || selTile == 14 || selTile == 15 || selTile == 16)//11 should be excluded
                        {
                            switch (caseNum)
                            {
                                case 0:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile - 1, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 1:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile + o, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 2:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile + 1, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 3:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile - k + 2, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 4:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile - k + 1, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 5:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile - k, b] = currentPlayer.PlayerNumber;
                                    break;
                            }
                        }
                        //Tile 17 is unique in neighboring-tile relationships
                        else if (selTile == 17)
                        {
                            switch (caseNum)
                            {
                                case 0:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[10, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 1:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[9, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 2:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[16, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 3:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[18, a] = currentPlayer.PlayerNumber;
                                    break;
                                case 4:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[12, a] = currentPlayer.PlayerNumber;

                                    break;
                                case 5:
                                    availableRoad[selTile, m] = currentPlayer.PlayerNumber;
                                    availableRoad[selTile, n] = currentPlayer.PlayerNumber;
                                    availableRoad[11, b] = currentPlayer.PlayerNumber;
                                    break;
                            }
                        }
                    }
                }
            }
            if (availableRoad[0,1] != 0)
                availableRoad[11, 4] = availableRoad[0, 1];
            else
                availableRoad[0, 1] = availableRoad[11, 4];
            if (availableRoad[1, 0] != 0)
                availableRoad[0, 3] = availableRoad[1, 0];
            else
                availableRoad[1, 0] = availableRoad[0, 3];
            if (availableRoad[1, 1] != 0)
                availableRoad[12, 4] = availableRoad[1, 1];
            else
                availableRoad[1, 1] = availableRoad[12, 4];
            if (availableRoad[2, 0] != 0)
                availableRoad[1, 3] = availableRoad[2, 0];
            else
                availableRoad[2, 0] = availableRoad[1, 3];
            if (availableRoad[2, 1] != 0)
                availableRoad[13, 4] = availableRoad[2, 1];
            else
                availableRoad[2, 1] = availableRoad[13, 4];
            if (availableRoad[13, 3] != 0)
                availableRoad[3, 0] = availableRoad[13, 3];
            else
                availableRoad[13, 3] = availableRoad[3, 0];
            if (availableRoad[3, 1] != 0)
                availableRoad[14, 4] = availableRoad[3, 1];
            else
                availableRoad[3, 1] = availableRoad[14, 4];
            if (availableRoad[3, 5] != 0)
                availableRoad[2, 2] = availableRoad[3, 5];
            else
                availableRoad[3, 5] = availableRoad[2, 2];
            if (availableRoad[4, 0] != 0)
                availableRoad[14, 3] = availableRoad[4, 0];
            else
                availableRoad[4, 0] = availableRoad[14, 3];
            if (availableRoad[4, 1] != 0)
                availableRoad[5, 4] = availableRoad[4, 1];
            else
                availableRoad[4, 1] = availableRoad[5, 4];
            if (availableRoad[3, 2] != 0)
                availableRoad[4, 5] = availableRoad[3, 2];
            else
                availableRoad[3, 2] = availableRoad[4, 5];
            if (availableRoad[5, 0] != 0)
                availableRoad[15, 3] = availableRoad[5, 0];
            else
                availableRoad[5, 0] = availableRoad[15, 3];
            if (availableRoad[5, 1] != 0)
                availableRoad[6, 4] = availableRoad[5, 1];
            else
                availableRoad[5, 1] = availableRoad[6, 4];
            if (availableRoad[14, 2] != 0)
                availableRoad[5, 5] = availableRoad[14, 2];
            else
                availableRoad[14, 2] = availableRoad[5, 5];
            if (availableRoad[6, 0] != 0)
                availableRoad[7, 3] = availableRoad[6, 0];
            else
                availableRoad[6, 0] = availableRoad[7, 3];
            if (availableRoad[15, 2] != 0)
                availableRoad[6, 5] = availableRoad[15, 2];
            else
                availableRoad[15, 2] = availableRoad[6, 5];
            if (availableRoad[7, 0] != 0)
                availableRoad[8, 3] = availableRoad[7, 0];
            else
                availableRoad[7, 0] = availableRoad[8, 3];
            if (availableRoad[16, 2] != 0)
                availableRoad[7, 5] = availableRoad[16, 2];
            else
                availableRoad[16, 2] = availableRoad[7, 5];
            if (availableRoad[9, 2] != 0)
                availableRoad[8, 5] = availableRoad[9, 2];
            else
                availableRoad[9, 2] = availableRoad[8, 5];
            if (availableRoad[10, 2] != 0)
                availableRoad[9, 5] = availableRoad[10, 2];
            else
                availableRoad[10, 2] = availableRoad[9, 5];
            if (availableRoad[11, 1] != 0)
                availableRoad[10, 4] = availableRoad[11, 1];
            else
                availableRoad[11, 1] = availableRoad[10, 4];
            if (availableRoad[12, 0] != 0)
                availableRoad[11, 3] = availableRoad[12, 0];
            else
                availableRoad[12, 0] = availableRoad[11, 3];
            if (availableRoad[12, 1] != 0)
                availableRoad[17, 4] = availableRoad[12, 1];
            else
                availableRoad[12, 1] = availableRoad[17, 4];
            if (availableRoad[12, 5] != 0)
                availableRoad[0, 2] = availableRoad[12, 5];
            else
                availableRoad[12, 5] = availableRoad[0, 2];
            if (availableRoad[13, 0] != 0)
                availableRoad[12, 3] = availableRoad[13, 0];
            else
                availableRoad[13, 0] = availableRoad[12, 3];
            if (availableRoad[13, 1] != 0)
                availableRoad[18, 4] = availableRoad[13, 1];
            else
                availableRoad[13, 1] = availableRoad[18, 4];
            if (availableRoad[13, 5] != 0)
                availableRoad[1, 2] = availableRoad[13, 5];
            else
                availableRoad[13, 5] = availableRoad[1, 2];
            if (availableRoad[14, 0] != 0)
                availableRoad[18,3] = availableRoad[14, 0];
            else
                availableRoad[14, 0] = availableRoad[18, 3];
            if (availableRoad[14, 1] != 0)
                availableRoad[15, 4] = availableRoad[14, 1];
            else
                availableRoad[14, 1] = availableRoad[15, 4];
            if (availableRoad[13, 2] != 0)
                availableRoad[14, 5] = availableRoad[13, 2];
            else
                availableRoad[13, 2] = availableRoad[14, 5];
            if (availableRoad[15, 0] != 0)
                availableRoad[16, 3] = availableRoad[15, 0];
            else
                availableRoad[15, 0] = availableRoad[16, 3];
            if (availableRoad[15, 1] != 0)
                availableRoad[7, 4] = availableRoad[15, 1];
            else
                availableRoad[15, 1] = availableRoad[7, 4];
            if (availableRoad[15, 5] != 0)
                availableRoad[18, 2] = availableRoad[15, 5];
            else
                availableRoad[15, 5] = availableRoad[18, 2];
            if (availableRoad[16, 0] != 0)
                availableRoad[9, 3] = availableRoad[16, 0];
            else
                availableRoad[16, 0] = availableRoad[9, 3];
            if (availableRoad[16, 1] != 0)
                availableRoad[8, 4] = availableRoad[16, 1];
            else
                availableRoad[16, 1] = availableRoad[8, 4];
            if (availableRoad[16, 5] != 0)
                availableRoad[17, 2] = availableRoad[16, 5];
            else
                availableRoad[16, 5] = availableRoad[17, 2];
            if (availableRoad[17, 0] != 0)
                availableRoad[10, 3] = availableRoad[17, 0];
            else
                availableRoad[17, 0] = availableRoad[10, 3];
            if (availableRoad[17, 1] != 0)
                availableRoad[9, 4] = availableRoad[17, 1];
            else
                availableRoad[17, 1] = availableRoad[9, 4];
            if (availableRoad[17, 5] != 0)
                availableRoad[11, 2] = availableRoad[17, 5];
            else
                availableRoad[17, 5] = availableRoad[11, 2];
            if (availableRoad[18, 0] != 0)
                availableRoad[17, 3] = availableRoad[18, 0];
            else
                availableRoad[18, 0] = availableRoad[17, 3];
            if (availableRoad[18, 1] != 0)
                availableRoad[16, 4] = availableRoad[18, 1];
            else
                availableRoad[18, 1] = availableRoad[16, 4];
            if (availableRoad[18, 5] != 0)
                availableRoad[12, 2] = availableRoad[18, 5];
            else
                availableRoad[18, 5] = availableRoad[12, 2]; 
           
        }

        /// <summary>
        /// ya ya, judge me. I hammered this because I don't have another 3 days
        /// to figure out an alogrithm for this like the Distance rule does.
        /// 
        /// Updates so the vertices of each tile have the same value if they connect to each other
        /// </summary>
        /// <param name="Map"></param>
        static void UpdateVertices(Map Map)
        {
            Map.MapTile[11].Vertice[5] = Map.MapTile[0].Vertice[1];
            Map.MapTile[11].Vertice[4] = Map.MapTile[0].Vertice[2];
            Map.MapTile[12].Vertice[0] = Map.MapTile[0].Vertice[2];
            Map.MapTile[12].Vertice[5] = Map.MapTile[0].Vertice[3];
            Map.MapTile[1].Vertice[1] = Map.MapTile[0].Vertice[3];
            Map.MapTile[1].Vertice[0] = Map.MapTile[0].Vertice[4];
            Map.MapTile[12].Vertice[4] = Map.MapTile[1].Vertice[2];
            Map.MapTile[13].Vertice[0] = Map.MapTile[1].Vertice[2];
            Map.MapTile[13].Vertice[5] = Map.MapTile[1].Vertice[3];
            Map.MapTile[2].Vertice[1] = Map.MapTile[1].Vertice[3];
            Map.MapTile[2].Vertice[0] = Map.MapTile[1].Vertice[4];
            Map.MapTile[13].Vertice[4] = Map.MapTile[2].Vertice[2];
            Map.MapTile[3].Vertice[0] = Map.MapTile[2].Vertice[2];
            Map.MapTile[3].Vertice[5] = Map.MapTile[2].Vertice[3];
            Map.MapTile[13].Vertice[3] = Map.MapTile[3].Vertice[1];
            Map.MapTile[14].Vertice[5] = Map.MapTile[3].Vertice[1];
            Map.MapTile[14].Vertice[4] = Map.MapTile[3].Vertice[2];
            Map.MapTile[4].Vertice[0] = Map.MapTile[3].Vertice[2];
            Map.MapTile[4].Vertice[5] = Map.MapTile[3].Vertice[3];
            Map.MapTile[14].Vertice[3] = Map.MapTile[4].Vertice[1];
            Map.MapTile[5].Vertice[5] = Map.MapTile[4].Vertice[1];
            Map.MapTile[5].Vertice[4] = Map.MapTile[4].Vertice[2];
            Map.MapTile[14].Vertice[2] = Map.MapTile[5].Vertice[0];
            Map.MapTile[15].Vertice[4] = Map.MapTile[5].Vertice[0];
            Map.MapTile[15].Vertice[3] = Map.MapTile[5].Vertice[1];
            Map.MapTile[6].Vertice[5] = Map.MapTile[5].Vertice[1];
            Map.MapTile[6].Vertice[4] = Map.MapTile[5].Vertice[2];
            Map.MapTile[15].Vertice[2] = Map.MapTile[6].Vertice[0];
            Map.MapTile[7].Vertice[4] = Map.MapTile[6].Vertice[0];
            Map.MapTile[7].Vertice[3] = Map.MapTile[6].Vertice[1];
            Map.MapTile[15].Vertice[1] = Map.MapTile[7].Vertice[5];
            Map.MapTile[16].Vertice[3] = Map.MapTile[7].Vertice[5];
            Map.MapTile[16].Vertice[2] = Map.MapTile[7].Vertice[0];
            Map.MapTile[8].Vertice[4] = Map.MapTile[7].Vertice[0];
            Map.MapTile[8].Vertice[3] = Map.MapTile[7].Vertice[1];
            Map.MapTile[16].Vertice[1] = Map.MapTile[8].Vertice[5];
            Map.MapTile[9].Vertice[3] = Map.MapTile[8].Vertice[5];
            Map.MapTile[9].Vertice[2] = Map.MapTile[8].Vertice[0];
            Map.MapTile[16].Vertice[0] = Map.MapTile[9].Vertice[4];
            Map.MapTile[17].Vertice[2] = Map.MapTile[9].Vertice[4];
            Map.MapTile[17].Vertice[1] = Map.MapTile[9].Vertice[5];
            Map.MapTile[10].Vertice[3] = Map.MapTile[9].Vertice[5];
            Map.MapTile[10].Vertice[2] = Map.MapTile[9].Vertice[0];
            Map.MapTile[17].Vertice[0] = Map.MapTile[10].Vertice[4];
            Map.MapTile[11].Vertice[2] = Map.MapTile[10].Vertice[4];
            Map.MapTile[11].Vertice[1] = Map.MapTile[10].Vertice[5];
            Map.MapTile[17].Vertice[5] = Map.MapTile[11].Vertice[3];
            Map.MapTile[12].Vertice[1] = Map.MapTile[11].Vertice[3];
            Map.MapTile[17].Vertice[4] = Map.MapTile[12].Vertice[2];
            Map.MapTile[18].Vertice[0] = Map.MapTile[12].Vertice[2];
            Map.MapTile[18].Vertice[5] = Map.MapTile[13].Vertice[1];
            Map.MapTile[12].Vertice[3] = Map.MapTile[13].Vertice[1];
            Map.MapTile[18].Vertice[4] = Map.MapTile[14].Vertice[0];
            Map.MapTile[13].Vertice[2] = Map.MapTile[14].Vertice[0];
            Map.MapTile[18].Vertice[3] = Map.MapTile[15].Vertice[5];
            Map.MapTile[14].Vertice[1] = Map.MapTile[15].Vertice[5];
            Map.MapTile[18].Vertice[2] = Map.MapTile[16].Vertice[4];
            Map.MapTile[15].Vertice[0] = Map.MapTile[16].Vertice[4];
            Map.MapTile[18].Vertice[1] = Map.MapTile[17].Vertice[3];
            Map.MapTile[16].Vertice[5] = Map.MapTile[17].Vertice[3];
        }
        static void UpdateEdges(Map Map)
        {
            Map.MapTile[11].Edge[4] = Map.MapTile[0].Edge[1];
            Map.MapTile[0].Edge[3] = Map.MapTile[1].Edge[0];
            Map.MapTile[12].Edge[4] = Map.MapTile[1].Edge[1];
            Map.MapTile[1].Edge[3] = Map.MapTile[2].Edge[0];
            Map.MapTile[3].Edge[4] = Map.MapTile[2].Edge[1];
            Map.MapTile[13].Edge[3] = Map.MapTile[3].Edge[0];
            Map.MapTile[14].Edge[4] = Map.MapTile[3].Edge[1];
            Map.MapTile[2].Edge[2] = Map.MapTile[3].Edge[5];
            Map.MapTile[14].Edge[3] = Map.MapTile[4].Edge[0];
            Map.MapTile[5].Edge[4] = Map.MapTile[4].Edge[1];
            Map.MapTile[3].Edge[2] = Map.MapTile[4].Edge[5];
            Map.MapTile[15].Edge[3] = Map.MapTile[5].Edge[0];
            Map.MapTile[6].Edge[4] = Map.MapTile[5].Edge[1];
            Map.MapTile[14].Edge[2] = Map.MapTile[5].Edge[5];
            Map.MapTile[7].Edge[3] = Map.MapTile[6].Edge[0];
            Map.MapTile[15].Edge[2] = Map.MapTile[6].Edge[5];
            Map.MapTile[8].Edge[3] = Map.MapTile[7].Edge[0];
            Map.MapTile[16].Edge[2] = Map.MapTile[7].Edge[5];
            Map.MapTile[9].Edge[2] = Map.MapTile[8].Edge[5];
            Map.MapTile[10].Edge[2] = Map.MapTile[9].Edge[5];
            Map.MapTile[10].Edge[4] = Map.MapTile[11].Edge[1];
            Map.MapTile[11].Edge[3] = Map.MapTile[12].Edge[0];
            Map.MapTile[17].Edge[4] = Map.MapTile[12].Edge[1];
            Map.MapTile[0].Edge[2] = Map.MapTile[12].Edge[5];
            Map.MapTile[12].Edge[3] = Map.MapTile[13].Edge[0];
            Map.MapTile[18].Edge[4] = Map.MapTile[13].Edge[1];
            Map.MapTile[1].Edge[2] = Map.MapTile[13].Edge[5];
            Map.MapTile[18].Edge[3] = Map.MapTile[14].Edge[0];
            Map.MapTile[15].Edge[4] = Map.MapTile[14].Edge[1];
            Map.MapTile[13].Edge[2] = Map.MapTile[14].Edge[5];
            Map.MapTile[16].Edge[3] = Map.MapTile[15].Edge[0];
            Map.MapTile[7].Edge[4] = Map.MapTile[15].Edge[1];
            Map.MapTile[18].Edge[2] = Map.MapTile[15].Edge[5];
            Map.MapTile[9].Edge[3] = Map.MapTile[16].Edge[0];
            Map.MapTile[8].Edge[4] = Map.MapTile[16].Edge[1];
            Map.MapTile[17].Edge[2] = Map.MapTile[16].Edge[5];
            Map.MapTile[10].Edge[3] = Map.MapTile[17].Edge[0];
            Map.MapTile[9].Edge[4] = Map.MapTile[17].Edge[1];
            Map.MapTile[11].Edge[2] = Map.MapTile[17].Edge[5];
            Map.MapTile[17].Edge[3] = Map.MapTile[18].Edge[0];
            Map.MapTile[16].Edge[4] = Map.MapTile[18].Edge[1];
            Map.MapTile[12].Edge[2] = Map.MapTile[18].Edge[5];
        }
    }
}
