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
        public string Name {
            get
            {
                return name;
            }
            set
            {
                if (value is string)
                    name = value;
                else
                    Console.WriteLine("Invalid Name. Try Again");
            }
        }
        public BResource(string inputName,int inputValue)
        {
            Name = inputName;
            resValue = inputValue;
        }
    }
}
