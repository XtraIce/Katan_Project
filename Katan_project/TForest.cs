using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katan_project
{
    public class TForest: BTile
    {
        BResource Wood;
        public TForest(string typeName,int diceValue, int[] edge, int[] vertice, bool banditFlag, bool port) :base(typeName,diceValue,edge,vertice,banditFlag, port)
        {
            typeName = "Forest";
            Wood.Value = 1;
            Wood.Name = "Wood";
        }
    }
}
