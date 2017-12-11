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
    public class TForest: BTile
    {
        BResource Wood = new BResource("Wood", 1);
        public TForest(string typeName) :base(typeName)
        {

        }
    }
}
