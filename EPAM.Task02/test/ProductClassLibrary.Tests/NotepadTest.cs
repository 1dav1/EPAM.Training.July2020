using FluentAssertions;
using System;
using Xunit;

namespace ProductClassLibrary.Tests
{
    public class NotepadTest
    {
        readonly string author = "TestAuthor1";
        readonly string name = "TestName1";
        readonly decimal price = 10.5m;
        readonly int numberOfPages = 1000;
        readonly double cpuFrequancy = 1600;
        const int KOPEK = 100;

        [Fact]
        public void CreateNotepad_WhenValuesAreValid_ShouldNotThrowExceptions()
        {
            // Arrange - Act
            Action action = () => new Notepad
            {
                Name = name,
                Price = price,
                NumberOfPages = numberOfPages
            };

            // Assert
            action.Should().NotThrow();
        }

        [Fact]
        public void CreateNotepad_WhenPriceIsNotValid_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange - Act
            Action action = () => new Notepad
            {
                Name = name,
                Price = -price,
                NumberOfPages = numberOfPages,
            };

            // Assert
            action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*price*");
        }

        [Fact]
        public void CreateNotepad_WhenNumberOfPagesIsNotValid_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange - Act
            Action action = () => new Notepad
            {
                Name = name,
                Price = price,
                NumberOfPages = -numberOfPages,
            };

            // Assert
            action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*number*");
        }

        [Theory]
        [InlineData("TestName1", 10.0, 1600, "TestName2", 200.1, 2000)]
        [InlineData("", 15.3, 1300, "TestName2", 200.1, 1000)]
        [InlineData("TestName1", 10.0, 1, "", 200.1, 1000)]
        public void AddOperatorNotepad_WhenOperandsAreValid_ShouldReturnCorrectResult1(string name1, decimal price1, int numberOfPages1,
                                                                                       string name2, decimal price2, int numberOfPages2)
        {
            // Arrange - Act
            Notepad notepad1 = new Notepad
            {
                Name = name1,
                Price = price1,
                NumberOfPages = numberOfPages1,
            };

            Notepad notepad2 = new Notepad
            {
                Name = name2,
                Price = price2,
                NumberOfPages = numberOfPages2,
            };

            Notepad expected = new Notepad
            {
                Name = name1 + "-" + name2,
                Price = (price1 + price2) / 2,
                NumberOfPages = numberOfPages1 + numberOfPages2,
            };

            // Assert
            (notepad1 + notepad2).Should().Be(expected);
        }

        [Fact]
        public void AddOperatorNotepad_WhenOperandIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            Notepad notepad1 = new Notepad
            {
                Name = name,
                Price = price,
                NumberOfPages = numberOfPages,
            };

            Notepad notepad2 = null;

            // Act
            Action action = () => { Notepad notepad = notepad1 + notepad2; };

            // Assert
            action.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void ConvertBookToNotepad_WhenOperandIsValid_ShouldReturnNewLaptop()
        {
            // Arrange
            Book book = new Book
            {
                Name = name,
                Price = price,
                Author = author,
                NumberOfPages = numberOfPages,
            };
            Notepad expected = new Notepad { Name = book.Name, Price = book.Price, NumberOfPages = numberOfPages, };

            // Act
            Notepad notepad = (Notepad)book;

            // Assert
            notepad.Should().Be(expected);
        }

        [Fact]
        public void ConvertBookToNotepad_WhenOperandIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            Book book = null;

            // Act
            Action action = () => { Notepad expected = (Notepad)book; };

            // Assert
            action.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void ConvertLaptopToNotepad_WhenOperandIsValid_ShouldReturnNewLaptop()
        {
            // Arrange
            Laptop laptop = new Laptop
            {
                Name = name,
                Price = price,
                CPUFrequancy = cpuFrequancy,
            };
            Notepad expected = new Notepad { Name = laptop.Name, Price = laptop.Price, NumberOfPages = 0, };

            // Act
            Notepad notepad = (Notepad)laptop;

            // Assert
            notepad.Should().Be(expected);
        }

        [Fact]
        public void ConvertLaptopToNotepad_WhenOperandIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            Laptop laptop = null;

            // Act
            Action action = () => { Notepad notepad = (Notepad)laptop; };

            // Assert
            action.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void ConvertNotepadToInt_WhenOperandIsValid_ShouldReturnKopeks()
        {
            // Arrange
            Notepad notepad = new Notepad
            {
                Name = name,
                Price = price,
                NumberOfPages = numberOfPages,
            };

            // Act
            int kopek = (int)notepad;

            // Assert
            kopek.Should().Be(Convert.ToInt32(notepad.Price) * KOPEK);
        }

        [Fact]
        public void ConvertNotepadToInt_WhenOperandIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            Notepad notepad = null;

            // Act
            Action action = () => { int kopek = (int)notepad; };

            // Assert
            action.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void ConvertNotepadToDecimal_WhenOperandIsValid_ShouldReturnPrice()
        {
            // Arrange - Act
            Notepad notepad = new Notepad
            {
                Name = name,
                Price = price,
                NumberOfPages = numberOfPages,
            };

            // Assert
            ((decimal)notepad).Should().Be(price);
        }

        [Fact]
        public void ConvertNotepadToDecimal_WhenOperandIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            Notepad notepad = null;

            // Act
            Action action = () => { decimal result = (decimal)notepad; };

            // Assert
            action.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void EqualsNotepad_WhenArgumentIsValid_ShouldReturnCorrectResult()
        {
            // Arrange - Act
            Notepad notepad1 = new Notepad
            {
                Name = name,
                Price = price,
                NumberOfPages = numberOfPages,
            };
            Notepad notepad2 = new Notepad
            {
                Name = name,
                Price = price,
                NumberOfPages = numberOfPages,
            };

            Notepad notEqualNotepad = new Notepad
            {
                Name = name,
                Price = price * 2,
                NumberOfPages = numberOfPages,
            };
            Notepad notepad3 = notepad1;

            // Assert
            notepad1.Equals(notepad2).Should().BeTrue();
            notepad1.Equals(notepad3).Should().BeTrue();
            notepad1.Equals(notEqualNotepad).Should().BeFalse();
        }
    }
}
