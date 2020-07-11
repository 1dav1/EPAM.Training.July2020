using System;

namespace GCDClassLibrary
{
    public class EuclidianAlgorithm
    {
        private double GCDTime { get; set; }

        private double BinaryGCDTime { get; set; }

        public int CalculateGCD(int number1, int number2)
        {
            if (number1 < 0 || number2 < 0)
            {
                return 0;
            }
            else if (number1 == number2)
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
            DateTime endTime;
            DateTime begTime = DateTime.Now;

            if (number1 < 0 || number2 < 0)
            {
                endTime = DateTime.Now;
                time = (endTime - begTime).TotalMilliseconds;
                GCDTime = time;
                return 0;
            }
            else if (number1 == number2)
            {
                endTime = DateTime.Now;
                time = (endTime - begTime).TotalMilliseconds;
                GCDTime = time;
                return number1;
            }
            else
            {
                if (number2 == 0)
                {
                    endTime = DateTime.Now;
                    time = (endTime - begTime).TotalMilliseconds;
                    GCDTime = time;
                    return number1;
                }

                return CalculateGCD(out time, number2, number1 % number2);
            }
        }

        public int CalculateGCD(int number1, int number2, int number3)
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
                int midResult = CalculateGCD(number1, number2);
                return CalculateGCD(midResult, number3);
            }
        }

        public int CalculateGCD(int number1, int number2, int number3, int number4)
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
                int midResult = CalculateGCD(number1, number2);
                midResult = CalculateGCD(midResult, number3);
                return CalculateGCD(midResult, number4);
            }
        }

        public int CalculateGCD(int number1, int number2, int number3, int number4, int number5)
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
                int midResult = CalculateGCD(number1, number2);
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

            if (number2 % 2 == 0)
            {
                return CalculateBinaryGCD(out time, number1, number2 >> 1);
            }

            if (number1 > number2)
            {
                return CalculateBinaryGCD(out time, (number1 - number2) >> 1, number2);
            }

            return CalculateBinaryGCD(out time, (number2 - number1) >> 1, number1);
        }
    }
}
