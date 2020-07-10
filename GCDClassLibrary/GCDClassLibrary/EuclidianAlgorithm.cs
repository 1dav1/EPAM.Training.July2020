using System;
using System.Collections.Generic;
using System.Text;

namespace GCDClassLibrary
{
    public class EuclidianAlgorithm
    {
        public int CalculateGCD(int number1, int number2)
        {
            if (number2 == 0)
                return number1;
            return CalculateGCD(number2, number1 % number2);
        }
    }
}
