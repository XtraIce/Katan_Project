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
    class TField : BTile
    {
        BResource Grain = new BResource("Grain", 1);
        public TField(string typeName) :base(typeName)
        {

        }
    }
}
