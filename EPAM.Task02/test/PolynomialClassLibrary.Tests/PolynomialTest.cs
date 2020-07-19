using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace PolynomialClassLibrary.Tests
{
    public class PolynomialTest
    {
        [Fact]
        public void Test1()
        {
            List<double> constants1 = new List<double>
            {
                1, -2, 4, 0, 12,
            };
            Polynomial polynomial1 = new Polynomial(constants1, 4);
            List<double> constants2 = new List<double>
            {
                0, 10, 4,
            };
            Polynomial polynomial2 = new Polynomial(constants2, 2);

            Polynomial result = polynomial1 + polynomial2;
            List<double> l = new List<double>();
            int exponent;

            if (polynomial1.Exponent < polynomial2.Exponent)
            {
                exponent = polynomial2.Exponent;
                for(int i = 0; i <= polynomial2.Exponent; i++)
                {
                    if (i <= polynomial1.Exponent)
                        l.Add(polynomial1.Constants[i] + polynomial2.Constants[i]);
                    else
                        l.Add(polynomial2.Constants[i]);
                }
            }
            else
            {
                exponent = polynomial1.Exponent;
                for (int i = 0; i <= polynomial1.Exponent; i++)
                {
                    if (i <= polynomial2.Exponent)
                        l.Add(polynomial1.Constants[i] + polynomial2.Constants[i]);
                    else
                        l.Add(polynomial1.Constants[i]);
                }
            }
            Polynomial expected = new Polynomial(l, exponent);

            result.Should().Be(expected);
        }
    }
}
