using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katan_project
{
    public class TDesert:BTile
    {
        public TDesert(string typeName,int diceValue, int[] edge,int[] vertice, bool banditFlag,bool noPort):base(typeName,diceValue,edge,vertice,banditFlag,noPort)
        {
            typeName = "Desert";
        }
    }
}
