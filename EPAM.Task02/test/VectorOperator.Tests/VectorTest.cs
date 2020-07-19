using FluentAssertions;
using System;
using Xunit;

namespace VectorOperator.Tests
{
    public class VectorTest
    {
        [Theory]
        [InlineData(10, 20, 30, 100, 0, 15)]
        [InlineData(100, 0, 15, 12.5, 31.9, 10.1)]
        [InlineData(12.5, 31.9, 10.1, 10, 20, 30)]
        public void AddVectorVector_WhenVectorsAreValid_ShouldReturnCorrectResult(double aX, double aY, double aZ, double bX, double bY, double bZ)
        {
            // Arrange
            Vector vector1 = new Vector { X = aX, Y = aY, Z = aZ, };
            Vector vector2 = new Vector { X = bX, Y = bY, Z = bZ, };

            // Act
            Vector resultVector = vector1 + vector2;

            // Assert
            resultVector.Should().Be(new Vector { X = aX + bX, Y = aY + bY, Z = aZ + bZ, });
        }

        [Theory]
        [InlineData(10, 20, 30)]
        public void AddVectorVector_WhenVectorIsNull_ShouldThrowArgumentNullException(double x, double y, double z)
        {
            // Arrenge
            Vector vector1 = new Vector
            {
                X = x,
                Y = y,
                Z = z,
            };
            Vector vector2 = null;

            // Act
            Action action = () => 
            { 
                Vector vector = vector1 + vector2; 
            };

            // Assert
            action.Should().Throw<ArgumentNullException>();            
        }

        [Theory]
        [InlineData(10, 20, 30)]
        [InlineData(100, 0, 15)]
        [InlineData(12.5, 31.9, 10.1)]
        public void NegateVector_WhenVectorIsValid_ShouldReturnNegatedVector(double x, double y, double z)
        {
            // Arrange - Act
            Vector vector = new Vector { X = x, Y = y, Z = z, };

            // Assert
            (-vector).Should().Be(new Vector { X = -x, Y = -y, Z = -z, });
        }

        [Fact]
        public void NegateVector_WhenVectorIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            Vector vector = null;

            // Act
            Action action = () =>
            {
                Vector negatedVector = -vector;
            };

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(10, 20, 30, 100, 0, 15)]
        [InlineData(100, 0, 15, 12.5, 31.9, 10.1)]
        [InlineData(12.5, 31.9, 10.1, 10, 20, 30)]
        public void AddVectorPoint_WhenArgumentsAreValid_ShouldReturnCorrectResult(double aX, double aY, double aZ, double bX, double bY, double bZ)
        {
            // Arrange
            Vector vector = new Vector { X = aX, Y = aY, Z = aZ, };
            Point point = new Point { X = bX, Y = bY, Z = bZ, };

            // Act
            Point resultPoint1 = vector + point;
            Point resultPoint2 = point + vector;

            // Assert
            resultPoint1.Should().Be(new Point { X = aX + bX, Y = aY + bY, Z = aZ + bZ, });
            resultPoint2.Should().Be(new Point { X = aX + bX, Y = aY + bY, Z = aZ + bZ, });
        }

        [Theory]
        [InlineData(10, 20, 30)]
        public void AddVectorPoint_WhenArgumentIsNull_ShouldThrowArgumentNullException(double x, double y, double z)
        {
            // Arrange
            Vector vector = new Vector { X = x, Y = y, Z = z, };
            Vector nullVector = null;
            Point point = new Point { X = x, Y = y, Z = z, };
            Point nullPoint = null;

            // Act
            Action action1 = () =>
            {
                Point resultPoint = new Point();
                resultPoint = vector + nullPoint;
            };

            Action action2 = () =>
            {
                Point resultPoint = point + nullVector;
            };

            // Assert
            action1.Should().Throw<ArgumentNullException>();
            action2.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(10, 20, 30, 100, 0, 15)]
        [InlineData(100, 0, 15, 12.5, 31.9, 10.1)]
        [InlineData(12.5, 31.9, 10.1, 10, 20, 30)]
        public void SubtractVectorVector_WhenVectorsAreValid_ShouldReturnCorrectResult(double aX, double aY, double aZ, double bX, double bY, double bZ)
        {
            // Arrange - Act
            Vector vector1 = new Vector
            {
                X = aX,
                Y = aY,
                Z = aZ,
            };
            Vector vector2 = new Vector
            {
                X = bX,
                Y = bY,
                Z = bZ,
            };

            // Assert
            (vector1 - vector2).Should().Be(new Vector { X = aX - bX, Y = aY - bY, Z = aZ - bZ, });
        }

        [Theory]
        [InlineData(10, 20, 30)]
        public void SubtractVectorVector_WhenVectorIsNull_ShouldThrowArgumentNullException(double x, double y, double z)
        {
            // Arrange
            Vector vector = new Vector { X = x, Y = y, Z = z, };
            Vector nullVector = null;

            // Act
            Action action = () =>
            {
                Vector resultVector = vector - nullVector;
            };

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(10, 20, 30, 100)]
        [InlineData(100, 0, 15, 12.5)]
        [InlineData(12.5, 31.9, 10.1, 10)]
        public void MultiplyDoubleVector_WhenVectorIsValid_ShouldReturnCorrectResult(double x, double y, double z, double scalar)
        {
            // Arrange - Act
            Vector vector = new Vector { X = x, Y = y, Z = z, };

            // Assert
            (vector * scalar).Should().Be(new Vector { X = x * scalar, Y = y * scalar, Z = z * scalar, });
            (scalar * vector).Should().Be(new Vector { X = x * scalar, Y = y * scalar, Z = z * scalar, });
        }

        [Theory]
        [InlineData(10)]
        public void MultiplyDoubleVector_WhenVectorIsNull_ShouldThrowArgumentNullException(double scalar)
        {
            // Arrange
            Vector nullVector = null;

            // Act
            Action action = () =>
            {
                Vector resultVector = nullVector * scalar;
            };

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(10, 20, 30, 100, 0, 15)]
        [InlineData(100, 0, 15, 12.5, 31.9, 10.1)]
        [InlineData(12.5, 31.9, 10.1, 10, 20, 30)]
        public void MultiplyVectorVector_WhenVectorsAreValid_ShouldReturnCorrectResult(double aX, double aY, double aZ, double bX, double bY, double bZ)
        {
            // Arrange - Act
            Vector vector1 = new Vector
            {
                X = aX,
                Y = aY,
                Z = aZ,
            };
            Vector vector2 = new Vector
            {
                X = bX,
                Y = bY,
                Z = bZ,
            };

            // Assert
            (vector1 * vector2).Should().Be(aX * bX + aY * bY + aZ * bZ);
        }

        [Theory]
        [InlineData(10, 20, 30)]
        public void MultiplyVectorVector_WhenVectorIsNull_ShouldThrowArgumentNullException(double x, double y, double z)
        {
            // Arrange 
            Vector vector = new Vector
            {
                X = x,
                Y = y,
                Z = z,
            };
            Vector nullVector = null;

            // Act
            Action action = () =>
            {
                double result = vector * nullVector;
            };

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(10, 20, 30)]
        public void Equals_WhenArgumentIsValid_ShouldReturnCorrectResult(double x, double y, double z)
        {
            // Arrenge - Act
            Vector vector1 = new Vector
            {
                X = x,
                Y = y,
                Z = z,
            };
            Vector vector2 = new Vector
            {
                X = x,
                Y = y,
                Z = z,
            };

            // Assert
            vector1.Equals(vector2).Should().BeTrue();
        }
    }
}
