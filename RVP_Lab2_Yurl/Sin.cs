using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP_Lab2_Yurl
{
    internal class Sin: IFunction
    {
       
        float IFunction.Calc(float x)
        {
            return (float) Math.Sin((double) x);
        }
    }
}
