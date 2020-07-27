using FluentAssertions;
using System;
using Xunit;

namespace ShapeClassLibrary.Tests
{
    public class FilmRectangleTests
    {
        private static readonly FilmRectangle filmRectangle = new FilmRectangle { Id = 1, Height = 100, Width = 120, };
        private static readonly FilmTriangle filmTriangle = new FilmTriangle { Id = 2, Side1 = 100, Side2 = 100, Side3 = 100, };

        [Fact]
        public void CreateFilmRectangle_IfArgumentsAreValid_ShouldReturnInstance()
        {
            // Arrange - Act
            FilmRectangle filmRectangle = new FilmRectangle(100, 120);

            // Assert
            filmRectangle.Should().NotBeNull().And.Be(filmRectangle);
        }

        [Fact]
        public void CreateFilmRectangle_IfArgumentsAreNotValid_ShouldThrowArgumentOutUfRangeException()
        {
            // Arrange - Act
            Action action1 = () => new FilmRectangle(100, -101);
            Action action2 = () => new FilmRectangle(0, 100);
            Action action3 = () => new FilmRectangle 
            {
                Id = -1,
                Height = 100,
                Width = 130.5,
            };

            // Assert
            action1.Should().Throw<ArgumentOutOfRangeException>();
            action2.Should().Throw<ArgumentOutOfRangeException>();
            action3.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void CreateFilmRectengleFromParentShape_IfParentShapeIsLarger_ShouldReturnFilmRectangle()
        {
            // Arrange - Act
            FilmRectangle rectangle = new FilmRectangle(filmTriangle, 10, 100);

            // Assert
            rectangle.Should().NotBeNull().And.BeOfType(typeof(FilmRectangle));
        }

        [Fact]
        public void CreateFilmRectengleFromParentShape_IfParentShapeIsSmaller_ShouldReturnFilmRectangle()
        {
            // Arrange - Act
            Action action = () => new FilmRectangle(filmTriangle, 100, 101);

            // Assert
            action.Should().Throw<Exception>().WithMessage("*be less*");
        }

        [Fact]
        public void GetPerimeter_IfRectangleIsValid_ShouldReturnCorrectResult()
        {
            // Arrange - Act
            double perimeter = 2 * (filmRectangle.Height + filmRectangle.Width);

            // Assert
            filmRectangle.GetPerimeter().Should().Be(perimeter);
        }

        [Fact]
        public void GetArea_IfRectangleIsValid_ShouldReturnCorrectResult()
        {
            // Arrange - Act
            double area = filmRectangle.Height * filmRectangle.Width;

            // Assert
            filmRectangle.GetArea().Should().Be(area);
        }

        [Fact]
        public void Equals_IfArgumentIsValid_ShouldReturnCorrectResult()
        {
            // Arrange - Act
            FilmRectangle equalRectangle = new FilmRectangle { Height = filmRectangle.Height, Width = filmRectangle.Width, };
            FilmRectangle sameRectangle = equalRectangle;
            FilmRectangle inequalRectangle = new FilmRectangle { Height = filmRectangle.Height - 1, Width = filmRectangle.Width - 1 };
            FilmRectangle nullRectangle = null;
            FilmCircle circle = new FilmCircle { Id = 1, Radius = 20, };

            // Assert
            filmRectangle.Equals(equalRectangle).Should().BeTrue();
            filmRectangle.Equals(inequalRectangle).Should().BeFalse();
            equalRectangle.Equals(sameRectangle).Should().BeTrue();
            filmRectangle.Equals(nullRectangle).Should().BeFalse();
            filmRectangle.Equals(circle).Should().BeFalse();
        }

        [Fact]
        public void Equals_IfCurrentObjectIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            FilmRectangle rectangle = null;

            // Act
            Action action = () => rectangle.Equals(filmRectangle);

            // Assert
            action.Should().Throw<NullReferenceException>();
        }
    }
}
