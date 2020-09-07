using FluentAssertions;
using SessionClassLibrary.Entities.Grade;
using System;
using Xunit;

namespace SessionClassLibrary.Tests
{
    public class GradeTest
    {
        [Theory]
        [InlineData(1, 1, 1, "Pass")]
        [InlineData(100, 12, 25, "Fail")]
        [InlineData(1000, 521, 731, "Pass")]
        public void CreatePassFailGrade_IfValuesAreValid_ShoulNotThrowExceptions(int id,
                                                                                 int assessmentId,
                                                                                 int studentId,
                                                                                 string gradeValue)
        {
            // Arrange - Act
            Action action = () =>
            {
                var grade = new PassFailGrade
                {
                    Id = id,
                    AssessmentId = assessmentId,
                    StudentId = studentId,
                    Value = gradeValue,
                };
            };

            // Assert
            action.Should().NotThrow();
        }

        [Theory]
        [InlineData(-1, 1, 1, "Pass")]
        [InlineData(100, -12, 25, "Fail")]
        [InlineData(1000, 521, -731, "Pass")]
        [InlineData(1, 1, 1, "Test")]
        public void CreatePassFailGrade_IfValuesAreNotValid_ShoulNotThrowArgumentOutOfRangeException(int id,
                                                                                                     int assessmentId,
                                                                                                     int studentId,
                                                                                                     string gradeValue)
        {
            // Arrange - Act
            Action action = () =>
            {
                var grade = new PassFailGrade
                {
                    Id = id,
                    AssessmentId = assessmentId,
                    StudentId = studentId,
                    Value = gradeValue,
                };
            };

            // Assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(1, 1, 1, 10)]
        [InlineData(100, 12, 25, 0)]
        [InlineData(1000, 521, 731, 5)]
        public void CreatePointGrade_IfValuesAreValid_ShoulNotThrowExceptions(int id,
                                                                              int assessmentId,
                                                                              int studentId,
                                                                              int gradeValue)
        {
            // Arrange - Act
            Action action = () =>
            {
                var grade = new PointGrade
                {
                    Id = id,
                    AssessmentId = assessmentId,
                    StudentId = studentId,
                    Value = gradeValue,
                };
            };

            // Assert
            action.Should().NotThrow();
        }

        [Theory]
        [InlineData(-1, 1, 1, 10)]
        [InlineData(100, -12, 25, 9)]
        [InlineData(1000, 521, -731, 8)]
        [InlineData(1, 1, 1, -7)]
        [InlineData(1, 1, 1, 11)]
        public void CreatePointGrade_IfValuesAreNotValid_ShoulNotThrowArgumentOutOfRangeException(int id,
                                                                                                  int assessmentId,
                                                                                                  int studentId,
                                                                                                  int gradeValue)
        {
            // Arrange - Act
            Action action = () =>
            {
                var grade = new PointGrade
                {
                    Id = id,
                    AssessmentId = assessmentId,
                    StudentId = studentId,
                    Value = gradeValue,
                };
            };

            // Assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
