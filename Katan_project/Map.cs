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
        public BTile[] MapTile = new BTile[19];

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
        public Map(bool randomizeCheck)
        {
            if (randomizeCheck)
            { RandGenerate(); }
            else
            { SetGenerate(); }
            AssignNumber();
            SetBandit();
            GeneratePorts();
        }
        /// <summary>
        /// Generates the layout of the map in the standard format
        /// Follows the max criteria of eah tile type
        /// </summary>
        void SetGenerate()
        {
            MapTile[0] = new TMountain("Mountain");
            MapTile[1] = new TField("Field");
            MapTile[2] = new TField("Field");
            MapTile[3] = new TForest("Forest");
            MapTile[4] = new THill("Hill");
            MapTile[5] = new TField("Field");
            MapTile[6] = new TPasture("Pasture");
            MapTile[7] = new TPasture("Pasture");
            MapTile[8] = new TMountain("Mountain");
            MapTile[9] = new THill("Hill");
            MapTile[10] = new TForest("Forest");
            MapTile[11] = new TPasture("Pasture");
            MapTile[12] = new THill("Hill");
            MapTile[13] = new TForest("Forest");
            MapTile[14] = new TMountain("Mountain");
            MapTile[15] = new TField("Field");
            MapTile[16] = new TForest("Forest");
            MapTile[17] = new TPasture("Pasture");
            MapTile[18] = new TDesert("Desert");

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

            for (int i=0;i<=18;i++)
            {
                while (true)
                {
                    int numDecide = rnd.Next(0, 6);
                    if (numField == 4 && numForest == 4 && numHill == 3 && numMountain == 3 && numPasture == 4 && numDesert==1)
                    {
                        break;
                    }
                    else if (numDecide == 0)
                    {
                        if (numField <= 3)
                        {
                            MapTile[i] = new TField("Field");
                            numField++;
                            break;
                        }
                        else
                            continue;
                    }
                    else if (numDecide == 1)
                        if (numForest <= 3)
                        {
                            MapTile[i] = new TForest("Forest");
                            numForest++;
                            break;
                        }
                        else
                            continue;
                    else if (numDecide == 2)
                        if (numHill <= 2)
                        {
                            MapTile[i] = new THill("Hill");
                            numHill++;
                            break;
                        }
                        else
                            continue;
                    else if (numDecide == 3)
                        if (numMountain <= 2)
                        {
                            MapTile[i] = new TMountain("Mountain");
                            numMountain++;
                            break;
                        }
                        else
                            continue;
                    else if (numDecide == 4)
                        if (numPasture <= 3)
                        {
                            MapTile[i] = new TPasture("Pasture");
                            numPasture++;
                            break;
                        }
                        else
                            continue;
                    else if (numDecide == 5)
                        if (numDesert == 0)
                        {
                            MapTile[i] = new TDesert("Desert");
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
            int[] array = new int[19] { 10,12,9,8,5,6,11,5,8,10,9,2,6,11,3,4,3,4,0};
            int j = 0;
            int i = 0;
            while(array[j]!=0)
            { 
                if (MapTile[i] is TDesert)
                {
                    MapTile[i].TileAssignValue(0);
                    i++;
                }
                else
                {
                    MapTile[i].TileAssignValue(array[j]);
                    j++;
                    i++;
                }
            }
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
                if (MapTile[i]is TDesert)
                {
                    MapTile[i].SetBF();
                }
            }
        }
    }
}
