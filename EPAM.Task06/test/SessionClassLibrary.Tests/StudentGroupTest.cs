using System;
using Xunit;
using FluentAssertions;

namespace SessionClassLibrary.Tests
{
    public class StudentGroupTest
    {
        [Theory]
        [InlineData(1, "G1")]
        [InlineData(12, "G100")]
        [InlineData(1000, "GB")]
        public void CreateStudentGroup_IfPassedValuesAreValid_ShouldNotThrowExceptions(int id, string number)
        {
            // Arrange - Act
            Action action = () =>
            {
                var group = new StudentGroup
                {
                    Id = id,
                    Number = number,
                };
            };

            // Assert
            action.Should().NotThrow();
        }

        [Theory]
        [InlineData(0, "G1")]
        [InlineData(-1, "G1")]
        [InlineData(1, "")]
        public void CreateStudentGroup_IfPassedValuesAreNotValid_ShouldThrowArgumentOutOfRangeException(int id, string number)
        {
            // Arrange - Act
            Action action = () =>
            {
                var group = new StudentGroup
                {
                    Id = id,
                    Number = number,
                };
            };

            // Assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
