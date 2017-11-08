using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katan_project
{
    public class THill:BTile
    {
        BResource Brick = new BResource("Brick", 1);
        public THill(int diceValue, int[] edge, bool banditFlag):base(diceValue,edge,banditFlag)
        {

        }
    }
}
