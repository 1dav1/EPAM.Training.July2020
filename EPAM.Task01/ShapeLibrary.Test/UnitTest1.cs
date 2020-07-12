using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace ShapeLibrary.Test
{
    interface IFile
    {
        public string[] ReadAllLines(string path);
    }

    public class UnitTest1
    {
        [Theory]
        [InlineData(20)]
        [InlineData(123)]
        [InlineData(1)]
        public void GetPerimeter_OfCircleIfRadiusIsValid_ShouldReturnCorrectResult(int radius)
        {
            // Arrange - Act
            Circle circle = new Circle { Radius = radius };

            // Assert
            circle.GetPerimeter().Should().Be(Math.PI * 2 * radius);
        }

        [Theory]
        [InlineData(20)]
        [InlineData(123)]
        [InlineData(1)]
        public void GetArea_OfCircleIfRadiusIsValid_ShouldReturnCorrectResult(int radius)
        {
            // Arrange - Act
            Circle circle = new Circle { Radius = radius };

            // Assert
            circle.GetArea().Should().Be(Math.PI * Math.Pow(radius, 2));
        }

        [Theory]
        [InlineData(-20)]
        public void GetPerimeter_OfCircleIfRadiusIsNegative_ShouldThrowArgumentOutOfRangeException(int radius)
        {
            // Arrange
            Circle circle = new Circle { Radius = radius };

            // Act
            Action action = () => circle.GetPerimeter();

            // Assert
            action.Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage("*Radius*");
        }

        [Theory]
        [InlineData(-20)]
        public void GetArea_OfCircleIfRadiusIsNegative_ShouldThrowArgumentOutOfRangeException(int radius)
        {
            // Arrange
            Circle circle = new Circle { Radius = radius };

            // Act
            Action action = () => circle.GetArea();

            // Assert
            action.Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage("*Radius*");
        }


        [Theory]
        [InlineData(10, 10, 20)]
        [InlineData(1, 5, 12)]
        [InlineData(12, 33, 15)]
        public void GetPerimeter_OfTriangleIfSidesAreValid_ShouldReturnCorrectResult(int side1, int side2, int side3)
        {
            // Arrange - Act
            Triangle triangle = new Triangle
            {
                Side1 = side1,
                Side2 = side2,
                Side3 = side3,
            };

            // Assert
            triangle.GetPerimeter().Should().Be(side1 + side2 + side3);
        }

        [Theory]
        [InlineData(10, 10, 20)]
        [InlineData(1, 5, 12)]
        [InlineData(12, 33, 15)]
        public void GetArea_OfTriangleIfSidesAreValid_ShouldReturnCorrectResult(int side1, int side2, int side3)
        {
            // Arrange - Act
            Triangle triangle = new Triangle
            {
                Side1 = side1,
                Side2 = side2,
                Side3 = side3,
            };
            double perimeter = side1 + side2 + side3;

            // Assert
            triangle.GetArea().Should().Be(Math.Sqrt(perimeter * (perimeter - side1) * (perimeter - side2) * (perimeter - side3)));
        }


        [Theory]
        [InlineData(-20, 20, 10)]
        public void GetPerimeter_OfTriangleIfSideIsNegative_ShouldThrowArgumentOutOfRangeException(int side1, int side2, int side3)
        {
            // Arrange
            Triangle triangle = new Triangle
            {
                Side1 = side1,
                Side2 = side2,
                Side3 = side3,
            };

            // Act
            Action action = () => triangle.GetPerimeter();

            // Assert
            action.Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage("*Side*");
        }

        [Theory]
        [InlineData(-20, 20, 10)]
        public void GetArea_OfTriangleIfSideIsNegative_ShouldThrowArgumentOutOfRangeException(int side1, int side2, int side3)
        {
            // Arrange
            Triangle triangle = new Triangle
            {
                Side1 = side1,
                Side2 = side2,
                Side3 = side3,
            };
            double perimeter = side1 + side2 + side3;

            // Act
            Action action = () => triangle.GetArea();

            // Assert
            action.Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage("*Side*");
        }

        [Theory]
        [InlineData(5, 10)]
        [InlineData(1, 5)]
        [InlineData(12, 33)]
        public void GetPerimeter_OfRectangleIfSidesAreValid_ShouldReturnCorrectResult(int height, int width)
        {
            // Arrange - Act
            Rectangle rectangle = new Rectangle
            {
                Height = height,
                Width = width,
            };

            // Assert
            rectangle.GetPerimeter().Should().Be((height + width) * 2);
        }

        [Theory]
        [InlineData(5, 10)]
        [InlineData(1, 5)]
        [InlineData(12, 33)]
        public void GetArea_OfRectangleIfSidesAreValid_ShouldReturnCorrectResult(int height, int width)
        {
            // Arrange - Act
            Rectangle rectangle = new Rectangle
            {
                Height = height,
                Width = width,
            };

            // Assert
            rectangle.GetArea().Should().Be(height * width);
        }

        [Theory]
        [InlineData(-20, 20)]
        public void GetPerimeter_OfRectangleIfSideIsNegative_ShouldThrowArgumentOutOfRangeException(int height, int width)
        {
            // Arrange
            Rectangle rectangle = new Rectangle
            {
                Height = height,
                Width = width,
            };

            // Act
            Action action = () => rectangle.GetPerimeter();

            // Assert
            action.Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage("*Side*");
        }

        [Theory]
        [InlineData(-20, 20)]
        public void GetArea_OfRectangleIfSideIsNegative_ShouldThrowArgumentOutOfRangeException(int height, int width)
        {
            // Arrange
            Rectangle rectangle = new Rectangle
            {
                Height = height,
                Width = width,
            };

            // Act
            Action action = () => rectangle.GetArea();

            // Assert
            action.Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage("*Side*");
        }

        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(33)]
        public void GetPerimeter_OfPentagonIfSideIsValid_ShouldReturnCorrectResult(int side)
        {
            // Arrange - Act
            Pentagon pentagon = new Pentagon { Side = side };

            // Assert
            pentagon.GetPerimeter().Should().Be(side * 5);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(33)]
        public void GetArea_OfPentagonIfSideIsValid_ShouldReturnCorrectResult(int side)
        {
            // Arrange - Act
            Pentagon pentagon = new Pentagon { Side = side };

            // Assert
            pentagon.GetArea().Should().Be(5 * Math.Pow(side, 2) / (4 * Math.Tan(36)));
        }

        [Theory]
        [InlineData(-20)]
        public void GetPerimeter_OfPentagonIfSideIsNegative_ShouldThrowArgumentOutOfRangeException(int side)
        {
            // Arrange
            Pentagon pentagon = new Pentagon { Side = side };

            // Act
            Action action = () => pentagon.GetPerimeter();

            // Assert
            action.Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage("*Side*");
        }

        [Theory]
        [InlineData(-20)]
        public void GetArea_OfPentagonIfSideIsNegative_ShouldThrowArgumentOutOfRangeException(int side)
        {
            // Arrange
            Pentagon pentagon = new Pentagon { Side = side };

            // Act
            Action action = () => pentagon.GetArea();

            // Assert
            action.Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage("*Side*");
        }
    }
}
