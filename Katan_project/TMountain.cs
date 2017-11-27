using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katan_project
{
    public class TMountain: BTile
    {
        BResource Ore;
        public TMountain(string typeName,int diceValue, int[] edge, int[] vertice, bool banditFlag, bool port):base(typeName,diceValue,edge,vertice,banditFlag,port)
        {
            typeName = "Mountain";
            Ore.Value = 1;
            Ore.Type = "Ore";
        }
    }
}
