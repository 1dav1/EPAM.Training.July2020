using FluentAssertions;
using System;
using Xunit;

namespace ShapeClassLibrary.Tests
{
    public class FilmCircleTests
    {
        private static readonly FilmCircle filmCircle = new FilmCircle { Id = 1, Radius = 100, };

        [Fact]
        public void CreateFilmCircle_IfArgumentsAreValid_ShouldReturnInstance()
        {
            // Arrange - Act
            FilmCircle circle = new FilmCircle(100);

            // Assert
            circle.Should().Be(filmCircle);
        }

        [Fact]
        public void CreateFilmCircle_IfExtraArguments_ShouldThrowArgumentException()
        {
            // Arrange - Act
            Action action = () => new FilmCircle(100, 100);

            // Assert
            action.Should().Throw<ArgumentException>().WithMessage("*too many*");
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
        public void CreateCircleFromParentShape_IfParentShapeIsLarger_ShouldReturnCircle()
        {
            // Arrange - Act
            FilmCircle circle = new FilmCircle(filmCircle, 90);
            FilmCircle expected = new FilmCircle { Radius = 90, };

            // Assert
            circle.Should().Be(expected);
        }
    }
}
