using FluentAssertions;
using ShapeClassLibrary;
using System;
using Xunit;

namespace PersonClassLibrary.Tests
{
    public class PersonTests
    {
        private static readonly FilmCircle filmCircle = new FilmCircle
        {
            Id = 1,
            Radius = 100.5,
        };
        private static readonly FilmRectangle filmRectangle = new FilmRectangle
        {
            Id = 1,
            Height = 100,
            Width = 320,
        };
        private static readonly FilmTriangle filmTriangle = new FilmTriangle
        {
            Id = 2,
            Side1 = 300.7,
            Side2 = 300.7,
            Side3 = 300.7,
        };
        private const double RADIUS = 100.5;
        private const double HEIGHT = 100;
        private const double WIDTH = 320;
        private const double SIDE = 300.7;

        [Fact]
        public void CreatePerson_ShouldReturnNewPerson()
        {
            // Arrange - Act
            Person person = new Person();

            // Assert
            person.Should().NotBeNull();
        }

        [Fact]
        public void CreatePerson_IfColorIsNotSet_ColorShouldBeNone()
        {
            // Arrange - Act
            Person person = new Person();

            // Assert
            person.Color.Should().Be(Colors.None);
        }

        [Fact]
        public void ColorShape_IfShapeIsValid_ShouldReturnColoredShape()
        {
            // Arrange
            Person person = new Person();
            person.SetColor(Colors.Green);
            PaperCircle paperCircle = new PaperCircle { Radius = RADIUS, };
            PaperRectangle paperRectangle = new PaperRectangle
            {
                Height = HEIGHT,
                Width = WIDTH,
            };
            PaperTriangle paperTriangle = new PaperTriangle
            {
                Side1 = SIDE,
                Side2 = SIDE,
                Side3 = SIDE,
            };
            PaperCircle expectedCircle = new PaperCircle { Radius = RADIUS, Color = Colors.Green, };
            PaperRectangle expectedRectangle = new PaperRectangle
            {
                Height = HEIGHT,
                Width = WIDTH,
                Color = Colors.Green,
            };
            PaperTriangle expectedTriangle = new PaperTriangle
            {
                Side1 = SIDE,
                Side2 = SIDE,
                Side3 = SIDE,
                Color = Colors.Green,
            };

            // Act
            Shape coloredShape1 = person.ColorShape(paperCircle);
            Shape coloredShape2 = person.ColorShape(paperRectangle);
            Shape coloredShape3 = person.ColorShape(paperTriangle);

            // Assert
            coloredShape1.Should().NotBeNull().And.Be(expectedCircle);
            coloredShape2.Should().NotBeNull().And.Be(expectedRectangle);
            coloredShape3.Should().NotBeNull().And.Be(expectedTriangle);
        }

        [Fact]
        public void ColorShape_IfShapeIsAlreadyColored_ShouldThrowException()
        {
            // Arrange
            Person person = new Person();
            person.SetColor(Colors.Green);
            PaperCircle paperCircle = new PaperCircle { Radius = RADIUS, Color = Colors.Green, };

            // Act
            Action action = () => person.ColorShape(paperCircle);

            // Assert
            action.Should().Throw<Exception>().WithMessage("*colored*");
        }

        [Fact]
        public void ColorShape_IfShapeIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            Person person = new Person();
            person.SetColor(Colors.Green);
            PaperCircle paperCircle = null;

            // Act
            Action action = () => person.ColorShape(paperCircle);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ColorShape_IfShapeIsOfFilm_ShouldThrowArgumentException()
        {
            // Arrange
            Person person = new Person();
            person.SetColor(Colors.Green);

            // Act
            Action action1 = () => person.ColorShape(filmCircle);
            Action action2 = () => person.ColorShape(filmRectangle);
            Action action3 = () => person.ColorShape(filmTriangle);

            // Assert
            action1.Should().Throw<ArgumentException>("*colored*");
            action2.Should().Throw<ArgumentException>("*colored*");
            action3.Should().Throw<ArgumentException>("*colored*");
        }
    }
}
