using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShapeClassLibrary.Tests
{
    public class FilmTriangleTests
    {
        private static readonly FilmRectangle filmRectangle = new FilmRectangle
        {
            Id = 1,
            Height = 100,
            Width = 120,
        };
        private static readonly FilmTriangle filmTriangle = new FilmTriangle
        {
            Id = 2,
            Side1 = 100,
            Side2 = 100,
            Side3 = 100,
        };
        private static readonly FilmCircle filmCircle = new FilmCircle { Id = 3, Radius = 50, };
        private const double SIDE = 100;

        [Fact]
        public void CreateFilmTriangle_IfArgumentsAreValid_ShouldReturnInstance()
        {
            // Arrange - Act
            FilmTriangle triangle = new FilmTriangle(SIDE, SIDE, SIDE);

            // Assert
            triangle.Should().NotBeNull().And.Be(filmTriangle);
        }

        [Fact]
        public void CreateFilmTriangle_IfArgumentsAreNotValid_ShouldThrowArgumentOutUfRangeException()
        {
            // Arrange - Act
            Action action1 = () => new FilmTriangle(SIDE, -SIDE, SIDE);
            Action action2 = () => new FilmTriangle(0, SIDE, SIDE);
            Action action3 = () => new FilmTriangle(SIDE, SIDE, -SIDE);
            Action action4 = () => new FilmTriangle
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
        public void CreateFilmTriangleFromParentShape_IfParentShapeIsLarger_ShouldReturnFilmRectangle()
        {
            // Arrange - Act
            FilmTriangle triangle1 = new FilmTriangle(filmCircle, SIDE, SIDE, SIDE);
            FilmTriangle triangle2 = new FilmTriangle(filmRectangle, SIDE, SIDE, SIDE);
            FilmTriangle triangle3 = new FilmTriangle(filmTriangle, SIDE / 10, SIDE / 10, SIDE / 10);

            // Assert
            triangle1.Should().NotBeNull().And.BeOfType(typeof(FilmTriangle));
            triangle2.Should().NotBeNull().And.BeOfType(typeof(FilmTriangle));
            triangle3.Should().NotBeNull().And.BeOfType(typeof(FilmTriangle));
        }

        [Fact]
        public void CreateFilmTriangleFromParentShape_IfParentShapeIsSmaller_ShouldReturnFilmRectangle()
        {
            // Arrange - Act
            Action action1 = () => new FilmTriangle(filmTriangle, SIDE * 10, SIDE * 10, SIDE * 10);
            Action action2 = () => new FilmTriangle(filmRectangle, SIDE * 10, SIDE * 10, SIDE * 10);
            Action action3 = () => new FilmTriangle(filmCircle, SIDE * 10, SIDE * 10, SIDE * 10);

            // Assert
            action1.Should().Throw<Exception>().WithMessage("*be less*");
            action2.Should().Throw<Exception>().WithMessage("*be less*");
            action3.Should().Throw<Exception>().WithMessage("*be less*");
        }

        [Fact]
        public void GetPerimeter_IfTriangleIsValid_ShouldReturnCorrectResult()
        {
            // Arrange - Act
            double perimeter = filmTriangle.Side1 + filmTriangle.Side2 + filmTriangle.Side3;

            // Assert
            filmTriangle.GetPerimeter().Should().Be(perimeter);
        }

        [Fact]
        public void GetArea_IfTriangleIsValid_ShouldReturnCorrectResult()
        {
            // Arrange - Act
            double p = (filmTriangle.Side1 + filmTriangle.Side2 + filmTriangle.Side3) / 2;
            double area = Math.Sqrt(p * (p - filmTriangle.Side1) * (p - filmTriangle.Side2) * (p - filmTriangle.Side3));

            // Assert
            filmTriangle.GetArea().Should().Be(area);
        }

        [Fact]
        public void Equals_IfArgumentIsValid_ShouldReturnCorrectResult()
        {
            // Arrange - Act
            FilmTriangle equalTriangle = new FilmTriangle
            {
                Side1 = filmTriangle.Side1,
                Side2 = filmTriangle.Side2,
                Side3 = filmTriangle.Side3,
            };
            FilmTriangle sameTriangle = equalTriangle;
            FilmTriangle inequalTriangle = new FilmTriangle
            {
                Side1 = filmTriangle.Side1 - 1,
                Side2 = filmTriangle.Side2,
                Side3 = filmTriangle.Side3,
            };
            FilmTriangle nullTriangle = null;

            // Assert
            filmTriangle.Equals(equalTriangle).Should().BeTrue();
            filmTriangle.Equals(inequalTriangle).Should().BeFalse();
            equalTriangle.Equals(sameTriangle).Should().BeTrue();
            filmTriangle.Equals(nullTriangle).Should().BeFalse();
            filmTriangle.Equals(filmCircle).Should().BeFalse();
        }

        [Fact]
        public void Equals_IfCurrentObjectIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            FilmTriangle rectangle = null;

            // Act
            Action action = () => rectangle.Equals(filmTriangle);

            // Assert
            action.Should().Throw<NullReferenceException>();
        }

    }
}
