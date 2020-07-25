using FluentAssertions;
using ShapeClassLibrary;
using System;
using Xunit;

namespace PersonClassLibrary.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Scissors scissors = new Scissors();
            SheetOfPaper sheetOfPaper = new SheetOfPaper();
            double[] parameters = { 10, 10, 10, };
            PaperTriangle paperTriangle = (PaperTriangle)scissors.Cut(sheetOfPaper, parameters);
            Person person = new Person();
            PaperTriangle expected = new PaperTriangle { Side1 = 10, Side2 = 10, Side3 = 10, Color = Colors.Red };

            person.SetColor(Colors.Red);
            PaperTriangle coloredTriangle = (PaperTriangle)person.ColorShape(paperTriangle);

            coloredTriangle.Should().Be(expected);
        }
    }
}
