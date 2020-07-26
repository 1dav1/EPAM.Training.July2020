using FluentAssertions;
using ShapeClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PersonClassLibrary.Tests
{
    public class BoxTests
    {
        const int MAX_CAPACITY = 20;

        readonly Shape paperCircle = new PaperCircle { Id = 3, Radius = 12.1, Color = Colors.Grey, };
        readonly Shape paperTriangle = new PaperTriangle { Id = 31, Side1 = 10, Side2 = 10, Side3 = 10, Color = Colors.White };
        readonly Shape paperRectangle = new PaperRectangle { Id = 10, Height = 10, Width = 12.1, Color = Colors.Green, };
        readonly Shape filmCircle = new FilmCircle { Id = 1, Radius = 100, };
        readonly Shape filmRectangle = new FilmRectangle { Id = 12, Height = 300, Width = 700, };
        readonly Shape filmTriangle = new FilmTriangle { Id = 5, Side1 = 15, Side2 = 15, Side3 = 15, };


        [Fact]
        public void PushShape_IfShapeIsNotNull_ListOfShapesShouldNotBeEmpty()
        {
            // Arrange
            Box box = new Box();
            Shape shape = paperCircle;

            // Act
            box.PushShape(shape);

            // Assert
            box.Shapes.Should().NotBeEmpty().And.HaveCount(1);

            //Scissors scissors = new Scissors();
            //SheetOfPaper sheetOfPaper = new SheetOfPaper();
            //double[] parameters = { 10, 10, 10, };
            //PaperTriangle paperTriangle = (PaperTriangle)scissors.Cut(sheetOfPaper, parameters);
            //Person person = new Person();
            //PaperTriangle expected = new PaperTriangle { Side1 = 10, Side2 = 10, Side3 = 10, Color = Colors.Red };

            //person.SetColor(Colors.Red);
            //PaperTriangle coloredTriangle = (PaperTriangle)person.ColorShape(paperTriangle);

            //coloredTriangle.Should().Be(expected);
        }

        [Fact]
        public void PushShape_IfShapeIsNull_ShoulThrowArgumentNullException()
        {
            // Arrange
            Box box = new Box();
            Shape shape = null;

            // Act
            Action action = () => box.PushShape(shape);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void PushShape_IfBoxIsFull_ShouldThrowException()
        {
            // Arrange
            Box box = new Box();
            Shape shape = null;
            for (int i = 0; i < MAX_CAPACITY; i++)
            {
                shape = new PaperRectangle { Id = i + 1, Height = 10, Width = 12.1, Color = Colors.Green, };
                box.PushShape(shape);
            }

            // Act
            Action action = () => box.PushShape(shape);

            // Assert
            action.Should().Throw<Exception>().WithMessage("*full*");
        }

        [Fact]
        public void PushShape_IfIdIsNotUnique_ShouldThrowException()
        {
            // Arrange
            Box box = new Box();
            Shape shape = paperTriangle;
            box.PushShape(shape);

            // Act
            Action action = () => box.PushShape(shape);

            // Assert
            action.Should().Throw<Exception>().WithMessage("*unique*");
        }

        [Fact]
        public void FindById_IfBoxContainsTargetShape_ShouldReturnShape()
        {
            // Arrenge - Act
            Box box = new Box();
            Shape shape = paperTriangle;
            box.PushShape(shape);

            // Assert
            box.FindById(paperTriangle.Id).Should().Be(shape);
        }

        [Fact]
        public void FindById_BoxDoesNotContainTargetShape_ShouldThrowException()
        {
            // Arrenge
            Box box = new Box();
            Shape shape = paperTriangle;
            box.PushShape(shape);

            // Act
            Action action = () => box.FindById(paperTriangle.Id - 1);

            // Assert
            action.Should().Throw<Exception>().WithMessage("*not found*");
        }

        [Fact]
        public void PullShapeById_IfArgumentIsNotNull_ShouldReturnShapeAndDeleteFromCollection()
        {
            // Arrenge - Act
            Box box = new Box();
            Shape shape = paperTriangle;
            box.PushShape(shape);

            // Assert
            box.PullShapeById(paperTriangle.Id).Should().Be(shape);
            box.Shapes.Should().BeEmpty();
        }

        [Fact]
        public void PullShapeById_IfNoTargetShapeInCollection_ShouldThrowException()
        {
            // Arrange
            Box box = new Box();
            Shape shape = paperTriangle;
            box.PushShape(shape);

            // Act
            Action action = () => box.PullShapeById(paperTriangle.Id - 1);

            // Assert
            action.Should().Throw<Exception>("*not found*");
        }

        [Fact]
        public void ReplaceById_IfArgumentIsNotNullAndCollectionContainsTargetShape_ShouldReplace()
        {
            // Arrange
            Box box = new Box();
            box.PushShape(paperTriangle);
            box.PushShape(filmRectangle);
            box.PushShape(paperCircle);
            Shape replacer = new FilmTriangle { Id = 2, Side1 = 10, Side2 = 10, Side3 = 10, };

            // Act
            box.ReplaceById(replacer, paperTriangle.Id);
            List<Shape> shapes = box.Shapes.ToList();

            // Assert
            shapes.Find(s => s.Id == paperTriangle.Id).Should().BeNull();
            shapes.Find(s => s.Id == replacer.Id).Should().Be(replacer);
        }

        [Fact]
        public void ReplaceById_IfCollectionDoesNotContainTargetShape_ShouldThrowException()
        {
            // Arrange
            Box box = new Box();
            box.PushShape(paperTriangle);
            box.PushShape(filmRectangle);
            box.PushShape(paperCircle);
            Shape replacer = new FilmTriangle { Id = 2, Side1 = 10, Side2 = 10, Side3 = 10, };

            // Act
            Action action = () => box.ReplaceById(replacer, paperTriangle.Id - 1);

            // Assert
            action.Should().Throw<Exception>().WithMessage("*not found*");
        }

        [Fact]
        public void ReplaceById_IfArgumentIsNull_ShouldThrowException()
        {
            // Arrange
            Box box = new Box();
            box.PushShape(paperTriangle);
            box.PushShape(filmRectangle);
            box.PushShape(paperCircle);
            Shape replacer = null;

            // Act
            Action action = () => box.ReplaceById(replacer, paperTriangle.Id);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }
    }
}
