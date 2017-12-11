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
    public class BResource
    {
        int resValue;
        public int Value {
            get
            {
                return resValue;
            }
            set {
                if (value >= 0)
                    resValue = value; 
                }
        }
        string type;
        public string Type {
            get
            {
                return type;
            }
            set
            {
                if (value is string)
                    type = value;
                else
                    Console.WriteLine("Invalid Name. Try Again");
            }
        }
        public BResource(string inputName,int inputValue)
        {
            type = inputName;
            resValue = inputValue;
        }
    }
}
