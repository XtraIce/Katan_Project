using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katan_project
{
    public class TMountain: BTile
    {
        BResource Ore = new BResource("Ore", 1);
        public TMountain(string typeName):base(typeName)
        {

        }
    }
}
