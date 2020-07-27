using FluentAssertions;
using System;
using Xunit;

namespace ShapeClassLibrary.Tests
{
    public class PaperTriangleTests
    {
        private static readonly PaperRectangle paperRectangle = new PaperRectangle
        {
            Id = 1,
            Height = 100,
            Width = 120,
            Color = Colors.Blue,
        };
        private static readonly PaperTriangle paperTriangle = new PaperTriangle
        {
            Id = 2,
            Side1 = 100,
            Side2 = 100,
            Side3 = 100,
            Color = Colors.Blue,
        };
        private static readonly PaperCircle paperCircle = new PaperCircle
        {
            Id = 3,
            Radius = 50,
            Color = Colors.Blue,
        };
        private const double SIDE = 100;

        [Fact]
        public void CreatePaperTriangle_IfArgumentsAreValid_ShouldReturnInstance()
        {
            // Arrange - Act
            PaperTriangle triangle = new PaperTriangle(SIDE, SIDE, SIDE) { Color = Colors.Blue, };

            // Assert
            triangle.Should().NotBeNull().And.Be(paperTriangle);
        }

        [Fact]
        public void CreatePaperTriangle_IfArgumentsAreNotValid_ShouldThrowArgumentOutUfRangeException()
        {
            // Arrange - Act
            Action action1 = () => new PaperTriangle(SIDE, -SIDE, SIDE);
            Action action2 = () => new PaperTriangle(0, SIDE, SIDE);
            Action action3 = () => new PaperTriangle(SIDE, SIDE, -SIDE);
            Action action4 = () => new PaperTriangle
            {
                Id = -1,
                Side1 = SIDE,
                Side2 = SIDE,
                Side3 = SIDE,
            };

            // Assert
            action1.Should().Throw<ArgumentOutOfRangeException>();
            action2.Should().Throw<ArgumentOutOfRangeException>();
            action3.Should().Throw<ArgumentOutOfRangeException>();
            action4.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void CreatePaperTriangleFromParentShape_IfParentShapeIsLarger_ShouldReturnFilmRectangle()
        {
            // Arrange - Act
            PaperTriangle triangle1 = new PaperTriangle(paperCircle, SIDE, SIDE, SIDE);
            PaperTriangle triangle2 = new PaperTriangle(paperRectangle, SIDE, SIDE, SIDE);
            PaperTriangle triangle3 = new PaperTriangle(paperTriangle, SIDE / 10, SIDE / 10, SIDE / 10);

            // Assert
            triangle1.Should().NotBeNull().And.BeOfType(typeof(PaperTriangle));
            triangle2.Should().NotBeNull().And.BeOfType(typeof(PaperTriangle));
            triangle3.Should().NotBeNull().And.BeOfType(typeof(PaperTriangle));
        }

        [Fact]
        public void CreatePaperTriangleFromParentShape_IfParentShapeIsSmaller_ShouldReturnFilmRectangle()
        {
            // Arrange - Act
            Action action1 = () => new PaperTriangle(paperTriangle, SIDE * 10, SIDE * 10, SIDE * 10);
            Action action2 = () => new PaperTriangle(paperRectangle, SIDE * 10, SIDE * 10, SIDE * 10);
            Action action3 = () => new PaperTriangle(paperCircle, SIDE * 10, SIDE * 10, SIDE * 10);

            // Assert
            action1.Should().Throw<Exception>().WithMessage("*be less*");
            action2.Should().Throw<Exception>().WithMessage("*be less*");
            action3.Should().Throw<Exception>().WithMessage("*be less*");
        }

        [Fact]
        public void GetPerimeter_IfTriangleIsValid_ShouldReturnCorrectResult()
        {
            // Arrange - Act
            double perimeter = paperTriangle.Side1 + paperTriangle.Side2 + paperTriangle.Side3;

            // Assert
            paperTriangle.GetPerimeter().Should().Be(perimeter);
        }

        [Fact]
        public void GetArea_IfTriangleIsValid_ShouldReturnCorrectResult()
        {
            // Arrange - Act
            double p = (paperTriangle.Side1 + paperTriangle.Side2 + paperTriangle.Side3) / 2;
            double area = Math.Sqrt(p * (p - paperTriangle.Side1) * (p - paperTriangle.Side2) * (p - paperTriangle.Side3));

            // Assert
            paperTriangle.GetArea().Should().Be(area);
        }

        [Fact]
        public void Equals_IfArgumentIsValid_ShouldReturnCorrectResult()
        {
            // Arrange - Act
            PaperTriangle equalTriangle = new PaperTriangle
            {
                Side1 = paperTriangle.Side1,
                Side2 = paperTriangle.Side2,
                Side3 = paperTriangle.Side3,
                Color = paperTriangle.Color,
            };
            PaperTriangle sameTriangle = equalTriangle;
            PaperTriangle inequalTriangle = new PaperTriangle
            {
                Side1 = paperTriangle.Side1 - 1,
                Side2 = paperTriangle.Side2,
                Side3 = paperTriangle.Side3,
                Color = paperTriangle.Color,
            };
            PaperTriangle nullTriangle = null;

            // Assert
            paperTriangle.Equals(equalTriangle).Should().BeTrue();
            paperTriangle.Equals(inequalTriangle).Should().BeFalse();
            equalTriangle.Equals(sameTriangle).Should().BeTrue();
            paperTriangle.Equals(nullTriangle).Should().BeFalse();
            paperTriangle.Equals(paperCircle).Should().BeFalse();
        }

        [Fact]
        public void Equals_IfCurrentObjectIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            PaperTriangle rectangle = null;

            // Act
            Action action = () => rectangle.Equals(paperTriangle);

            // Assert
            action.Should().Throw<NullReferenceException>();
        }
    }
}
