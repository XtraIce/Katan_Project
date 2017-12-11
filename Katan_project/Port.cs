using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// RIKER QUINTANA
/// 816823248
/// </summary>
namespace Katan_project
{
    public class Port
    {
        int TradeRate;
        string tradeType;
        public string TradeType
        {
            get
            {
                return tradeType;
            }
            set
            {
                if (value is string)
                    tradeType = value;
                else
                    Console.WriteLine("Invalid Name. Try Again");
            }
        }
        public Port(int tradeR,string tradeT)
        {
            TradeRate = tradeR;
            TradeType = tradeT;
        }
    }
}
