using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP_Lab2_Yurl
{
    internal class Tg:IFunction
    {
        public float x { get; set; }
        public float Calc(float x)
        {
            return (float)Math.Tan((double)x);
        }
    }
}
