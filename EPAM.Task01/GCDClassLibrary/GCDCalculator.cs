using System;
using System.Collections.Generic;

namespace GCDClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="calculator"]/GCDCalculator/*'/>
    public class GCDCalculator
    {
        private double GCDTime { get; set; }

        private double BinaryGCDTime { get; set; }

        // multiplier to convert milliseconds to more readable format
        private const int MULTIPLIER = 1000;

        /// <include file='docs.xml' path='docs/members[@name="calculator"]/CalculateTwoInt/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="calculator"]/CalculateWithTime/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="calculator"]/CalculateThreeInt/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="calculator"]/CalculateFourInt/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="calculator"]/CalculateFiveInt/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="calculator"]/CalculateBinWithTime/*'/>
        public uint CalculateBinaryGCD(out double time, uint number1, uint number2)
        {
            DateTime endTime;
            DateTime begTime = DateTime.Now;

            var shift = 0;

            // GCD(0, number2) == number2; GCD(number1, 0) == number1, GCD(0,0) == 0
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

            /* Let shift := lg K, where K is the greatest power of 2
             * dividing both number1 and number2. */
            while (((number1 | number2) & 1) == 0)
            {
                shift++;
                number1 >>= 1;
                number2 >>= 1;
            }

            while ((number1 & 1) == 0)
                number1 >>= 1;

            // From here on, number1 is always odd.
            do
            {
                /* remove all factors of 2 in number2 - they are not common
                 * note: number2 is not zero, so while will terminate */
                while ((number2 & 1) == 0)
                    number2 >>= 1;

                /* Now number1 and number2 are both odd. Swap if necessary so number1 <= number2,
                 * then set number2 = number2 - number1 (which is even). For bignums, the
                 * swapping is just pointer movement, and the subtraction
                 * can be done in-place. */
                if (number1 > number2)
                {
                    uint temp = number2; number2 = number1; number1 = temp; 
                }

                // Here number2 >= number1.
                number2 -= number1; 
            } while (number2 != 0);

            endTime = DateTime.Now;
            time = (endTime - begTime).TotalMilliseconds;
            BinaryGCDTime = time;

            // restore common factors of 2
            return number1 << shift;
        }

        /// <include file='docs.xml' path='docs/members[@name="calculator"]/GetHistogram/*'/>
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
