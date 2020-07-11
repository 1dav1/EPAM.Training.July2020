using System;
using System.Collections.Generic;
using System.IO;

namespace GCDClassLibrary
{
    public class GCDCalculator
    {
        private int GCDTime { get; set; }

        private int BinaryGCDTime { get; set; }

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

        public int CalculateGCD(out int time, int number1, int number2)
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
            time = (endTime.Millisecond - begTime.Millisecond);
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

        public uint CalculateBinaryGCD(out int time, uint number1, uint number2)
        {
            DateTime endTime;
            DateTime begTime = DateTime.Now;

            var shift = 0;

            /* GCD(0,v) == v; GCD(u,0) == u, GCD(0,0) == 0 */
            if (number1 == 0)
            {
                endTime = DateTime.Now;
                time = (endTime.Millisecond - begTime.Millisecond);
                BinaryGCDTime = time;

                return number2;
            }
            if (number2 == 0)
            {
                endTime = DateTime.Now;
                time = (endTime.Millisecond - begTime.Millisecond);
                BinaryGCDTime = time;

                return number1;
            }

            /* Let shift := lg K, where K is the greatest power of 2
                dividing both u and v. */
            while (((number1 | number2) & 1) == 0)
            {
                shift++;
                number1 >>= 1;
                number2 >>= 1;
            }

            while ((number1 & 1) == 0)
                number1 >>= 1;

            /* From here on, u is always odd. */
            do
            {
                /* remove all factors of 2 in v -- they are not common */
                /*   note: v is not zero, so while will terminate */
                while ((number2 & 1) == 0)
                    number2 >>= 1;

                /* Now u and v are both odd. Swap if necessary so u <= v,
                    then set v = v - u (which is even). For bignums, the
                     swapping is just pointer movement, and the subtraction
                      can be done in-place. */
                if (number1 > number2)
                {
                    uint temp = number2; number2 = number1; number1 = temp; // Swap u and v.
                }

                number2 -= number1; // Here v >= u.
            } while (number2 != 0);

            /* restore common factors of 2 */
            
            endTime = DateTime.Now;
            time = (endTime.Millisecond - begTime.Millisecond);
            BinaryGCDTime = time;

            return number1 << shift;





            //if (number1 == number2)
            //{
            //    endTime = DateTime.Now;
            //    time = (endTime - begTime).TotalMilliseconds;
            //    BinaryGCDTime = time;
            //    return number1;
            //}

            //if (number1 == 0)
            //{
            //    endTime = DateTime.Now;
            //    time = (endTime - begTime).TotalMilliseconds;
            //    BinaryGCDTime = time;
            //    return number2;
            //}

            //if (number2 == 0)
            //{
            //    endTime = DateTime.Now;
            //    time = (endTime - begTime).TotalMilliseconds;
            //    BinaryGCDTime = time;
            //    return number1;
            //}

            //if ((number1 & 1) == 0)
            //{
            //    if (number2 % 2 != 0)
            //    {
            //        return CalculateBinaryGCD(out time, number1 >> 1, number2);
            //    }
            //    else
            //    {
            //        return CalculateBinaryGCD(out time, number1 >> 1, number2 >> 1) << 1;
            //    }
            //}

            //if ((number2 & 1) == 0)
            //{
            //    return CalculateBinaryGCD(out time, number1, number2 >> 1);
            //}

            //if (number1 > number2)
            //{
            //    return CalculateBinaryGCD(out time, (number1 - number2) >> 1, number2);
            //}

            //return CalculateBinaryGCD(out time, (number2 - number1) >> 1, number1);
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
