using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace ShapeLibrary.Test
{
    /// <include file='docs.xml' path='docs/members[@name="ireader"]/IReader/*'/>
    public interface IReader
    {
        /// <include file='docs.xml' path='docs/members[@name="ireader"]/GetLinesFromFile/*'/>
        public string[] GetLinesFromFile(string path);
    }

    /// <include file='docs.xml' path='docs/members[@name="shapestests"]/GetLinesFromFile/*'/>
    public class ShapesTests
    {
        readonly List<Shape> expectedShapes = new List<Shape>
        {
             new Triangle
            {
                Side1 = 10,
                Side2 = 10,
                Side3 = 20,
            },
             new Triangle
            {
                Side1 = 18,
                Side2 = 30,
                Side3 = 24,
            },
             new Rectangle
            {
                Height = 5,
                Width = 10,
            },
             new Circle
            {
                Radius = 20,
            },
             new Pentagon
            {
                Side = 15,
            },
        };

        readonly string[] lines = { "10;10;20", "18;30;24", "(0,0);(0,5);(10,5);(10,0)", "20", "15;15;15;15;15" };

        readonly string path = "..\\..\\..\\..\\docs\\shapes.txt";

        /// <include file='docs.xml' path='docs/members[@name="shapestests"]/GetShapes/*'/>
        [Fact]
        public void GetShapes_FromTextStrings_ShouldReturnCollectionOfShapes()
        {
            // Arrange
            Mock<IReader> mockInterface = new Mock<IReader>();
            mockInterface.Setup(r => r.GetLinesFromFile(path)).Returns(lines);
            IReader reader = mockInterface.Object;

            // Act
            List<Shape> shapes = new ShapeFactory().GetShapes(reader.GetLinesFromFile(path));

            // Assert
            shapes.Should().BeEquivalentTo<Shape>(expectedShapes, options => options.RespectingRuntimeTypes());
        }

        /// <include file='docs.xml' path='docs/members[@name="shapestests"]/GetEqualShapes/*'/>
        [Theory]
        [InlineData(10, 10, 20)]
        public void GetEqualShapes_IfEqualShapePassed_ShouldReturnNotEmptyCollection(double side1, double side2, double side3)
        {
            // Arrange - Act
            ShapeFactory shapeFactory = new ShapeFactory();

            Triangle triangle = new Triangle
            {
                Side1 = side1,
                Side2 = side2,
                Side3 = side3,
            };

            // Assert
            shapeFactory.GetEqualShapes(triangle, expectedShapes).Should().NotBeEmpty();
        }

        /// <include file='docs.xml' path='docs/members[@name="shapestests"]/GetEqualShapesNot/*'/>
        [Theory]
        [InlineData(30, 10, 20)]
        public void GetEqualShapes_IfNotEqualShapePassed_ShouldReturnEmptyCollection(double side1, double side2, double side3)
        {
            // Arrange Act
            ShapeFactory shapeFactory = new ShapeFactory();

            Triangle triangle = new Triangle
            {
                Side1 = side1,
                Side2 = side2,
                Side3 = side3,
            };

            // Assert
            shapeFactory.GetEqualShapes(triangle, expectedShapes).Should().BeEmpty();
        }

        /// <include file='docs.xml' path='docs/members[@name="shapestests"]/GetPerimeterCircle/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="shapestests"]/GetAreaCircle/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="shapestests"]/GetPerimeterCircleEx/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="shapestests"]/GetAreaCircleEx/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="shapestests"]/GetPerimeterTriangle/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="shapestests"]/GetAreaTriangle/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="shapestests"]/GetPerimeterTriangleEx/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="shapestests"]/GetAreaTriangleEx/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="shapestests"]/GetPerimeterRectangle/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="shapestests"]/GetAreaRectangle/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="shapestests"]/GetPerimeterRectangleEx/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="shapestests"]/GetAreaRectangleEx/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="shapestests"]/GetPerimeterPentagon/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="shapestests"]/GetAreaPentagon/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="shapestests"]/GetPerimeterPentagonEx/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="shapestests"]/GetAreaPentagonEx/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="shapestests"]/EqualsCircle/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="shapestests"]/EqualsTriangle/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="shapestests"]/EqualsRectangle/*'/>
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

        /// <include file='docs.xml' path='docs/members[@name="shapestests"]/EqualsPentagon/*'/>
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
