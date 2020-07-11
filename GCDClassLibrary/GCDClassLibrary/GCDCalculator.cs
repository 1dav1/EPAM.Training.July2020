using System;
using System.Collections.Generic;

namespace GCDClassLibrary
{
    public class GCDCalculator
    {
        private double GCDTime { get; set; }

        private double BinaryGCDTime { get; set; }

        // multiplier to convert milliseconds to pixels
        private const int MULTIPLIER = 1000;

        public uint CalculateGCD(uint number1, uint number2)
        {
            //if (number1 < 0 || number2 < 0)
            //{
            //    return 0;
            //}
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

                return CalculateGCD(number2, number1 % number2);
            }
        }

        public int CalculateGCD(out double time, int number1, int number2)
        {
            DateTime begTime = DateTime.Now;
            while(number1 != number2)
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
            DateTime endTime = DateTime.Now;
            time = (endTime - begTime).TotalMilliseconds;
            return number1;
        }

        public uint CalculateGCD(uint number1, uint number2, uint number3)
        {
            if (number1 < 0 || number2 < 0 || number3 < 0)
            {
                return 0;
            }
            else if (number1 == number2 && number1 == number3)
            {
                return number1;
            }
            else
            {
                uint midResult = CalculateGCD(number1, number2);
                return CalculateGCD(midResult, number3);
            }
        }

        public uint CalculateGCD(uint number1, uint number2, uint number3, uint number4)
        {
            if (number1 < 0 || number2 < 0 || number3 < 0 || number4 < 0)
            {
                return 0;
            }
            else if (number1 == number2 && number1 == number3 && number1 == number4)
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
            if (number1 < 0 || number2 < 0 || number3 < 0 || number4 < 0 || number5 < 0)
            {
                return 0;
            }
            else if (number1 == number2 && number1 == number3 && number1 == number4 && number1 == number5)
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

        public int CalculateBinaryGCD(out double time, int number1, int number2)
        {
            DateTime endTime;
            DateTime begTime = DateTime.Now;

            if (number1 == number2)
            {
                endTime = DateTime.Now;
                time = (endTime - begTime).TotalMilliseconds;
                BinaryGCDTime = time;
                return number1;
            }

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

            if ((number1 & 1) == 0)
            {
                if (number2 % 2 != 0)
                {
                    return CalculateBinaryGCD(out time, number1 >> 1, number2);
                }
                else
                {
                    return CalculateBinaryGCD(out time, number1 >> 1, number2 >> 1) << 1;
                }
            }

            if ((number2 & 1) == 0)
            {
                return CalculateBinaryGCD(out time, number1, number2 >> 1);
            }

            if (number1 > number2)
            {
                return CalculateBinaryGCD(out time, (number1 - number2) >> 1, number2);
            }

            return CalculateBinaryGCD(out time, (number2 - number1) >> 1, number1);
        }

        public SortedDictionary<string, double> GetHistogram()
        {
            SortedDictionary<string, double> histogram = new SortedDictionary<string, double>();
            histogram.Add("GCD", GCDTime * MULTIPLIER);
            histogram.Add("BinaryGCD", BinaryGCDTime * MULTIPLIER);
            return histogram;
        }
    }
}
