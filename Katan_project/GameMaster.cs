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

        bool DistanceRule(int selTile,int selVer)
        {
 
            int k = 0;
            switch (selTile)
            {
                case 1: k = 1; break;
                case 3: k = 2; selVer += 5; break;
                case 5: k = 3; selVer += 4; break;
                case 7: k = 4; selVer += 3; break;
                case 9: k = 5; selVer += 2; break;
                case 11: k = 6;selVer += 1; break;
            }
            switch (selVer)
            {
                case 6: selVer = 0; break;
                case 7: selVer = 1; break;
                case 8: selVer = 2; break;
                case 9: selVer = 3; break;
                case 10: selVer = 4;break;
            }
            int m = selVer - 1;
            if (m == -1)
                m = 5;
            int n = selVer + 1;
            if (n == 6)
                n = 0;
            int j = 12 - selTile + k;
            if(selTile == 0)
            {

            }
            if (selTile == 1 || selTile == 3 || selTile == 5 || selTile == 7 || selTile == 9 || selTile == 11)//11 should be excluded
            {
                switch (selVer)
                {
                    case 0:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[selTile-1].Vertice[m] == 0)
                            return true;
                        break;
                    case 1:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[selTile-j].Vertice[m] == 0)
                            return true;
                        break;
                    case 2:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[selTile-j+1].Vertice[n] == 0)
                            return true;
                        break;
                    case 3:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[selTile+1].Vertice[n] == 0)
                            return true;
                        break;
                    case 4:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0 && MapTile[selTile+1].Vertice[m] == 0)
                            return true;
                        break;
                    case 5:
                        if (MapTile[selTile].Vertice[m] == 0 && MapTile[selTile].Vertice[n] == 0)
                            return true;
                        break;
                }


            }
            
        }

    }
}
