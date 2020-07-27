using FluentAssertions;
using ShapeClassLibrary;
using System;
using Xunit;

namespace PersonClassLibrary.Tests
{
    public class ScissorsTests
    {
        private static readonly Shape paperCircle = new PaperCircle { Id = 3, Radius = 12.1, };
        private static readonly Shape paperRectangle = new PaperRectangle { Id = 10, Height = 10, Width = 12.1, };
        private static readonly Shape filmCircle = new FilmCircle { Id = 1, Radius = 100, };
        private static readonly SheetOfPaper paper = new SheetOfPaper();
        private static readonly SheetOfFilm film = new SheetOfFilm();

        [Fact]
        public void CutFromPaper_IfArgumentsAreValid_ShouldReturnShape()
        {
            // Arrange - Act

            Shape shape = Scissors.Cut(paper, 12.1);

            // Assert
            shape.Should().Be(paperCircle);
        }

        [Fact]
        public void CutFromPaper_IfArgumentIsNull_ShouldThrowException()
        {
            // Arrange
            SheetOfPaper paper = null;

            // Act
            Action action = () => Scissors.Cut(paper, 12.1);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CutFromFilm_IfArgumentsAreValid_ShouldReturnShape()
        {
            // Arrange - Act

            Shape shape = Scissors.Cut(film, 100);

            // Assert
            shape.Should().Be(filmCircle);
        }

        [Fact]
        public void CutFromFilm_IfArgumentIsNull_ShouldThrowException()
        {
            // Arrange
            SheetOfFilm film = null;

            // Act
            Action action = () => Scissors.Cut(film, 100);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CutFromShape_IfArgumentsAreValid_ShouldReturnShape()
        {
            // Arrange
            PaperRectangle rectangle = new PaperRectangle { Height = 9, Width = 10, };

            // Act
            Shape shape = Scissors.Cut(paperRectangle, 9, 10);

            // Assert
            shape.Should().Be(rectangle);
        }

        [Fact]
        public void CutFromShape_IfArgumentIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            Shape nullShape = null;

            // Act
            Action action = () => Scissors.Cut(nullShape, 9, 10);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }
    }
}
