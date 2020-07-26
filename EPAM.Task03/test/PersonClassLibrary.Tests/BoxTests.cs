using FluentAssertions;
using ShapeClassLibrary;
using System;
using Xunit;

namespace PersonClassLibrary.Tests
{
    public class BoxTests
    {
        const int MAX_CAPACITY = 20;

        [Fact]
        public void PushShape_IfShapeIsNotNull_ListOfShapesShouldNotBeEmpty()
        {
            // Arrange
            Box box = new Box();
            Shape shape = new PaperCircle { Id = 1, Radius = 10, Color = Colors.Blue };

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
        public void PushShape_IfBoxIsFull_ShoulThrowException()
        {
            // Arrange
            Box box = new Box();
            Shape shape = new PaperRectangle { Id = 1, Height = 10, Width = 12.1, Color = Colors.Green, };
            for(int i = 0; i < MAX_CAPACITY; i++)
            {
                box.PushShape(shape);
            }

            // Act
            Action action = () => box.PushShape(shape);

            // Assert
            action.Should().Throw<Exception>().WithMessage("*full*");
        }

        [Fact]
        public void FindById_IfBoxContainsTargetShape_ShoulReturnShape()
        {
            // Arrenge - Act
            Box box = new Box();
            Shape shape = new PaperTriangle { Id = 31, Side1 = 10, Side2 = 10, Side3 = 10, Color = Colors.White };
            box.PushShape(shape);

            // Assert
            box.FindById(31).Should().Be(shape);
        }
    }
}
