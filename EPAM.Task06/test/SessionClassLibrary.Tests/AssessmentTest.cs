using FluentAssertions;
using SessionClassLibrary.Entities.Assessment;
using System;
using Xunit;

namespace SessionClassLibrary.Tests
{
    public class AssessmentTest
    {
        [Theory]
        [InlineData(1, "10.10.2010", 1, 1, 1)]
        [InlineData(10, "01.12.1990", 100, 1000, 2)]
        [InlineData(999, "28.02.1990", 9, 99, 3)]
        public void CreateExamAssessment_IfValuesAreValid_ShouldNotThrowExceptions(int id,
                                                                                   string date,
                                                                                   int subjectId,
                                                                                   int groupId,
                                                                                   int session)
        {
            // Arrange - Act
            Action action = () =>
            {
                var assessment = new ExamAssessment
                {
                    Id = id,
                    GroupId = groupId,
                    Date = Convert.ToDateTime(date),
                    SubjectId = subjectId,
                    NumberOfSession = session,
                };
            };

            // Assert
            action.Should().NotThrow();
        }

        [Theory]
        [InlineData(-1, "10.10.2010", 1, 1, 1)]
        [InlineData(10, "01.12.1990", -100, 1000, 2)]
        [InlineData(999, "28.02.1990", 9, -99, 3)]
        [InlineData(999, "28.02.1990", 9, -99, 0)]
        public void CreateExamAssessment_IfValuesAreNotValid_ShouldThrowArgumentOutOfRangeException(int id,
                                                                                                    string date,
                                                                                                    int subjectId,
                                                                                                    int groupId,
                                                                                                    int session)
        {
            // Arrange - Act
            Action action = () =>
            {
                var assessment = new ExamAssessment
                {
                    Id = id,
                    GroupId = groupId,
                    Date = Convert.ToDateTime(date),
                    SubjectId = subjectId,
                    NumberOfSession = session,
                };
            };

            // Assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(1, "10.10.2010", 1, 1, 1)]
        [InlineData(10, "01.12.1990", 100, 1000, 2)]
        [InlineData(999, "28.02.1990", 9, 99, 3)]
        public void CreateTestAssessment_IfValuesAreValid_ShouldNotThrowExceptions(int id,
                                                                                   string date,
                                                                                   int subjectId,
                                                                                   int groupId,
                                                                                   int session)
        {
            // Arrange - Act
            Action action = () =>
            {
                var assessment = new ExamAssessment
                {
                    Id = id,
                    GroupId = groupId,
                    Date = Convert.ToDateTime(date),
                    SubjectId = subjectId,
                    NumberOfSession = session,
                };
            };

            // Assert
            action.Should().NotThrow();
        }

        [Theory]
        [InlineData(-1, "10.10.2010", 1, 1, 1)]
        [InlineData(10, "01.12.1990", -100, 1000, 2)]
        [InlineData(999, "28.02.1990", 9, -99, 3)]
        [InlineData(999, "28.02.1990", 9, 99, -4)]
        public void CreateTestAssessment_IfValuesAreNotValid_ShouldThrowArgumentOutOfRangeException(int id,
                                                                                                    string date,
                                                                                                    int subjectId,
                                                                                                    int groupId,
                                                                                                    int session)
        {
            // Arrange - Act
            Action action = () =>
            {
                var assessment = new ExamAssessment
                {
                    Id = id,
                    GroupId = groupId,
                    Date = Convert.ToDateTime(date),
                    SubjectId = subjectId,
                    NumberOfSession = session,
                };
            };

            // Assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
