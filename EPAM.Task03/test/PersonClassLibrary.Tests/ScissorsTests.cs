using FluentAssertions;
using ShapeClassLibrary;
using System;
using Xunit;

namespace PersonClassLibrary.Tests
{
    public class ScissorsTests
    {
        private static readonly Shape paperCircle = new PaperCircle { Id = 3, Radius = 12.1, };
        private static readonly Shape paperTriangle = new PaperTriangle { Id = 31, Side1 = 10, Side2 = 10, Side3 = 10, };
        private static readonly Shape paperRectangle = new PaperRectangle { Id = 10, Height = 10, Width = 12.1, };
        private static readonly Shape filmCircle = new FilmCircle { Id = 1, Radius = 100, };
        private static readonly Shape filmRectangle = new FilmRectangle { Id = 12, Height = 300, Width = 700, };
        private static readonly Shape filmTriangle = new FilmTriangle { Id = 5, Side1 = 15, Side2 = 15, Side3 = 15, };
        private static readonly SheetOfPaper paper = new SheetOfPaper();
        private static readonly SheetOfFilm film = new SheetOfFilm();

        [Fact]
        public void CutFromPaper_IfArgumentsAreValid_ShouldReturnShape()
        {
            // Arrange
            Scissors scissors = new Scissors();

            // Act
            Shape shape = scissors.Cut(paper, 12.1);

            // Assert
            shape.Should().Be(paperCircle);
        }

        [Fact]
        public void CutFromPaper_IfArgumentIsNull_ShouldThrowException()
        {
            // Arrange
            Scissors scissors = new Scissors();
            SheetOfPaper paper = null;

            // Act
            Action action = () => scissors.Cut(paper, 12.1);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CutFromFilm_IfArgumentsAreValid_ShouldReturnShape()
        {
            // Arrange
            Scissors scissors = new Scissors();

            // Act
            Shape shape = scissors.Cut(film, 100);

            // Assert
            shape.Should().Be(filmCircle);
        }

        [Fact]
        public void CutFromFilm_IfArgumentIsNull_ShouldThrowException()
        {
            // Arrange
            Scissors scissors = new Scissors();
            SheetOfFilm film = null;

            // Act
            Action action = () => scissors.Cut(film, 100);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CutFromShape_IfArgumentsAreValid_ShouldReturnShape()
        {
            // Arrange
            Scissors scissors = new Scissors();
            PaperRectangle rectangle = new PaperRectangle { Height = 9, Width = 10, };

            // Act
            Shape shape = scissors.Cut(paperRectangle, 9, 10);

            // Assert
            shape.Should().Be(rectangle);
        }

        [Fact]
        public void CutFromShape_IfArgumentIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            Scissors scissors = new Scissors();
            Shape nullShape = null;

            // Act
            Action action = () => scissors.Cut(nullShape, 9, 10);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }
    }
}
