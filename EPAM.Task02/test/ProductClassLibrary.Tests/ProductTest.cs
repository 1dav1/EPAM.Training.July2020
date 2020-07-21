using FluentAssertions;
using System;
using Xunit;

namespace ProductClassLibrary.Tests
{
    public class ProductTest
    {
        [Fact]
        public void Test1()
        {
            Book book = null;

            Action action = () => { Laptop laptop = (Laptop)book; };

            //action.Should().Throw();
        }
    }
}
