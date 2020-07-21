using FluentAssertions;
using System;
using Xunit;

namespace ProductClassLibrary.Tests
{
    public class LaptopTest
    {
        readonly string author = "TestAuthor1";
        readonly string name = "TestName1";
        readonly decimal price = 10.5m;
        readonly int numberOfPages = 1000;
        readonly double cpuFrequancy = 1600;
        const int KOPEK = 100;

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
    }
}
