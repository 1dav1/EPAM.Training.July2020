using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;

namespace PolynomialClassLibrary
{
    public class Polynomial
    {
        public List<double> Constants { get; }
        public int Exponent { get; }

        public Polynomial(IEnumerable<double> constants, int exponent)
        {
            Constants = (List<double>)constants;
            Exponent = exponent;
        }

        public static Polynomial operator +(Polynomial polynomial1, Polynomial polynomial2)
        {
            if (polynomial1 == null || polynomial2 == null)
                throw new ArgumentNullException();

            List<double> constants = new List<double>();
            int exponent;

            if (polynomial1.Exponent < polynomial2.Exponent)
            {
                // the exponent of the result polynomial equals the biggest of the exponents of two specified polynomials
                exponent = polynomial2.Exponent;

                for(int i = 0; i <= polynomial2.Exponent; i++)
                {
                    if (i <= polynomial1.Exponent)
                        // summarizing the correspondent constants of two polynomials
                        constants.Add(polynomial1.Constants[i] + polynomial2.Constants[i]);
                    else
                        // adding the residual constants of the polynomial with the higher exponent to the list of constants of the resulting polynomial
                        constants.Add(polynomial2.Constants[i]);
                }
            }
            else
            {
                exponent = polynomial1.Exponent;

                for(int i = 0; i <= polynomial1.Exponent; i++)
                {
                    if (i <= polynomial2.Exponent)
                        constants.Add(polynomial1.Constants[i] + polynomial2.Constants[i]);
                    else
                        constants.Add(polynomial1.Constants[i]);
                }
            }

            return new Polynomial(constants, exponent);
        }
    }
}
