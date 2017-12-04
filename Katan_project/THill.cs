using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katan_project
{
    public class THill:BTile
    {
        BResource Brick;
        public THill(string typeName,int diceValue, int[] edge, int[] vertice, bool banditFlag, bool port) :base(typeName,diceValue,edge,vertice,banditFlag,port)
        {
            typeName = "Hill";
            Brick.Value = 1;
            Brick.Type = "Brick";
        }
    }
}
