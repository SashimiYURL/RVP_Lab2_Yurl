using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP_Lab2_Yurl
{
    internal class Parabola:IFunction
    {
        float IFunction.Calc(float x)
        {
            return (x * x);
        }
    }
}
