using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katan_project
{
    class Map
    {
        /// <summary>
        /// Each map consists of:
        /// 3 Mountain  tiles
        /// 3 Hill      tiles
        /// 4 Field     tiles
        /// 4 Pasture   tiles
        /// 4 Forest    tiles
        /// 1 Desert    tiles
        /// </summary>
        BTile[] MapLayout = new BTile[18];
        TMountain[] Mountain = new TMountain[2];
        TField[] Field = new TField[3];
        THill[] Hill = new THill[2];
        TPasture[] Pasture = new TPasture[3];
        TForest[] Forest = new TForest[3];
        TDesert Desert;
        public Map()
        {
           
        }
        /// <summary>
        /// Generates the layout of the map in the standard format
        /// Follows the max criteria of eah tile type
        /// </summary>
        public void SetGenerate()
        {
            MapLayout[0]  = Mountain[0];
            MapLayout[1]  = Field[0];
            MapLayout[2]  = Field[1];
            MapLayout[3]  = Forest[0];
            MapLayout[4]  = Hill[0];
            MapLayout[5]  = Field[2];
            MapLayout[6]  = Pasture[0];
            MapLayout[7]  = Pasture[1];
            MapLayout[8]  = Mountain[1];
            MapLayout[9]  = Hill[1];
            MapLayout[10] = Forest[1];
            MapLayout[11] = Pasture[2];
            MapLayout[12] = Hill[2];
            MapLayout[13] = Forest[2];
            MapLayout[14] = Mountain[2];
            MapLayout[15] = Field[3];
            MapLayout[16] = Forest[3];
            MapLayout[17] = Pasture[3];
            MapLayout[18] = Desert;

        }
        /// <summary>
        /// Generate the layout of the map in a randomly generated format
        /// Checks that the the amount of tiles generated does not exceed the max set amount
        /// per tile type
        /// </summary>
        public void RandGenerate()
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
                            MapLayout[i] = Field[numField];
                            numField++;
                            break;
                        }
                        else
                            continue;
                    }
                    else if (numDecide == 1)
                        if (numForest <= 3)
                        {
                            MapLayout[i] = Forest[numForest];
                            numForest++;
                            break;
                        }
                        else
                            continue;
                    else if (numDecide == 2)
                        if (numHill <= 2)
                        {
                            MapLayout[i] = Forest[numHill];
                            numHill++;
                            break;
                        }
                        else
                            continue;
                    else if (numDecide == 3)
                        if (numMountain <= 2)
                        {
                            MapLayout[i] = Forest[numMountain];
                            numMountain++;
                            break;
                        }
                        else
                            continue;
                    else if (numDecide == 4)
                        if (numPasture <= 3)
                        {
                            MapLayout[i] = Forest[numPasture];
                            numPasture++;
                            break;
                        }
                        else
                            continue;
                    else
                        if (numDesert < 1)
                        {
                            MapLayout[i] = Forest[numDesert];
                            numDesert++;
                            break;
                        }
                        else
                            continue;
                }
            }
        }
        /// <summary>
        /// assign dice values to each tile on the map using public method of BTile to access private member dice_value
        /// </summary>
        public void AssignNumber()
        {
            MapLayout[0].TileAssignValue(10);
            MapLayout[1].TileAssignValue(12);
            MapLayout[2].TileAssignValue(9);
            MapLayout[3].TileAssignValue(8);
            MapLayout[4].TileAssignValue(5);
            MapLayout[5].TileAssignValue(6);
            MapLayout[6].TileAssignValue(11);
            MapLayout[7].TileAssignValue(5);
            MapLayout[8].TileAssignValue(8);
            MapLayout[9].TileAssignValue(10);
            MapLayout[10].TileAssignValue(9);
            MapLayout[11].TileAssignValue(2);
            MapLayout[12].TileAssignValue(6);
            MapLayout[13].TileAssignValue(11);
            MapLayout[14].TileAssignValue(3);
            MapLayout[15].TileAssignValue(4);
            MapLayout[16].TileAssignValue(3);
            MapLayout[17].TileAssignValue(4);
        }
    }
}
