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
            //Vector[] vectors = null;

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
                Vector vector = new Vector(); 
                vector = vector1 + vector2; 
            };

            // Assert
            action.Should().Throw<ArgumentNullException>();            
        }
    }
}
