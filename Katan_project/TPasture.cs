using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
