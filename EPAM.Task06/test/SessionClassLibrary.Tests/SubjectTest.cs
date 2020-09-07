using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SessionClassLibrary.Tests
{
    public class SubjectTest
    {
        [Theory]
        [InlineData(1, "TestSubject")]
        [InlineData(10, "TestSubject1")]
        [InlineData(100, "TestSubject10")]
        public void CreateSubject_IfValuesAreValid_ShouldNotThrowExceptions(int id, string name)
        {
            // Arrange - Act
            Action action = () =>
            {
                var subject = new Subject
                {
                    Id = id,
                    Name = name,
                };
            };

            // Assert
            action.Should().NotThrow();
        }

        [Theory]
        [InlineData(-1, "TestSubject")]
        [InlineData(10, "")]
        [InlineData(0, "TestSubject10")]
        public void CreateSubject_IfValuesAreNotValid_ShouldThrowArgumentOutOfRangeException(int id, string name)
        {
            // Arrange - Act
            Action action = () =>
            {
                var subject = new Subject
                {
                    Id = id,
                    Name = name,
                };
            };

            // Assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
