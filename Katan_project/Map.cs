using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katan_project
{
    public class Map
    {
        /// <summary>
        /// Each map consists of:
        /// 3 Mountain  tiles
        /// 3 Hill      tiles
        /// 4 Field     tiles
        /// 4 Pasture   tiles
        /// 4 Forest    tiles
        /// 1 Desert    tiles
        /// 
        /// 4 anytype   ports
        /// 1 sheep     port
        /// 1 wood      port
        /// 1 brick     port
        /// 1 ore       port
        /// 1 grain     port
        /// </summary>
        BTile[] MapTile = new BTile[18];
        TMountain[] Mountain = new TMountain[3];
        TField[] Field = new TField[4];
        THill[] Hill = new THill[3];
        TPasture[] Pasture = new TPasture[4];
        TForest[] Forest = new TForest[4];
        TDesert [] Desert = new TDesert[1] ;

        Port[] MapPort = new Port[]
        {
            new Port(2,"sheep"),
            new Port(2,"wood"),
            new Port(2,"brick"),
            new Port(2,"ore"),
            new Port(2,"grain"),
            new Port(3, "any"),
            new Port(3, "any"),
            new Port(3, "any"),
            new Port(3, "any")
        };
        public Map()
        {
            SetGenerate();
            AssignNumber();
            SetBandit();
        }
        /// <summary>
        /// Generates the layout of the map in the standard format
        /// Follows the max criteria of eah tile type
        /// </summary>
        void SetGenerate()
        {
            MapTile[0]  = Mountain[0];
            MapTile[1]  = Field[0];
            MapTile[2]  = Field[1];
            MapTile[3]  = Forest[0];
            MapTile[4]  = Hill[0];
            MapTile[5]  = Field[2];
            MapTile[6]  = Pasture[0];
            MapTile[7]  = Pasture[1];
            MapTile[8]  = Mountain[1];
            MapTile[9]  = Hill[1];
            MapTile[10] = Forest[1];
            MapTile[11] = Pasture[2];
            MapTile[12] = Hill[2];
            MapTile[13] = Forest[2];
            MapTile[14] = Mountain[2];
            MapTile[15] = Field[3];
            MapTile[16] = Forest[3];
            MapTile[17] = Pasture[3];
            MapTile[18] = Desert[0];

        }
        /// <summary>
        /// Generate the layout of the map in a randomly generated format
        /// Checks that the the amount of tiles generated does not exceed the max set amount
        /// per tile type
        /// </summary>
        void RandGenerate()
        {
            Random rnd = new Random();
            int numField=0;
            int numForest=0;
            int numHill=0;
            int numMountain=0;
            int numPasture=0;
            int numDesert=0;

            for(int i=0;i<=18;i++)
            {
                while (true)
                {
                    int numDecide = rnd.Next(0, 5);
                    if (numDecide == 0)
                    {
                        if (numField <= 3)
                        {
                            MapTile[i] = Field[numField];
                            numField++;
                            break;
                        }
                        else
                            continue;
                    }
                    else if (numDecide == 1)
                        if (numForest <= 3)
                        {
                            MapTile[i] = Forest[numForest];
                            numForest++;
                            break;
                        }
                        else
                            continue;
                    else if (numDecide == 2)
                        if (numHill <= 2)
                        {
                            MapTile[i] = Forest[numHill];
                            numHill++;
                            break;
                        }
                        else
                            continue;
                    else if (numDecide == 3)
                        if (numMountain <= 2)
                        {
                            MapTile[i] = Forest[numMountain];
                            numMountain++;
                            break;
                        }
                        else
                            continue;
                    else if (numDecide == 4)
                        if (numPasture <= 3)
                        {
                            MapTile[i] = Forest[numPasture];
                            numPasture++;
                            break;
                        }
                        else
                            continue;
                    else
                        if (numDesert < 1)
                        {
                            MapTile[i] = Forest[numDesert];
                            numDesert++;
                            break;
                        }
                        else
                            continue;
                }
            }
        }
        /// <summary>
        /// assign dice values to each tile on the map using 
        /// public method of BTile to access private member dice_Value
        /// </summary>
        void AssignNumber()
        {
            MapTile[0].TileAssignValue(10);
            MapTile[1].TileAssignValue(12);
            MapTile[2].TileAssignValue(9);
            MapTile[3].TileAssignValue(8);
            MapTile[4].TileAssignValue(5);
            MapTile[5].TileAssignValue(6);
            MapTile[6].TileAssignValue(11);
            MapTile[7].TileAssignValue(5);
            MapTile[8].TileAssignValue(8);
            MapTile[9].TileAssignValue(10);
            MapTile[10].TileAssignValue(9);
            MapTile[11].TileAssignValue(2);
            MapTile[12].TileAssignValue(6);
            MapTile[13].TileAssignValue(11);
            MapTile[14].TileAssignValue(3);
            MapTile[15].TileAssignValue(4);
            MapTile[16].TileAssignValue(3);
            MapTile[17].TileAssignValue(4);
            MapTile[18].TileAssignValue(0);
        }
        /// <summary>
        /// generate ports on specified tiles
        void GeneratePorts()
        {
            Random rnd = new Random();
            bool[]PortPlaced = new bool[9];
            for(int i = 0; i <= 8; i++)
            {
                while (true)
                {
                    int select = rnd.Next(1, 9);

                    if (select == 1 && MapTile[0].CheckEmptyPort())
                    {
                        MapTile[0].SetPort(MapPort[i]);break;
                    }
                    else if (select == 2 && MapTile[1].CheckEmptyPort())
                    {
                        MapTile[1].SetPort(MapPort[i]);break;
                    }
                    else if (select == 3 && MapTile[3].CheckEmptyPort())
                    {
                        MapTile[3].SetPort(MapPort[i]);break;
                    }
                    else if (select == 4 && MapTile[4].CheckEmptyPort())
                    {
                        MapTile[4].SetPort(MapPort[i]);break;
                    }
                    else if (select == 5 && MapTile[5].CheckEmptyPort())
                    {
                        MapTile[5].SetPort(MapPort[i]);break;
                    }
                    else if (select == 6 && MapTile[7].CheckEmptyPort())
                    {
                        MapTile[7].SetPort(MapPort[i]);break;
                    }
                    else if (select == 7 && MapTile[8].CheckEmptyPort())
                    {
                        MapTile[8].SetPort(MapPort[i]);break;
                    }
                    else if (select == 8 && MapTile[9].CheckEmptyPort())
                    {
                        MapTile[9].SetPort(MapPort[i]);break;
                    }
                    else if (select == 9 && MapTile[11].CheckEmptyPort())
                    {
                        MapTile[11].SetPort(MapPort[i]);break;
                    }
                    else
                        continue;
                }
            }
        }
        void SetBandit()
        {
            for(int i = 0; i <= 18; i++)
            {
                if (MapTile[i].GetName()=="Desert")
                {
                    MapTile[i].SetBF();
                }
            }
        }
    }
}
