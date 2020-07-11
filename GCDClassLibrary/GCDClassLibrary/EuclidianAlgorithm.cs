namespace GCDClassLibrary
{
    public class EuclidianAlgorithm
    {
        public int CalculateGCD(int number1, int number2)
        {
            if (number1 < 0 || number2 < 0)
            {
                return 0;
            }
            else
            {
                if (number2 == 0)
                    return number1;
                return CalculateGCD(number2, number1 % number2);
            }
        }
    }
}
