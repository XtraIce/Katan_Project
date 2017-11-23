using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katan_project
{
    public class Port
    {
        int TradeRate;
        string TradeType;
        
        public Port(int tradeR,string tradeT)
        {
            TradeRate = tradeR;
            TradeType = tradeT;
        }
    }
}
