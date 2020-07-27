using FluentAssertions;
using System;
using Xunit;

namespace ShapeClassLibrary.Tests
{
    public class PaperRectangleTests
    {
        private static readonly PaperCircle paperCircle = new PaperCircle
        {
            Id = 1,
            Radius = 100,
            Color = Colors.Green,
        };
        private static readonly PaperRectangle paperRectangle = new PaperRectangle
        {
            Id = 1,
            Height = 100,
            Width = 320.5,
            Color = Colors.Green,
        };
        private static readonly PaperTriangle paperTriangle = new PaperTriangle
        {
            Id = 2,
            Side1 = 300,
            Side2 = 300,
            Side3 = 300,
            Color = Colors.Green,
        };
        private const double HEIGHT = 100;
        private const double WIDTH = 320.5;

        [Fact]
        public void CreatePaperRectangle_IfArgumentsAreValid_ShouldReturnInstance()
        {
            // Arrange - Act
            PaperRectangle rectangle = new PaperRectangle(HEIGHT, WIDTH)
            {
                Color = paperRectangle.Color
            };

            // Assert
            rectangle.Should().NotBeNull().And.Be(paperRectangle);
        }

        [Fact]
        public void CreatePaperRectangle_IfArgumentsAreNotValid_ShouldThrowArgumentOutUfRangeException()
        {
            // Arrange - Act
            Action action1 = () => new PaperRectangle(HEIGHT, -WIDTH);
            Action action2 = () => new PaperRectangle(0, WIDTH);
            Action action3 = () => new PaperRectangle 
            {
                Id = -1, 
                Height = HEIGHT,
                Width = WIDTH,
            };

            // Assert
            action1.Should().Throw<ArgumentOutOfRangeException>();
            action2.Should().Throw<ArgumentOutOfRangeException>();
            action3.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void CreatePaperRectengleFromParentShape_IfParentShapeIsLarger_ShouldReturnFilmRectangle()
        {
            // Arrange - Act
            PaperRectangle rectangle1 = new PaperRectangle(paperCircle, HEIGHT / 10, WIDTH / 10);
            PaperRectangle rectangle2 = new PaperRectangle(paperRectangle, HEIGHT / 10, WIDTH / 10);
            PaperRectangle rectangle3 = new PaperRectangle(paperTriangle, HEIGHT / 10, WIDTH / 10);

            PaperRectangle expected = new PaperRectangle { Height = HEIGHT / 10, Width = WIDTH / 10, Color = Colors.Green, };

            // Assert
            rectangle1.Should().NotBeNull().And.Be(expected);
            rectangle2.Should().NotBeNull().And.Be(expected);
            rectangle3.Should().NotBeNull().And.Be(expected);
        }

        [Fact]
        public void CreatePaperRectengleFromParentShape_IfParentShapeIsSmaller_ShouldReturnFilmRectangle()
        {
            // Arrange - Act
            Action action = () => new PaperRectangle(paperTriangle, HEIGHT * 10, WIDTH * 10);

            // Assert
            action.Should().Throw<Exception>().WithMessage("*be less*");
        }

        [Fact]
        public void GetPerimeter_IfRectangleIsValid_ShouldReturnCorrectResult()
        {
            // Arrange - Act
            double perimeter = 2 * (paperRectangle.Height + paperRectangle.Width);

            // Assert
            paperRectangle.GetPerimeter().Should().Be(perimeter);
        }

        [Fact]
        public void GetArea_IfRectangleIsValid_ShouldReturnCorrectResult()
        {
            // Arrange - Act
            double area = paperRectangle.Height * paperRectangle.Width;

            // Assert
            paperRectangle.GetArea().Should().Be(area);
        }

        [Fact]
        public void Equals_IfArgumentIsValid_ShouldReturnCorrectResult()
        {
            // Arrange - Act
            PaperRectangle equalRectangle = new PaperRectangle
            {
                Height = paperRectangle.Height,
                Width = paperRectangle.Width,
                Color = paperRectangle.Color,
            };
            PaperRectangle sameRectangle = equalRectangle;
            PaperRectangle inequalRectangle = new PaperRectangle
            {
                Height = paperRectangle.Height - 1,
                Width = paperRectangle.Width - 1,
                Color = paperRectangle.Color,
            };
            PaperRectangle nullRectangle = null;

            // Assert
            paperRectangle.Equals(equalRectangle).Should().BeTrue();
            paperRectangle.Equals(inequalRectangle).Should().BeFalse();
            equalRectangle.Equals(sameRectangle).Should().BeTrue();
            paperRectangle.Equals(nullRectangle).Should().BeFalse();
            paperRectangle.Equals(paperCircle).Should().BeFalse();
        }

        [Fact]
        public void Equals_IfCurrentObjectIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            PaperRectangle rectangle = null;

            // Act
            Action action = () => rectangle.Equals(paperRectangle);

            // Assert
            action.Should().Throw<NullReferenceException>();
        }
    }
}
