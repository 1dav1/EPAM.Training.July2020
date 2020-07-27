using FluentAssertions;
using System;
using Xunit;

namespace ShapeClassLibrary.Tests
{
    public class FilmCircleTests
    {
        private static readonly FilmCircle filmCircle = new FilmCircle { Id = 1, Radius = 100, };
        private static readonly FilmRectangle filmRectangle = new FilmRectangle { Id = 1, Height = 100, Width = 320, };
        private static readonly FilmTriangle filmTriangle = new FilmTriangle { Id = 2, Side1 = 300, Side2 = 300, Side3 = 300, };

        [Fact]
        public void CreateFilmCircle_IfArgumentsAreValid_ShouldReturnInstance()
        {
            // Arrange - Act
            FilmCircle circle = new FilmCircle(100);

            // Assert
            circle.Should().NotBeNull().And.Be(filmCircle);
        }

        [Fact]
        public void CreateFilmCircle_IfArgumentsAreNotValid_ShouldThrowArgumentOutUfRangeException()
        {
            // Arrange - Act
            Action action1 = () => new FilmCircle(-101);
            Action action2 = () => new FilmCircle(0);
            Action action3 = () => new FilmCircle { Id = -1, Radius = 100, };

            // Assert
            action1.Should().Throw<ArgumentOutOfRangeException>();
            action2.Should().Throw<ArgumentOutOfRangeException>();
            action3.Should().Throw<ArgumentOutOfRangeException>();
        }


        [Fact]
        public void CreateCircleFromParentShape_IfParentShapeIsLarger_ShouldReturnCircle()
        {
            // Arrange - Act
            FilmCircle circle1 = new FilmCircle(filmCircle, 90);
            FilmCircle circle2 = new FilmCircle(filmRectangle, 90);
            FilmCircle circle3 = new FilmCircle(filmTriangle, 90);

            FilmCircle expected = new FilmCircle { Radius = 90, };

            // Assert
            circle1.Should().NotBeNull().And.Be(expected);
            circle2.Should().NotBeNull().And.Be(expected);
            circle3.Should().NotBeNull().And.Be(expected);
        }

        [Fact]
        public void CreateCircleFromParentShape_IfParentShapeIsSmaller_ShouldReturnCircle()
        {
            // Arrange - Act
            Action action = () => new FilmCircle(filmCircle, 101);

            // Assert
            action.Should().Throw<Exception>().WithMessage("*be less*");
        }

        [Fact]
        public void GetPerimeter_IfCircleIsValid_ShouldReturnCorrectResult()
        {
            // Arrange - Act
            double perimeter = 2 * Math.PI * filmCircle.Radius;

            // Assert
            filmCircle.GetPerimeter().Should().Be(perimeter);
        }

        [Fact]
        public void GetArea_IfCircleIsValid_ShouldReturnCorrectResult()
        {
            // Arrange - Act
            double area = Math.PI * Math.Pow(filmCircle.Radius, 2);

            // Assert
            filmCircle.GetArea().Should().Be(area);
        }

        [Fact]
        public void Equals_IfArgumentIsValid_ShouldReturnCorrectResult()
        {
            // Arrange - Act
            FilmCircle equalCircle = new FilmCircle { Radius = 100, };
            FilmCircle sameCircle = equalCircle;
            FilmCircle inequalCircle = new FilmCircle { Radius = 101, };
            FilmCircle nullCircle = null;

            // Assert
            filmCircle.Equals(equalCircle).Should().BeTrue();
            filmCircle.Equals(inequalCircle).Should().BeFalse();
            equalCircle.Equals(sameCircle).Should().BeTrue();
            filmCircle.Equals(nullCircle).Should().BeFalse();
        }

        [Fact]
        public void Equals_IfCurrentObjectIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            FilmCircle circle = null;

            // Act
            Action action = () => circle.Equals(filmCircle);

            // Assert
            action.Should().Throw<NullReferenceException>();
        }
    }
}
