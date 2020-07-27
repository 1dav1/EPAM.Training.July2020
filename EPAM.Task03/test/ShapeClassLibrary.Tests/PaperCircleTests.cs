using FluentAssertions;
using System;
using Xunit;

namespace ShapeClassLibrary.Tests
{
    public class PaperCircleTests
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
            Width = 320,
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

        [Fact]
        public void CreatePaperCircle_IfArgumentsAreValid_ShouldReturnInstance()
        {
            // Arrange - Act
            PaperCircle circle = new PaperCircle(100);
            circle.Color = paperCircle.Color;

            // Assert
            circle.Should().NotBeNull().And.Be(paperCircle);
        }

        [Fact]
        public void CreatePaperCircle_IfArgumentsAreNotValid_ShouldThrowArgumentOutUfRangeException()
        {
            // Arrange - Act
            Action action1 = () => new PaperCircle(-101);
            Action action2 = () => new PaperCircle(0);
            Action action3 = () => new PaperCircle { Id = -1, Radius = 100, };

            // Assert
            action1.Should().Throw<ArgumentOutOfRangeException>();
            action2.Should().Throw<ArgumentOutOfRangeException>();
            action3.Should().Throw<ArgumentOutOfRangeException>();
        }


        [Fact]
        public void CreateCircleFromParentShape_IfParentShapeIsLarger_ShouldReturnCircle()
        {
            // Arrange - Act
            PaperCircle circle1 = new PaperCircle(paperCircle, 90);
            PaperCircle circle2 = new PaperCircle(paperRectangle, 90);
            PaperCircle circle3 = new PaperCircle(paperTriangle, 90);

            PaperCircle expected = new PaperCircle { Radius = 90, Color = Colors.Green };

            // Assert
            circle1.Should().NotBeNull().And.Be(expected);
            circle2.Should().NotBeNull().And.Be(expected);
            circle3.Should().NotBeNull().And.Be(expected);
        }

        [Fact]
        public void CreateCircleFromParentShape_IfParentShapeIsSmaller_ShouldReturnCircle()
        {
            // Arrange - Act
            Action action = () => new PaperCircle(paperCircle, 101);

            // Assert
            action.Should().Throw<Exception>().WithMessage("*be less*");
        }

        [Fact]
        public void GetPerimeter_IfCircleIsValid_ShouldReturnCorrectResult()
        {
            // Arrange - Act
            double perimeter = 2 * Math.PI * paperCircle.Radius;

            // Assert
            paperCircle.GetPerimeter().Should().Be(perimeter);
        }

        [Fact]
        public void GetArea_IfCircleIsValid_ShouldReturnCorrectResult()
        {
            // Arrange - Act
            double area = Math.PI * Math.Pow(paperCircle.Radius, 2);

            // Assert
            paperCircle.GetArea().Should().Be(area);
        }

        [Fact]
        public void Equals_IfArgumentIsValid_ShouldReturnCorrectResult()
        {
            // Arrange - Act
            PaperCircle equalCircle = new PaperCircle { Radius = 100, Color = Colors.Green, };
            PaperCircle sameCircle = equalCircle;
            PaperCircle inequalCircle = new PaperCircle { Radius = 101, };
            PaperCircle nullCircle = null;

            // Assert
            paperCircle.Equals(equalCircle).Should().BeTrue();
            paperCircle.Equals(inequalCircle).Should().BeFalse();
            equalCircle.Equals(sameCircle).Should().BeTrue();
            paperCircle.Equals(nullCircle).Should().BeFalse();
            paperCircle.Equals(paperRectangle).Should().BeFalse();
        }

        [Fact]
        public void Equals_IfCurrentObjectIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            FilmCircle circle = null;

            // Act
            Action action = () => circle.Equals(paperCircle);

            // Assert
            action.Should().Throw<NullReferenceException>();
        }
    }
}
