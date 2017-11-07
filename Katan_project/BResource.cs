using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katan_project
{
    public abstract class BResource
    {
        public int Value { get; }
        public int Name { get; set; }

        public BResource(int value) => Value = value;
    }
}
