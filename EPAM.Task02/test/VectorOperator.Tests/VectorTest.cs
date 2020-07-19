using FluentAssertions;
using System;
using Xunit;

namespace VectorOperator.Tests
{
    public class VectorTest
    {
        [Fact]
        public void Test1()
        {
            Vector vector = new Vector { X = 10, Y = 20, Z = 30, };
            Vector vector1 = new Vector { X = 30, Y = 20, Z = 10, };
            Vector vector2 = new Vector { X = 50, Y = 31, Z = 9, };
            //Vector[] vectors = null;

            //Action action = () => vector.AddVector(null, null, null);

            action.Should().Throw<ArgumentNullException>();
        }
    }
}
