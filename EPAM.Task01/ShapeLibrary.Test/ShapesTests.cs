using FluentAssertions;
using System;
using Xunit;

namespace ShapeLibrary.Test
{
    public class ShapesTests
    {
        [Theory]
        [InlineData(20)]
        [InlineData(123)]
        [InlineData(1)]
        public void GetPerimeter_OfCircleIfRadiusIsValid_ShouldReturnCorrectResult(double radius)
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
        public void GetArea_OfCircleIfRadiusIsValid_ShouldReturnCorrectResult(double radius)
        {
            // Arrange - Act
            Circle circle = new Circle { Radius = radius };

            // Assert
            circle.GetArea().Should().Be(Math.PI * Math.Pow(radius, 2));
        }

        [Theory]
        [InlineData(-20)]
        public void GetPerimeter_OfCircleIfRadiusIsNegative_ShouldThrowArgumentOutOfRangeException(double radius)
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
        public void GetArea_OfCircleIfRadiusIsNegative_ShouldThrowArgumentOutOfRangeException(double radius)
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
        public void GetPerimeter_OfTriangleIfSidesAreValid_ShouldReturnCorrectResult(double side1, double side2, double side3)
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
        public void GetArea_OfTriangleIfSidesAreValid_ShouldReturnCorrectResult(double side1, double side2, double side3)
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
        public void GetPerimeter_OfTriangleIfSideIsNegative_ShouldThrowArgumentOutOfRangeException(double side1, double side2, double side3)
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
        public void GetArea_OfTriangleIfSideIsNegative_ShouldThrowArgumentOutOfRangeException(double side1, double side2, double side3)
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
        public void GetPerimeter_OfRectangleIfSidesAreValid_ShouldReturnCorrectResult(double height, double width)
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
        public void GetArea_OfRectangleIfSidesAreValid_ShouldReturnCorrectResult(double height, double width)
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
        public void GetPerimeter_OfRectangleIfSideIsNegative_ShouldThrowArgumentOutOfRangeException(double height, double width)
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
        public void GetArea_OfRectangleIfSideIsNegative_ShouldThrowArgumentOutOfRangeException(double height, double width)
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
        public void GetPerimeter_OfPentagonIfSideIsValid_ShouldReturnCorrectResult(double side)
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
        public void GetArea_OfPentagonIfSideIsValid_ShouldReturnCorrectResult(double side)
        {
            // Arrange - Act
            Pentagon pentagon = new Pentagon { Side = side };

            // Assert
            pentagon.GetArea().Should().Be(5 * Math.Pow(side, 2) / (4 * Math.Tan(36)));
        }

        [Theory]
        [InlineData(-20)]
        public void GetPerimeter_OfPentagonIfSideIsNegative_ShouldThrowArgumentOutOfRangeException(double side)
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
        public void GetArea_OfPentagonIfSideIsNegative_ShouldThrowArgumentOutOfRangeException(double side)
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

        [Theory]
        [InlineData(20, 21)]
        public void Equals_OfCircleIfValidShapesAreBeingCompared_ShouldReturnCorrectResult(double radius1, double radius2)
        {
            // Arrange - Act
            Circle circle1 = new Circle { Radius = radius1 };
            Circle circle2 = new Circle { Radius = radius1 };
            Circle circle3 = new Circle { Radius = radius2 };

            // Assert
            circle1.Equals(circle2).Should().BeTrue();
            circle1.Equals(circle3).Should().BeFalse();
        }

        [Theory]
        [InlineData(10, 10, 20, 10, 20, 30)]
        public void Equals_OfTriangleIfValidShapesAreBeingCompared_ShouldReturnCorrectResult(double side1_1, double side2_1, double side3_1, 
                                                                                             double side1_2, double side2_2, double side3_2)
        {
            // Arrange - Act
            Triangle triangle1 = new Triangle
            {
                Side1 = side1_1,
                Side2 = side2_1,
                Side3 = side3_1,
            };
            Triangle triangle2 = new Triangle
            {
                Side1 = side1_1,
                Side2 = side2_1,
                Side3 = side3_1,
            };
            Triangle triangle3 = new Triangle
            {
                Side1 = side1_2,
                Side2 = side2_2,
                Side3 = side3_2,
            };

            // Assert
            triangle1.Equals(triangle2).Should().BeTrue();
            triangle1.Equals(triangle3).Should().BeFalse();
        }

        [Theory]
        [InlineData(5, 10, 12, 20)]
        public void Equals_OfRectangleIfValidShapesAreBeingCompared_ShouldReturnCorrectResult(double height1, double width1, double height2, double width2)
        {
            Rectangle rectangle1 = new Rectangle
            {
                Height = height1,
                Width = width1,
            };
            Rectangle rectangle2 = new Rectangle
            {
                Height = height1,
                Width = width1,
            };
            Rectangle rectangle3 = new Rectangle
            {
                Height = height2,
                Width = width2,
            };

            // Assert
            rectangle1.Equals(rectangle2).Should().BeTrue();
            rectangle1.Equals(rectangle3).Should().BeFalse();
        }

        [Theory]
        [InlineData(10, 20)]
        public void Equals_OfPentagonIfValidShapesAreBeingCompared_ShouldReturnCorrectResult(double side1, double side2)
        {
            // Arrange - Act
            Pentagon pentagon1 = new Pentagon { Side = side1, };
            Pentagon pentagon2 = new Pentagon { Side = side1, };
            Pentagon pentagon3 = new Pentagon { Side = side2, };

            // Assert
            pentagon1.Equals(pentagon2).Should().BeTrue();
            pentagon2.Equals(pentagon3).Should().BeFalse();
        }
    }
}
