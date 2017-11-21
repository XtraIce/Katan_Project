using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katan_project
{
    public class BResource
    {
        int resValue;
        public int Value {
            get
            {
                return resValue;
            }
            set {
                if (value > 0)
                    resValue = value; 
                }
        }
        string name;
        public string Name { get; set; }

        public BResource(string inputName,int inputValue)
        {
            Name = inputName;
            resValue = inputValue;
        }

        public int 
    }
}
