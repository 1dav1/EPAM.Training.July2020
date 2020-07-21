using FluentAssertions;
using System;
using Xunit;

namespace ProductClassLibrary.Tests
{
    public class BookTest
    {
        readonly string author = "TestAuthor1";
        readonly string name = "TestName1";
        readonly decimal price = 10.5m;
        readonly int numberOfPages = 1000;
        readonly double cpuFrequancy = 1600;
        const int KOPEK = 100;

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
    }
}
