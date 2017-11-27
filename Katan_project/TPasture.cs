using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katan_project
{
    public class TPasture: BTile
    {
        BResource Sheep;
        public TPasture(string typeName,int diceValue, int[] edge, int[] vertice, bool banditFlag, bool port):base(typeName,diceValue,edge,vertice,banditFlag,port)
        {
            typeName = "Pasture";
            Sheep.Value = 1;
            Sheep.Type = "Sheep";
        }
    }
}
