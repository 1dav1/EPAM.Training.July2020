using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PolynomialClassLibrary.Tests
{
    public class PolynomialTest
    {
        [Fact]
        public void Polynomial_WhenListIsValid_ShouldNotThrowArgumentNullException()
        {
            // Arrange
            List<double> constants = new List<double> { 12, 0, -3, 123.1, };
            int exponent = 3;

            // Act
            Action action = () => new Polynomial(constants, exponent);

            // Assert
            action.Should().NotThrow<ArgumentNullException>();
        }

        [Theory]
        [InlineData(1, 2, 3, 0, 5, 2, 1)]
        [InlineData(0, 15, -4, 10, 5, 2, 1)]
        [InlineData(7, 3, 25, -8, 1, 2, 1)]
        public void AddPolynomialPolynomial_WhenArgumentsAreValid_ShouldReturnCorrectResult(double a1, double a2, double a3, double b1, double b2, int expA, int expB)
        {
            // Arrange - Act
            List<double> constantsA = new List<double> { a1, a2, a3, };
            Polynomial polynomial1 = new Polynomial(constantsA, expA);

            List<double> constantsB = new List<double> { b1, b2, };
            Polynomial polynomial2 = new Polynomial(constantsB, expB);

            List<double> constants = new List<double> { (a1 + b1), (a2 + b2), a3, };
            int exponent = expA;

            Polynomial expected = new Polynomial(constants, exponent);

            // Assert
            (polynomial1 + polynomial2).Should().Be(expected);
        }


        [Fact]
        public void AddPolynomialPolynomial_WhenArgumentIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            Polynomial polynomial = new Polynomial(new List<double> { 1, 2, 3, }, 2);
            Polynomial nullPolynomial = null;

            // Act
            Action action = () =>
            {
                Polynomial polynomial1 = polynomial + nullPolynomial;
            };

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(1, 2, 3, 2)]
        [InlineData(0, 15, -4, 2)]
        [InlineData(7, 3, 25, 2)]
        public void Negate_WhenPolynomialIsValid_ShouldReturnCorrectResult(double a1, double a2, double a3, int exponent)
        {
            // Arrange - Act
            Polynomial polynomial = new Polynomial(new List<double> { a1, a2, a3, }, exponent);
            Polynomial expected = new Polynomial(new List<double> { -a1, -a2, -a3, }, exponent);

            // Assert
            (-polynomial).Should().Be(expected);

        }

        [Fact]
        public void Negate_WhenArgumentIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            Polynomial polynomial = null;

            // Act
            Action action = () =>
            {
                Polynomial polynomial1 = -polynomial;
            };

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(1, 2, 3, 0, 5, 2, 1)]
        [InlineData(0, 15, -4, 10, 5, 2, 1)]
        [InlineData(7, 3, 25, -8, 1, 2, 1)]
        public void SubtractPolynomialPolynomial_WhenArgumentsAreValid_ShouldReturnCorrectResult(double a1, double a2, double a3,
                                                                                                 double b1, double b2,
                                                                                                 int expA, int expB)
        {
            // Arrange - Act
            List<double> constantsA = new List<double> { a1, a2, a3, };
            Polynomial polynomial1 = new Polynomial(constantsA, expA);

            List<double> constantsB = new List<double> { b1, b2, };
            Polynomial polynomial2 = new Polynomial(constantsB, expB);

            List<double> constants = new List<double> { (a1 - b1), (a2 - b2), a3, };
            int exponent = expA;

            Polynomial expected = new Polynomial(constants, exponent);

            // Assert
            (polynomial1 - polynomial2).Should().Be(expected);
        }

        [Fact]
        public void SubtractPolynomialPolynomial_WhenArgumentIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            Polynomial polynomial = new Polynomial(new List<double> { 1, 2, 3, }, 2);
            Polynomial nullPolynomial = null;

            // Act
            Action action = () =>
            {
                Polynomial polynomial1 = polynomial - nullPolynomial;
            };

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(1, 2, 3, 0, 5, 2, 1)]
        [InlineData(0, 15, -4, 10, 5, 2, 1)]
        [InlineData(7, 3, 25, -8, 1, 2, 1)]
        public void MultiplyPolynomialPolynomial_WhenArgumentsAreValid_ShouldReturnCorrectResult(double a1, double a2, double a3,
                                                                                                 double b1, double b2,
                                                                                                 int expA, int expB)
        {
            // Arrange - Act
            List<double> constantsA = new List<double> { a1, a2, a3, };
            Polynomial polynomial1 = new Polynomial(constantsA, expA);

            List<double> constantsB = new List<double> { b1, b2, };
            Polynomial polynomial2 = new Polynomial(constantsB, expB);

            List<double> constants = new List<double> { (a1 * b1), (a2 * b1 + a1 * b2), (a2 * b2 + a3 * b1), a3 * b2, };
            int exponent = expA + expB;

            Polynomial expected = new Polynomial(constants, exponent);

            // Assert
            (polynomial1 * polynomial2).Should().Be(expected);
        }

        [Fact]
        public void MultiplyPolynomialPolynomial_WhenArgumentIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            Polynomial polynomial = new Polynomial(new List<double> { 1, 2, 3, }, 2);
            Polynomial nullPolynomial = null;

            // Act
            Action action = () =>
            {
                Polynomial polynomial1 = polynomial * nullPolynomial;
            };

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(25, 2, 3, 0, 2)]
        [InlineData(100.15, 15, -4, 10, 2)]
        [InlineData(-7, 3, 25, -8, 2)]
        public void MultiplyDoublePolynomial_WhenArgumentsAreValid_ShouldReturnCorrectResult(double scalar, double a1, double a2,
                                                                                             double a3, int exponent)
        {
            // Arrange - Act
            List<double> constants = new List<double> { a1, a2, a3, };
            Polynomial polynomial = new Polynomial(constants, exponent);

            List<double> expConstants = new List<double> { (scalar * a1), (scalar * a2), (scalar * a3), };
            Polynomial expected = new Polynomial(expConstants, exponent);

            // Assert
            (scalar * polynomial).Should().Be(expected);
            (polynomial * scalar).Should().Be(expected);
        }

        [Fact]
        public void MultiplyScalarPolynomial_WhenArgumentIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            Polynomial nullPolynomial = null;
            double scalar = 1.2;

            // Act
            Action action = () =>
            {
                Polynomial polynomial = scalar * nullPolynomial;
            };

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }
    }
}
