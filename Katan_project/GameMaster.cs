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
        public static void GenerateResource(Map Map,Player P1,Player P2,Player P3,Player P4)
        {
            for(int i = 0; i <= 18; i++)
            {
                for(int j = 0;j<=5;j++)
                {
                    if(Map.MapTile[i].Vertice[j]==1)
                    {
                        if(Map.MapTile[i] is TPasture)
                            P1.SheepHeld.Value += 1;
                        if(Map.MapTile[i] is THill)
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
        public static void BuildSettlement(Map Map,Player currentPlayer, int selTile, int selVer)
        {
            if (currentPlayer.WoodHeld.Value >= 1 && currentPlayer.GrainHeld.Value >= 1 &&
               currentPlayer.BrickHeld.Value >= 1 && currentPlayer.SheepHeld.Value >= 1)
            {
                if (Map.MapTile[selTile].Vertice[selVer] == 0)
                {
                    Map.MapTile[selTile].Vertice[selVer] = currentPlayer.PlayerNumber;
                    currentPlayer.OwnedSettlements += 1;
                }
                else
                {
                    Console.WriteLine("That spot has already been built upon.");
                }
            }
            else
            {
                Console.WriteLine("Insufficient resources.");
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
        public static void UpgradeToCity(Map Map,Player currentPlayer, int selTile, int selVer)
        {
            if(currentPlayer.GrainHeld.Value>=2&&currentPlayer.OreHeld.Value>=3)
            {
                currentPlayer.GrainHeld.Value -= 2;
                currentPlayer.OreHeld.Value -= 3;
                Map.MapTile[selTile].Vertice[selVer] = (currentPlayer.PlayerNumber + currentPlayer.PlayerNumber*10);
                currentPlayer.OwnedSettlements -= 1;
                currentPlayer.OwnedCities += 1;
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
        public static void PlaceRoad(Map Map,Player currentPlayer, int i, int j )
        {
            if (Map.MapTile[i].Edge[j]==0 && currentPlayer.WoodHeld.Value>=1 && currentPlayer.BrickHeld.Value >= 1)
            {
                Map.MapTile[i].Edge[j] = currentPlayer.PlayerNumber;
                currentPlayer.OwnedRoads += 1;
            }
        }
        public static void BasicTrade()
        {

        }
        public static void PortTrade()
        {

        }
        /// <summary>
        /// DistanceRule checks the vertice selected to see if neighboring vertices are occupied
        /// If occupied, returns false
        /// If unoccupied, returns true
        /// </summary>
        /// <param name="selTile"></param>
        /// <param name="selVer"></param>
        /// <returns></returns>
        public static bool DistanceRule(Map Map,int selTile,int selVer)
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
                case 14: k = 11; o = 4;  caseNum += 1;break;
                case 15: k = 10; o = 3;  caseNum += 2;break;
                case 16: k = 9;  o = 2;  caseNum += 3;break;
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
            if (selTile!=0 && selTile%2==0 && selTile<=10)
            {
                if (caseNum==4)
                    caseNum = 5;
                if (caseNum == 2 || caseNum==3)
                {
                    caseNum = 3;
                    m = n;
                }
            }
            //Tile 17 is unique in neighboring-tile relationships
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
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[1].Vertice[n] == 0)
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
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[selTile-1].Vertice[m] == 0)
                            return true;
                        break;
                    case 1:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[selTile+j].Vertice[m] == 0)
                            return true;
                        break;
                    case 2:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[selTile+j+1].Vertice[n] == 0)
                            return true;
                        break;
                    case 3:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[selTile+1].Vertice[m] == 0)
                            return true;
                        break;
                    case 4:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[selTile+1].Vertice[n] == 0)
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
            else if (selTile==11)
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
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[17].Vertice[n] == 0)
                            return true;
                        break;
                    case 3:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[12].Vertice[n] == 0)
                            return true;
                        break;
                    case 4:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[0].Vertice[m] == 0)
                            return true;
                        break;
                    case 5:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[0].Vertice[n]==0)
                            return true;
                        break;
                    default: return false;
                }
            }
            //Tile 11 is unique in neighboring-tile relationships
            else if (selTile==12)
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
            else if ( selTile == 13 || selTile == 14 || selTile == 15 || selTile == 16)//11 should be excluded
            {
                switch (caseNum)
                {
                    case 0:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[selTile - k].Vertice[n] == 0)
                            return true;
                        break;
                    case 1:
                        if (Map.MapTile[selTile].Vertice[m] == 0 && Map.MapTile[selTile].Vertice[n] == 0 && Map.MapTile[selTile - 1].Vertice[m] == 0)
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
            Map.MapTile[18].Vertice[5] = Map.MapTile[12].Vertice[3];
            Map.MapTile[13].Vertice[1] = Map.MapTile[12].Vertice[3];
            Map.MapTile[18].Vertice[4] = Map.MapTile[13].Vertice[2];
            Map.MapTile[14].Vertice[0] = Map.MapTile[13].Vertice[2];
            Map.MapTile[18].Vertice[3] = Map.MapTile[14].Vertice[1];
            Map.MapTile[15].Vertice[5] = Map.MapTile[14].Vertice[1];
            Map.MapTile[18].Vertice[2] = Map.MapTile[15].Vertice[0];
            Map.MapTile[16].Vertice[4] = Map.MapTile[15].Vertice[0];
            Map.MapTile[18].Vertice[1] = Map.MapTile[16].Vertice[5];
            Map.MapTile[17].Vertice[3] = Map.MapTile[16].Vertice[5];
        }
    }
}
