using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katan_project
{
    public abstract class BTile
    {
        string TypeName;
        int DiceValue;
        int[] Edge = new int[6];
        int[] Vertice = new int[6];
        Port PortOwned = null;
        bool BanditFlag;
        bool HasPort;

        public BTile(string typeName,int diceValue, int []edge,int []vertice,bool banditFlag, bool hasPort)
        {
            TypeName = typeName;
            DiceValue = diceValue;
            Edge = edge;
            Vertice = vertice;
            BanditFlag = banditFlag;
            HasPort = hasPort;
        }
        public void TileAssignValue(int newValue)
        {
            if(0<newValue && newValue<=12)
            {
                DiceValue = newValue;
            }
            else
            {
                Console.WriteLine("invalid dice value. Please assign a valid number between 1-12");
            }
        }
        public string GetName()
        {
            return TypeName;
        }
        public void SetBF()
        {
            BanditFlag = !BanditFlag;
        }
        public bool GetBF()
        {
            return BanditFlag;
        }
        public void SetPort(Port a)
        {
            if (this.HasPort == true)
            {
                PortOwned = a;
            }
        }
        public bool CheckEmptyPort()
        {
            if (PortOwned == null)
                return true;
            else
                return false;
        }
        public string GetPortType()
        {
            return PortOwned.TradeType;
        }
    }
}
