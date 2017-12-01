using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katan_project
{
    public class GameMaster: Map
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
        public void GenerateResource(Player P1,Player P2,Player P3,Player P4)
        {
            for(int i = 0; i <= 18; i++)
            {
                for(int j = 0;j<=5;j++)
                {
                    if(MapTile[i].Vertice[j]==1)
                    {
                        if(MapTile[i] is TPasture)
                            P1.SheepHeld.Value += 1;
                        if(MapTile[i] is THill)
                            P1.BrickHeld.Value += 1;
                        if (MapTile[i] is TMountain)
                            P1.OreHeld.Value += 1;
                        if (MapTile[i] is TForest)
                            P1.WoodHeld.Value += 1;
                        if (MapTile[i] is TField)
                            P1.GrainHeld.Value += 1;
                    }
                    else if (MapTile[i].Vertice[j] == 11)
                    {
                        if (MapTile[i] is TPasture)
                            P1.SheepHeld.Value += 2;
                        if (MapTile[i] is THill)
                            P1.BrickHeld.Value += 2;
                        if (MapTile[i] is TMountain)
                            P1.OreHeld.Value += 2;
                        if (MapTile[i] is TForest)
                            P1.WoodHeld.Value += 2;
                        if (MapTile[i] is TField)
                            P1.GrainHeld.Value += 2;
                    }
                    if (MapTile[i].Vertice[j] == 2)
                    {
                        if (MapTile[i] is TPasture)
                            P2.SheepHeld.Value += 1;
                        if (MapTile[i] is THill)
                            P2.BrickHeld.Value += 1;
                        if (MapTile[i] is TMountain)
                            P2.OreHeld.Value += 1;
                        if (MapTile[i] is TForest)
                            P2.WoodHeld.Value += 1;
                        if (MapTile[i] is TField)
                            P2.GrainHeld.Value += 1;
                    }
                    else if (MapTile[i].Vertice[j] == 22)
                    {
                        if (MapTile[i] is TPasture)
                            P2.SheepHeld.Value += 2;
                        if (MapTile[i] is THill)
                            P2.BrickHeld.Value += 2;
                        if (MapTile[i] is TMountain)
                            P2.OreHeld.Value += 2;
                        if (MapTile[i] is TForest)
                            P2.WoodHeld.Value += 2;
                        if (MapTile[i] is TField)
                            P2.GrainHeld.Value += 2;
                    }
                    if (MapTile[i].Vertice[j] == 3)
                    {
                        if (MapTile[i] is TPasture)
                            P3.SheepHeld.Value += 1;
                        if (MapTile[i] is THill)
                            P3.BrickHeld.Value += 1;
                        if (MapTile[i] is TMountain)
                            P3.OreHeld.Value += 1;
                        if (MapTile[i] is TForest)
                            P3.WoodHeld.Value += 1;
                        if (MapTile[i] is TField)
                            P3.GrainHeld.Value += 1;
                    }
                    else if (MapTile[i].Vertice[j] == 33)
                    {
                        if (MapTile[i] is TPasture)
                            P3.SheepHeld.Value += 2;
                        if (MapTile[i] is THill)
                            P3.BrickHeld.Value += 2;
                        if (MapTile[i] is TMountain)
                            P3.OreHeld.Value += 2;
                        if (MapTile[i] is TForest)
                            P3.WoodHeld.Value += 2;
                        if (MapTile[i] is TField)
                            P3.GrainHeld.Value += 2;
                    }
                    if (MapTile[i].Vertice[j] == 4)
                    {
                        if (MapTile[i] is TPasture)
                            P4.SheepHeld.Value += 1;
                        if (MapTile[i] is THill)
                            P4.BrickHeld.Value += 1;
                        if (MapTile[i] is TMountain)
                            P4.OreHeld.Value += 1;
                        if (MapTile[i] is TForest)
                            P4.WoodHeld.Value += 1;
                        if (MapTile[i] is TField)
                            P4.GrainHeld.Value += 1;
                    }
                    else if (MapTile[i].Vertice[j] == 44)
                    {
                        if (MapTile[i] is TPasture)
                            P4.SheepHeld.Value += 2;
                        if (MapTile[i] is THill)
                            P4.BrickHeld.Value += 2;
                        if (MapTile[i] is TMountain)
                            P4.OreHeld.Value += 2;
                        if (MapTile[i] is TForest)
                            P4.WoodHeld.Value += 2;
                        if (MapTile[i] is TField)
                            P4.GrainHeld.Value += 2;
                    }
                }
            }
        }
        public void PlaceSettlement(Player currentPlayer,int selTile,int selVer)
        {
            if (currentPlayer.WoodHeld.Value >= 1 && currentPlayer.GrainHeld.Value >= 1 &&
               currentPlayer.BrickHeld.Value >= 1 && currentPlayer.SheepHeld.Value >= 1)
            {
                if (MapTile[selTile].Vertice[selVer] == 0)
                {
                    if(selTile == 0)
                    {
                        if (selVer == 0 && MapTile[selTile].Vertice[1] == 0
                            && MapTile[selTile].Vertice[5] == 0)
                        {

                        }
                    }

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
        public void PlaceRoad(int i, int j, Player currentPlayer)
        {
            if(currentPlayer.WoodHeld.Value>=1 && currentPlayer.BrickHeld.Value >= 1)
            {
                MapTile[i].Edge[j] = currentPlayer.PlayerNumber;
            }
        }
        public void BasicTrade()
        {

        }
        public void PortTrade()
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
        bool DistanceRule(int selTile,int selVer)
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
            if (selTile%2==0 && selTile<=10)
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
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0)
                            return true;
                        break;
                    case 1:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[11].Vertice[m] == 0)
                            return true;
                        break;
                    case 2:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[12].Vertice[n] == 0)
                            return true;
                        break;
                    case 3:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[1].Vertice[n] == 0)
                            return true;
                        break;
                    case 4:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[1].Vertice[m] == 0)
                            return true;
                        break;
                    case 5:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0)
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
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[selTile-1].Vertice[m] == 0)
                            return true;
                        break;
                    case 1:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[selTile+j].Vertice[m] == 0)
                            return true;
                        break;
                    case 2:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[selTile+j+1].Vertice[n] == 0)
                            return true;
                        break;
                    case 3:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[selTile+1].Vertice[m] == 0)
                            return true;
                        break;
                    case 4:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[selTile+1].Vertice[n] == 0)
                            return true;
                        break;
                    case 5:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0)
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
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0)
                            return true;
                        break;
                    case 1:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[10].Vertice[m] == 0)
                            return true;
                        break;
                    case 2:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[17].Vertice[n] == 0)
                            return true;
                        break;
                    case 3:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[12].Vertice[n] == 0)
                            return true;
                        break;
                    case 4:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[0].Vertice[m] == 0)
                            return true;
                        break;
                    case 5:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[0].Vertice[n]==0)
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
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[0].Vertice[n] == 0)
                            return true;
                        break;
                    case 1:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[11].Vertice[m] == 0)
                            return true;
                        break;
                    case 2:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[17].Vertice[n] == 0)
                            return true;
                        break;
                    case 3:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[18].Vertice[n] == 0)
                            return true;
                        break;
                    case 4:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[13].Vertice[m] == 0)
                            return true;
                        break;
                    case 5:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[1].Vertice[n] == 0)
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
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[selTile - k].Vertice[n] == 0)
                            return true;
                        break;
                    case 1:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[selTile - 1].Vertice[m] == 0)
                            return true;
                        break;
                    case 2:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[selTile + o].Vertice[n] == 0)
                            return true;
                        break;
                    case 3:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[selTile + 1].Vertice[n] == 0)
                            return true;
                        break;
                    case 4:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[selTile - k + 2].Vertice[m] == 0)
                            return true;
                        break;
                    case 5:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[selTile - k + 1].Vertice[n] == 0)
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
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[11].Vertice[n] == 0)
                            return true;
                        break;
                    case 1:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[10].Vertice[m] == 0)
                            return true;
                        break;
                    case 2:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[9].Vertice[n] == 0)
                            return true;
                        break;
                    case 3:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[16].Vertice[n] == 0)
                            return true;
                        break;
                    case 4:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[18].Vertice[m] == 0)
                            return true;
                        break;
                    case 5:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[12].Vertice[n] == 0)
                            return true;
                        break;
                    default: return false;
                }
            }
            Console.WriteLine("Not a valid path on CatanMap");
            return false;
        }

    }
}
