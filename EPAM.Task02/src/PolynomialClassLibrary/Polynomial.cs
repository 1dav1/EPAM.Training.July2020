using System;
using System.Collections.Generic;
using System.Linq;

namespace PolynomialClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="polynomial"]/Polynomial/*'/>
    public class Polynomial
    {
        /// <include file='docs.xml' path='docs/members[@name="polynomial"]/Constants/*'/>
        public List<double> Constants { get; }

        /// <include file='docs.xml' path='docs/members[@name="polynomial"]/Exponent/*'/>
        public int Exponent { get; }

        /// <include file='docs.xml' path='docs/members[@name="polynomial"]/Constructor/*'/>
        public Polynomial(IEnumerable<double> constants, int exponent)
        {
            if (constants == null)
                throw new ArgumentNullException();

            Constants = (List<double>)constants;
            Exponent = exponent;
        }

        /// <include file='docs.xml' path='docs/members[@name="polynomial"]/AddPolynomialPolynomial/*'/>
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

                for (int i = 0; i <= polynomial2.Exponent; i++)
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

                for (int i = 0; i <= polynomial1.Exponent; i++)
                {
                    if (i <= polynomial2.Exponent)
                        constants.Add(polynomial1.Constants[i] + polynomial2.Constants[i]);
                    else
                        constants.Add(polynomial1.Constants[i]);
                }
            }

            return new Polynomial(constants, exponent);
        }

        /// <include file='docs.xml' path='docs/members[@name="polynomial"]/Negate/*'/>
        public static Polynomial operator -(Polynomial polynomial)
        {
            if (polynomial == null)
                throw new ArgumentNullException();

            List<double> constants = new List<double>();

            for (int i = 0; i <= polynomial.Exponent; i++)
            {
                constants.Add(-polynomial.Constants[i]);
            }

            return new Polynomial(constants, polynomial.Exponent);
        }

        /// <include file='docs.xml' path='docs/members[@name="polynomial"]/Subtract/*'/>
        public static Polynomial operator -(Polynomial polynomial1, Polynomial polynomial2)
            => polynomial1 + (-polynomial2);

        /// <include file='docs.xml' path='docs/members[@name="polynomial"]/MultiplyDoublePolynomial/*'/>
        public static Polynomial operator *(double scalar, Polynomial polynomial)
        {
            if (polynomial == null)
                throw new ArgumentNullException();

            int exponent = polynomial.Exponent;
            List<double> constants = new List<double>();

            var multipliedConstants = from c in polynomial.Constants
                                      select scalar * c;

            constants.AddRange(multipliedConstants);

            return new Polynomial(constants, exponent);
        }

        /// <include file='docs.xml' path='docs/members[@name="polynomial"]/MultiplyDoublePolynomial/*'/>
        public static Polynomial operator *(Polynomial polynomial, double scalar)
            => (scalar * polynomial);

        /// <include file='docs.xml' path='docs/members[@name="polynomial"]/MultiplyPolynomialPolynomial/*'/>
        public static Polynomial operator *(Polynomial polynomial1, Polynomial polynomial2)
        {
            if (polynomial1 == null || polynomial2 == null)
                throw new ArgumentNullException();

            int exponent = polynomial1.Exponent + polynomial2.Exponent;
            List<double> constants = new List<double>(exponent + 1);

            // initializing the list with zeroes
            for (int i = 0; i <= exponent; i++)
                constants.Add(0);

            for (int i = 0; i <= polynomial2.Exponent; i++)
            {
                for (int j = 0; j <= polynomial1.Exponent; j++)
                {
                    constants[i + j] += polynomial1.Constants[j] * polynomial2.Constants[i];
                }
            }

            return new Polynomial(constants, exponent);
        }

        /// <include file='docs.xml' path='docs/members[@name="polynomial"]/Equals/*'/>
        override public bool Equals(object obj)
        {
            if (obj is Polynomial polynomial)
            {
                if (polynomial.Exponent != this.Exponent)
                    return false;
                for (int i = 0; i <= polynomial.Exponent; i++)
                {
                    if (polynomial.Constants[i] != this.Constants[i])
                        return false;
                }
                return true;
            }
            return false;
        }

        /// <include file='docs.xml' path='docs/members[@name="polynomial"]/GetHashCode/*'/>
        public override int GetHashCode()
            => HashCode.Combine(Exponent, Constants);
    }
}
