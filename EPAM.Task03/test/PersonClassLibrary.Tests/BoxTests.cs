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
        const string FILE = "test.xml";

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

        [Fact]
        public void FindByTemplate_IfCollectionContainsTargetShape_ShouldReturnShape()
        {
            // Arrange
            Box box = new Box();
            box.PushShape(paperTriangle);
            box.PushShape(filmRectangle);
            box.PushShape(paperCircle);

            Shape template = paperTriangle;

            // Act
            List<Shape> shapes = (List<Shape>)box.FindByTemplate(template);

            // Assert
            shapes.Should().NotBeEmpty();
            shapes[0].Should().Be(template);
        }

        [Fact]
        public void FindByTemplate_IfCollectionDoesNotContainTargetShape_ResultShouldBeEmpty()
        {
            // Arrange
            Box box = new Box();
            box.PushShape(paperTriangle);
            box.PushShape(filmRectangle);
            box.PushShape(paperCircle);

            Shape template = new FilmCircle { Id = 11, Radius = 1, };

            // Act
            List<Shape> shapes = (List<Shape>)box.FindByTemplate(template);

            // Assert
            shapes.Should().BeEmpty();
        }

        [Fact]
        public void Count_ShouldReturnNumberOfShapesInBox()
        {
            // Arrange - Act
            Box box = new Box();
            box.PushShape(paperTriangle);
            box.PushShape(filmRectangle);
            box.PushShape(paperCircle);

            Box zeroBox = new Box();

            // Assert
            box.Count().Should().Be(3);
            zeroBox.Count().Should().Be(0);
        }

        [Fact]
        public void GetTotalArea_ShouldReturnCorrectResult()
        {
            // Arrange - Act
            Box box = new Box();
            PaperTriangle triangle = (PaperTriangle)paperTriangle;
            FilmRectangle rectangle = (FilmRectangle)filmRectangle;
            PaperCircle circle = (PaperCircle)paperCircle;

            box.PushShape(paperTriangle);
            box.PushShape(filmRectangle);
            box.PushShape(paperCircle);

            double p = (triangle.Side1 + triangle.Side2 + triangle.Side3) / 2;
            double triangleArea = Math.Sqrt(p * (p - triangle.Side1) * (p - triangle.Side2) * (p - triangle.Side3));
            double rectangleArea = rectangle.Height * rectangle.Width;
            double circleArea = Math.PI * Math.Pow(circle.Radius, 2);

            Box zeroBox = new Box();

            // Assert
            box.GetTotalArea().Should().Be(triangleArea + rectangleArea + circleArea);
            zeroBox.GetTotalArea().Should().Be(0);
        }

        [Fact]
        public void GetTotalPerimeter_ShouldReturnCorrectResult()
        {
            // Arrange - Act
            Box box = new Box();
            PaperTriangle triangle = (PaperTriangle)paperTriangle;
            FilmRectangle rectangle = (FilmRectangle)filmRectangle;
            PaperCircle circle = (PaperCircle)paperCircle;

            box.PushShape(paperTriangle);
            box.PushShape(filmRectangle);
            box.PushShape(paperCircle);

            double trianglePerimeter = triangle.Side1 + triangle.Side2 + triangle.Side3;
            double rectanglePerimeter = (rectangle.Height + rectangle.Width) * 2;
            double circumference = 2 * Math.PI * circle.Radius;

            Box zeroBox = new Box();

            // Assert
            box.GetTotalPerimeter().Should().Be(trianglePerimeter + rectanglePerimeter + circumference);
            zeroBox.GetTotalPerimeter().Should().Be(0);
        }

        [Fact]
        public void PullCircles_IfBoxContainsCircles_ShouldReturnCircles()
        {
            // Arrange
            Box box = new Box();
            box.PushShape(paperTriangle);
            box.PushShape(filmCircle);
            box.PushShape(paperRectangle);

            // Act
            List<Shape> shapes = (List<Shape>)box.PullCircles();
            Shape circleInBox = box.Shapes.ToList().Find(c => c.Id == filmCircle.Id);

            // Assert
            shapes.Should().NotBeEmpty();
            shapes[0].Should().Be(filmCircle);
            circleInBox.Should().BeNull();
        }

        [Fact]
        public void PullCircles_IfBoxDoesNotContainCircles_ShouldReturnEmptyResult()
        {
            // Arrange
            Box box = new Box();
            box.PushShape(paperTriangle);
            box.PushShape(filmRectangle);
            box.PushShape(paperRectangle);

            // Act
            List<Shape> shapes = (List<Shape>)box.PullCircles();

            // Assert
            shapes.Should().BeEmpty();
        }

        [Fact]
        public void PullFilmShapes_IfBoxContainsShapesOfFilm_ShouldReturnShapesOfFilm()
        {
            // Arrange
            Box box = new Box();
            box.PushShape(paperTriangle);
            box.PushShape(filmRectangle);
            box.PushShape(paperRectangle);

            // Act
            List<Shape> shapes = (List<Shape>)box.PullFilmShapes();
            Shape filmInBox = box.Shapes.ToList().Find(c => c.Id == filmRectangle.Id);

            // Assert
            shapes.Should().NotBeEmpty();
            shapes[0].Should().Be(filmRectangle);
            filmInBox.Should().BeNull();
        }

        [Fact]
        public void PullFilmShapes_IfBoxDoesNotContainShapesOfFilm_ShouldReturnEmptyResult()
        {
            // Arrange
            Box box = new Box();
            box.PushShape(paperTriangle);
            box.PushShape(paperCircle);
            box.PushShape(paperRectangle);

            // Act
            List<Shape> shapes = (List<Shape>)box.PullFilmShapes();

            // Assert
            shapes.Should().BeEmpty();
        }

        [Fact]
        public void WriteAllToXmlStreamWriter_IfFileNameIsNotNull_ShouldWriteToXml()
        {
            // Arrange
            Box box = new Box();
            box.PushShape(paperTriangle);
            Box readBox = new Box();

            // Act
            box.WriteAllToXmlStreamWriter(FILE);
            readBox.ReadAllFromXmlXmlReader(FILE);

            // Assert
            readBox.Shapes.ToList()[0].Should().Be(paperTriangle);
        }

        [Fact]
        public void WritePaperToXmlStreamWriter_IfFileNameIsNotNull_ShouldWriteToXml()
        {
            // Arrange
            Box box = new Box();
            box.PushShape(paperTriangle);
            box.PushShape(filmTriangle);
            box.PushShape(paperCircle);
            Box readBox = new Box();

            // Act
            box.WritePaperToXmlStreamWriter(FILE);
            readBox.ReadAllFromXmlXmlReader(FILE);

            // Assert
            readBox.Shapes.ToList()[0].Should().Be(paperTriangle);
        }

        [Fact]
        public void WriteAllToXmlXmlWriter_IfFileNameIsNotNull_ShouldWriteToXml()
        {
            // Arrange
            Box box = new Box();
            box.PushShape(paperTriangle);
            Box readBox = new Box();

            // Act
            box.WriteAllToXmlXmlWriter(FILE);
            readBox.ReadAllFromXmlStreamReader(FILE);

            // Assert
            readBox.Shapes.ToList()[0].Should().Be(paperTriangle);
        }
    }
}
