using FluentAssertions;
using System;
using Xunit;

namespace ProductClassLibrary.Tests
{
    public class ProductTest
    {
        readonly string author = "TestAuthor1";
        readonly string name = "TestName1";
        readonly decimal price = 10.5m;
        readonly int numberOfPages = 1000;
        readonly double cpuFrequancy = 1600;
        const int KOPEK = 100;

        /***** Book Tests *****/

        [Fact]
        public void CreateBook_WhenValuesAreValid_ShouldNotThrowExceptions()
        {
            // Arrange - Act
            Action action = () => new Book
            {
                Author = author,
                Name = name,
                Price = price,
                NumberOfPages = numberOfPages,
            };

            // Assert
            action.Should().NotThrow();
        }

        [Fact]
        public void CreateBook_WhenPriceIsNotValid_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange - Act
            Action action = () => new Book
            {
                Author = author,
                Name = name,
                Price = -price,
                NumberOfPages = numberOfPages,
            };

            // Assert
            action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*price*");
        }

        [Fact]
        public void CreateBook_WhenNumberOfPagesIsNotValid_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange - Act
            Action action = () => new Book
            {
                Author = author,
                Name = name,
                Price = price,
                NumberOfPages = -numberOfPages,
            };

            // Assert
            action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*number*");
        }

        [Theory]
        [InlineData("TestAuthor1", "TestName1", 10.0, 100, "TestAuthor2", "TestName2", 200.1, 1000)]
        [InlineData("", "TestName1", 15.3, 100, "TestAuthor2", "TestName2", 200.1, 1000)]
        [InlineData("TestAuthor1", "TestName1", 10.0, 1, "TestAuthor2", "", 200.1, 1000)]
        public void AddOperatorBook_WhenOperandsAreValid_ShouldReturnCorrectResult1(string author1, string name1, decimal price1, int page1,
                                                                                    string author2, string name2, decimal price2, int page2)
        {
            // Arrange - Act
            Book book1 = new Book
            {
                Author = author1,
                Name = name1,
                Price = price1,
                NumberOfPages = page1,
            };

            Book book2 = new Book
            {
                Author = author2,
                Name = name2,
                Price = price2,
                NumberOfPages = page2,
            };

            Book expected = new Book
            {
                Author = author1 + "-" + author2,
                Name = name1 + "-" + name2,
                Price = (price1 + price2) / 2,
                NumberOfPages = page1 + page2,
            };

            // Assert
            (book1 + book2).Should().Be(expected);
        }

        [Fact]
        public void AddOperatorBook_WhenOperandIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            Book book1 = new Book
            {
                Author = author,
                Name = name,
                Price = price,
                NumberOfPages = numberOfPages,
            };

            Book book2 = null;

            // Act
            Action action = () => { Book book = book1 + book2; };

            // Assert
            action.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void ConvertLaptopToBook_WhenOperandIsValid_ShouldReturnNewBook()
        {
            // Arrange
            Laptop laptop = new Laptop
            {
                Name = name,
                Price = price,
                CPUFrequancy = cpuFrequancy,
            };
            Book expected = new Book { Author = "n/a", Name = laptop.Name, Price = laptop.Price, NumberOfPages = 0, };

            // Act
            Book book = (Book)laptop;

            // Assert
            book.Should().Be(expected);
        }

        [Fact]
        public void ConvertLaptopToBook_WhenOperandIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            Laptop laptop = null;

            // Act
            Action action = () => { Book book = (Book)laptop; };

            // Assert
            action.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void ConvertNotepadToBook_WhenOperandIsValid_ShouldReturnNewBook()
        {
            // Arrange
            Notepad notepad = new Notepad
            {
                Name = name,
                Price = price,
                NumberOfPages = numberOfPages,
            };
            Book expected = new Book { Author = "n/a", Name = notepad.Name, Price = notepad.Price, NumberOfPages = numberOfPages, };

            // Act
            Book book = (Book)notepad;

            // Assert
            book.Should().Be(expected);
        }

        [Fact]
        public void ConvertNotepadToBook_WhenOperandIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            Notepad notepad = null;

            // Act
            Action action = () => { Book book = (Book)notepad; };

            // Assert
            action.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void ConvertBookToInt_WhenOperandIsValid_ShouldReturnKopeks()
        {
            // Arrange
            Book book = new Book
            {
                Author = author,
                Name = name,
                Price = price,
                NumberOfPages = numberOfPages,
            };

            // Act
            int kopek = (int)book;

            // Assert
            kopek.Should().Be(Convert.ToInt32(book.Price) * KOPEK);
        }

        [Fact]
        public void ConvertBookToInt_WhenOperandIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            Book book = null;

            // Act
            Action action = () => { int kopek = (int)book; };

            // Assert
            action.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void ConvertBookToDecimal_WhenOperandIsValid_ShouldReturnPrice()
        {
            // Arrange - Act
            Book book = new Book
            {
                Name = name,
                Price = price,
                Author = author,
                NumberOfPages = numberOfPages,
            };

            // Assert
            ((decimal)book).Should().Be(price);
        }

        [Fact]
        public void ConvertBookToDecimal_WhenOperandIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            Book book = null;

            // Act
            Action action = () => { decimal result = (decimal)book; };

            // Assert
            action.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void EqualsBook_WhenArgumentIsValid_ShouldReturnCorrectResult()
        {
            // Arrange - Act
            Book book1 = new Book
            {
                Name = name,
                Price = price,
                Author = author,
                NumberOfPages = numberOfPages,
            };
            Book book2 = new Book
            {
                Name = name,
                Price = price,
                Author = author,
                NumberOfPages = numberOfPages,
            };
            Book notEqualBook = new Book
            {
                Name = name,
                Price = price * 2,
                Author = author,
                NumberOfPages = numberOfPages,
            };
            Book book3 = book1;

            // Assert
            book1.Equals(book2).Should().BeTrue();
            book1.Equals(book3).Should().BeTrue();
            book1.Equals(notEqualBook).Should().BeFalse();
        }

        /***** Laptop Tests *****/

        [Fact]
        public void CreateLaptop_WhenValuesAreValid_ShouldNotThrowExceptions()
        {
            // Arrange - Act
            Action action = () => new Laptop
            {
                Name = name,
                Price = price,
                CPUFrequancy = cpuFrequancy,
            };

            // Assert
            action.Should().NotThrow();
        }

        [Fact]
        public void CreateLaptop_WhenPriceIsNotValid_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange - Act
            Action action = () => new Laptop
            {
                Name = name,
                Price = -price,
                CPUFrequancy = cpuFrequancy,
            };

            // Assert
            action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*price*");
        }

        [Fact]
        public void CreateLaptop_WhenCPUFrequancyIsNotValid_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange - Act
            Action action = () => new Laptop
            {
                Name = name,
                Price = price,
                CPUFrequancy = -cpuFrequancy,
            };

            // Assert
            action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*frequancy*");
        }

        [Theory]
        [InlineData("TestName1", 10.0, 1600, "TestName2", 200.1, 2000)]
        [InlineData("", 15.3, 1300, "TestName2", 200.1, 1000)]
        [InlineData("TestName1", 10.0, 1, "", 200.1, 1000)]
        public void AddOperatorLaptop_WhenOperandsAreValid_ShouldReturnCorrectResult1(string name1, decimal price1, double frequancy1,
                                                                                      string name2, decimal price2, double frequancy2)
        {
            // Arrange - Act
            Laptop laptop1 = new Laptop
            {
                Name = name1,
                Price = price1,
                CPUFrequancy = frequancy1,
            };

            Laptop laptop2 = new Laptop
            {
                Name = name2,
                Price = price2,
                CPUFrequancy = frequancy2,
            };

            Laptop expected = new Laptop
            {
                Name = name1 + "-" + name2,
                Price = (price1 + price2) / 2,
                CPUFrequancy = (frequancy1 + frequancy2) / 2,
            };

            // Assert
            (laptop1 + laptop2).Should().Be(expected);
        }

        [Fact]
        public void AddOperatorLaptop_WhenOperandIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            Laptop laptop1 = new Laptop
            {
                Name = name,
                Price = price,
                CPUFrequancy = cpuFrequancy,
            };

            Laptop laptop2 = null;

            // Act
            Action action = () => { Laptop laptop = laptop1 + laptop2; };

            // Assert
            action.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void ConvertBookToLaptop_WhenOperandIsValid_ShouldReturnNewLaptop()
        {
            // Arrange
            Book book = new Book
            {
                Name = name,
                Price = price,
                Author = author,
                NumberOfPages = numberOfPages,
            };
            Laptop expected = new Laptop { Name = book.Name, Price = book.Price, CPUFrequancy = 0, };

            // Act
            Laptop laptop = (Laptop)book;

            // Assert
            laptop.Should().Be(expected);
        }

        [Fact]
        public void ConvertBookToLaptop_WhenOperandIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            Book book = null;

            // Act
            Action action = () => { Laptop laptop = (Laptop)book; };

            // Assert
            action.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void ConvertNotepadToLaptop_WhenOperandIsValid_ShouldReturnNewLaptop()
        {
            // Arrange
            Notepad notepad = new Notepad
            {
                Name = name,
                Price = price,
                NumberOfPages = numberOfPages,
            };
            Laptop expected = new Laptop { Name = notepad.Name, Price = notepad.Price, CPUFrequancy = 0, };

            // Act
            Laptop laptop = (Laptop)notepad;

            // Assert
            laptop.Should().Be(expected);
        }

        [Fact]
        public void ConvertNotepadToLaptop_WhenOperandIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            Notepad notepad = null;

            // Act
            Action action = () => { Laptop laptop = (Laptop)notepad; };

            // Assert
            action.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void ConvertLaptopToInt_WhenOperandIsValid_ShouldReturnKopeks()
        {
            // Arrange
            Laptop laptop = new Laptop
            {
                Name = name,
                Price = price,
                CPUFrequancy = cpuFrequancy,
            };

            // Act
            int kopek = (int)laptop;

            // Assert
            kopek.Should().Be(Convert.ToInt32(laptop.Price) * KOPEK);
        }

        [Fact]
        public void ConvertLaptopToInt_WhenOperandIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            Laptop laptop = null;

            // Act
            Action action = () => { int kopek = (int)laptop; };

            // Assert
            action.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void ConvertLaptopToDecimal_WhenOperandIsValid_ShouldReturnPrice()
        {
            // Arrange - Act
            Laptop laptop = new Laptop
            {
                Name = name,
                Price = price,
                CPUFrequancy = cpuFrequancy,
            };

            // Assert
            ((decimal)laptop).Should().Be(price);
        }

        [Fact]
        public void ConvertLaptopToDecimal_WhenOperandIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            Laptop laptop = null;

            // Act
            Action action = () => { decimal result = (decimal)laptop; };

            // Assert
            action.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void EqualsLaptop_WhenArgumentIsValid_ShouldReturnCorrectResult()
        {
            // Arrange - Act
            Laptop laptop1 = new Laptop
            {
                Name = name,
                Price = price,
                CPUFrequancy = cpuFrequancy,
            };
            Laptop laptop2 = new Laptop
            {
                Name = name,
                Price = price,
                CPUFrequancy = cpuFrequancy,
            };

            Laptop notEqualLaptop = new Laptop
            {
                Name = name,
                Price = price * 2,
                CPUFrequancy = cpuFrequancy,
            };
            Laptop laptop3 = laptop1;

            // Assert
            laptop1.Equals(laptop2).Should().BeTrue();
            laptop1.Equals(laptop3).Should().BeTrue();
            laptop1.Equals(notEqualLaptop).Should().BeFalse();
        }

        /***** Notepad Tests *****/

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
