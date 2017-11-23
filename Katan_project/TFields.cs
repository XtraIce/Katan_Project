using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katan_project
{
    class TField : BTile
    {
        BResource Grain;
        public TField(string typeName, int diceValue,int []edge, int[] vertice, bool banditFlag, bool port) :base(typeName, diceValue,edge,vertice,banditFlag, port)
        {
            typeName = "Field";
            Grain.Value = 1;
            Grain.Name = "Grain";
        }
    }
}
