using FluentAssertions;
using System;
using Xunit;

namespace SessionClassLibrary.Tests
{
    public class StudentTest
    {
        [Theory]
        [InlineData(1, "TestName", "Male", "01.01.2001", 1)]
        [InlineData(100, "TestName", "Female", "01.10.1999", 15)]
        [InlineData(12, "TestName", "Male", "21.03.1991", 123)]
        public void CreateStudent_IfPassedValuesAreValid_ShouldNotThrowExceptions(int id, string name, string gender, string date, int groupId)
        {
            // Arrange - Act
            Action action = () =>
            {
                var student = new Student
                {
                    Id = id,
                    Name = name,
                    Gender = gender,
                    BirthDate = Convert.ToDateTime(date),
                    GroupId = groupId,
                };
            };

            // Assert
            action.Should().NotThrow();
        }

        [Theory]
        [InlineData(-1, "TestName", "Male", "01.01.2001", 1)]
        [InlineData(100, "TestName", "Female", "01.10.1999", -15)]
        [InlineData(12, "", "Male", "21.03.1991", 123)]
        [InlineData(12, "TestName", "TestGender", "21.03.1991", 123)]
        public void CreateStudent_IfPassedValuesAreNotValid_ShouldThrowArgumentOutOfRangeException(int id,
                                                                                                   string name,
                                                                                                   string gender,
                                                                                                   string date,
                                                                                                   int groupId)
        {
            // Arrange - Act
            Action action = () =>
            {
                var student = new Student
                {
                    Id = id,
                    Name = name,
                    Gender = gender,
                    BirthDate = Convert.ToDateTime(date),
                    GroupId = groupId,
                };
            };

            // Assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
