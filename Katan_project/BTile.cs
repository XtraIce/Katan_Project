using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katan_project
{
    public abstract class BTile
    {
        int dice_Value;
        int[] edge_ = new int[5];
        bool bandit_Flag;

        public BTile(int diceValue, int []edge,bool banditFlag)
        {
            dice_Value = diceValue;
            edge_ = edge;
            bandit_Flag = banditFlag;
        }
    }
}
