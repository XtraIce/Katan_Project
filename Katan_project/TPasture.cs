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
    public class TPasture: BTile
    {
        BResource Sheep = new BResource("Sheep", 1);
        public TPasture(string typeName):base(typeName)
        {

        }
    }
}
