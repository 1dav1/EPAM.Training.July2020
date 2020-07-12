using System;
using System.Collections.Generic;
using System.IO;

namespace GCDClassLibrary
{
    public class GCDCalculator
    {
        private double GCDTime { get; set; }

        private double BinaryGCDTime { get; set; }

        // multiplier to convert milliseconds to more readable format
        private const int MULTIPLIER = 1000;

        public uint CalculateGCD(uint number1, uint number2)
        {
            if (number1 == number2)
            {
                return number1;
            }
            else
            {
                if (number2 == 0)
                {
                    return number1;
                }

                // calling calculation method recursively to calculate the Gratest Common Devisor
                return CalculateGCD(number2, number1 % number2);
            }
        }

        public uint CalculateGCD(out double time, uint number1, uint number2)
        {
            // capturing current time as the beginning time
            DateTime begTime = DateTime.Now;

            // iterative calculation of the Gratest Common Devisor
            while (number1 != number2)
            {
                if (number1 > number2)
                {
                    number1 -= number2;
                }
                else
                {
                    number2 -= number1;
                }
            }

            // capturing current time as the ending time
            DateTime endTime = DateTime.Now;

            // calculating the consumed time (output parameter)
            time = (endTime - begTime).TotalMilliseconds;
            GCDTime = time;

            return number1;
        }

        public uint CalculateGCD(uint number1, uint number2, uint number3)
        {
            if (number1 == number2 && number1 == number3)
            {
                return number1;
            }
            else
            {
                // variable that stores intermidiate result
                uint midResult = CalculateGCD(number1, number2);
                return CalculateGCD(midResult, number3);
            }
        }

        public uint CalculateGCD(uint number1, uint number2, uint number3, uint number4)
        {
            if (number1 == number2 && number1 == number3 && number1 == number4)
            {
                return number1;
            }
            else
            {
                uint midResult = CalculateGCD(number1, number2);
                midResult = CalculateGCD(midResult, number3);
                return CalculateGCD(midResult, number4);
            }
        }

        public uint CalculateGCD(uint number1, uint number2, uint number3, uint number4, uint number5)
        {
            if (number1 == number2 && number1 == number3 && number1 == number4 && number1 == number5)
            {
                return number1;
            }
            else
            {
                uint midResult = CalculateGCD(number1, number2);
                midResult = CalculateGCD(midResult, number3);
                midResult = CalculateGCD(midResult, number4);
                return CalculateGCD(midResult, number5);
            }
        }

        public uint CalculateBinaryGCD(out double time, uint number1, uint number2)
        {
            DateTime endTime;
            DateTime begTime = DateTime.Now;

            var shift = 0;

            if (number1 == 0)
            {
                endTime = DateTime.Now;
                time = (endTime - begTime).TotalMilliseconds;
                BinaryGCDTime = time;

                return number2;
            }
            if (number2 == 0)
            {
                endTime = DateTime.Now;
                time = (endTime - begTime).TotalMilliseconds;
                BinaryGCDTime = time;

                return number1;
            }

            while (((number1 | number2) & 1) == 0)
            {
                shift++;
                number1 >>= 1;
                number2 >>= 1;
            }

            while ((number1 & 1) == 0)
                number1 >>= 1;

            do
            {
                while ((number2 & 1) == 0)
                    number2 >>= 1;

                if (number1 > number2)
                {
                    uint temp = number2; number2 = number1; number1 = temp; 
                }

                number2 -= number1; 
            } while (number2 != 0);

            
            endTime = DateTime.Now;
            time = (endTime - begTime).TotalMilliseconds;
            BinaryGCDTime = time;

            return number1 << shift;
        }

        public SortedDictionary<string, double> GetHistogram()
        {
            SortedDictionary<string, double> histogram = new SortedDictionary<string, double>
            {
                { "GCD", GCDTime * MULTIPLIER },
                { "BinaryGCD", BinaryGCDTime * MULTIPLIER }
            };
            return histogram;
        }
    }
}
