using FluentAssertions;
using Moq;
using SessionClassLibrary.Entities.Assessment;
using SessionClassLibrary.Entities.Grade;
using System;
using System.Collections.Generic;
using Xunit;

namespace SessionClassLibrary.Tests
{
    public class RepositoryTest
    {
        /******* data *******/
        private readonly List<Student> students = new List<Student>
        {
            new Student
            {
                Id = 1,
                Name = "Name1",
                BirthDate = Convert.ToDateTime("10.10.1999"),
                Gender = "Male",
                GroupId = 1,
            },
            new Student
            {
                Id = 2,
                Name = "Name1",
                BirthDate = Convert.ToDateTime("10.10.1999"),
                Gender = "Male",
                GroupId = 1,
            },
            new Student
            {
                Id = 3,
                Name = "Name1",
                BirthDate = Convert.ToDateTime("10.10.1999"),
                Gender = "Male",
                GroupId = 1,
            },
        };

        private readonly List<StudentGroup> groups = new List<StudentGroup>
        {
            new StudentGroup
            {
                Id = 1,
                Number = "Group1",
            },
            new StudentGroup
            {
                Id = 2,
                Number = "Group2",
            },
            new StudentGroup
            {
                Id = 3,
                Number = "Group3",
            },
        };

        private readonly List<Subject> subjects = new List<Subject>
        {
            new Subject
            {
                Id = 1,
                Name = "Subject1",
            },
            new Subject
            {
                Id = 2,
                Name = "Subject2",
            },
            new Subject
            {
                Id = 3,
                Name = "Subject3",
            },
        };

        private readonly List<TestAssessment> tests = new List<TestAssessment>
        {
            new TestAssessment
            {
                Id = 1,
                SubjectId = 1,
                GroupId = 1,
                Date = Convert.ToDateTime("01.01.2020"),
                NumberOfSession = 1,
            },
            new TestAssessment
            {
                Id = 2,
                SubjectId = 2,
                GroupId = 1,
                Date = Convert.ToDateTime("02.01.2020"),
                NumberOfSession = 1,
            },
            new TestAssessment
            {
                Id = 3,
                SubjectId = 3,
                GroupId = 1,
                Date = Convert.ToDateTime("03.01.2020"),
                NumberOfSession = 1,
            },
        };

        private readonly List<ExamAssessment> exams = new List<ExamAssessment>
        {
            new ExamAssessment
            {
                Id = 1,
                SubjectId = 1,
                GroupId = 1,
                Date = Convert.ToDateTime("01.01.2020"),
                NumberOfSession = 1,
            },
            new ExamAssessment
            {
                Id = 2,
                SubjectId = 2,
                GroupId = 1,
                Date = Convert.ToDateTime("02.01.2020"),
                NumberOfSession = 1,
            },
            new ExamAssessment
            {
                Id = 3,
                SubjectId = 3,
                GroupId = 1,
                Date = Convert.ToDateTime("03.01.2020"),
                NumberOfSession = 1,
            },
        };

        private readonly List<PassFailGrade> passGrades = new List<PassFailGrade>
        {
            new PassFailGrade
            {
                Id = 1,
                StudentId = 1,
                AssessmentId = 1,
                Value = "Pass",
            },
            new PassFailGrade
            {
                Id = 2,
                StudentId = 2,
                AssessmentId = 1,
                Value = "Fail",
            },
            new PassFailGrade
            {
                Id = 3,
                StudentId = 3,
                AssessmentId = 1,
                Value = "Pass",
            },
        };

        private readonly List<PointGrade> pointGrades = new List<PointGrade>
        {
            new PointGrade
            {
                Id = 1,
                StudentId = 1,
                AssessmentId = 1,
                Value = 9,
            },
            new PointGrade
            {
                Id = 2,
                StudentId = 2,
                AssessmentId = 1,
                Value = 3,
            },
            new PointGrade
            {
                Id = 3,
                StudentId = 3,
                AssessmentId = 1,
                Value = 7,
            },
        };

        /******* test cases *******/
        [Fact]
        public void GetAllStudents_IfQueryIsCorrect_ShouldReturnAllStudents()
        {
            // Arrange
            var mock = new Mock<IMockRepository<Student>>();
            mock.Setup(m => m.GetAll()).Returns(students);

            // Act
            List<Student> studs = (List<Student>)mock.Object.GetAll();

            // Assert
            studs.Should().NotBeEmpty().And.HaveCount(3);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetStudentById_IfQueryIsCorrect_ShouldReturnStudent(int id)
        {
            // Arrange
            var mock = new Mock<IMockRepository<Student>>();
            mock.Setup(m => m.GetById(id)).Returns(students.Find(s => s.Id == id));
            Student expected = students.Find(s => s.Id == id);

            // Act
            Student stud = mock.Object.GetById(id);

            // Assert
            stud.Should().NotBeNull().And.Be(expected);
        }

        [Fact]
        public void GetAllStudentGroups_IfQueryIsCorrect_ShouldReturnAllStudentGroups()
        {
            // Arrange
            var mock = new Mock<IMockRepository<StudentGroup>>();
            mock.Setup(m => m.GetAll()).Returns(groups);

            // Act
            List<StudentGroup> grs = (List<StudentGroup>)mock.Object.GetAll();

            // Assert
            grs.Should().NotBeEmpty().And.HaveCount(3);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetStudentGroupById_IfQueryIsCorrect_ShouldReturnStudentGroup(int id)
        {
            // Arrange
            var mock = new Mock<IMockRepository<StudentGroup>>();
            mock.Setup(m => m.GetById(id)).Returns(groups.Find(g => g.Id == id));
            StudentGroup expected = groups.Find(g => g.Id == id);

            // Act
            StudentGroup gr = mock.Object.GetById(id);

            // Assert
            gr.Should().NotBeNull().And.Be(expected);
        }

        [Fact]
        public void GetAllSubjects_IfQueryIsCorrect_ShouldReturnAllSubjects()
        {
            // Arrange
            var mock = new Mock<IMockRepository<Subject>>();
            mock.Setup(m => m.GetAll()).Returns(subjects);

            // Act
            List<Subject> subjs = (List<Subject>)mock.Object.GetAll();

            // Assert
            subjs.Should().NotBeEmpty().And.HaveCount(3);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetSubjectById_IfQueryIsCorrect_ShouldReturnSubject(int id)
        {
            // Arrange
            var mock = new Mock<IMockRepository<Subject>>();
            mock.Setup(m => m.GetById(id)).Returns(subjects.Find(s => s.Id == id));
            Subject expected = subjects.Find(s => s.Id == id);

            // Act
            Subject subj = mock.Object.GetById(id);

            // Assert
            subj.Should().NotBeNull().And.Be(expected);
        }

        [Fact]
        public void GetAllTests_IfQueryIsCorrect_ShouldReturnAllTests()
        {
            // Arrange
            var mock = new Mock<IMockRepository<TestAssessment>>();
            mock.Setup(m => m.GetAll()).Returns(tests);

            // Act
            List<TestAssessment> assessments = (List<TestAssessment>)mock.Object.GetAll();

            // Assert
            assessments.Should().NotBeEmpty().And.HaveCount(3);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetTestById_IfQueryIsCorrect_ShouldReturnTest(int id)
        {
            // Arrange
            var mock = new Mock<IMockRepository<TestAssessment>>();
            mock.Setup(m => m.GetById(id)).Returns(tests.Find(t => t.Id == id));
            TestAssessment expected = tests.Find(t => t.Id == id);

            // Act
            TestAssessment assessment = mock.Object.GetById(id);

            // Assert
            assessment.Should().NotBeNull().And.Be(expected);
        }

        [Fact]
        public void GetAllExams_IfQueryIsCorrect_ShouldReturnAllExams()
        {
            // Arrange
            var mock = new Mock<IMockRepository<ExamAssessment>>();
            mock.Setup(m => m.GetAll()).Returns(exams);

            // Act
            List<ExamAssessment> assessments = (List<ExamAssessment>)mock.Object.GetAll();

            // Assert
            assessments.Should().NotBeEmpty().And.HaveCount(3);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetExamById_IfQueryIsCorrect_ShouldReturnExam(int id)
        {
            // Arrange
            var mock = new Mock<IMockRepository<ExamAssessment>>();
            mock.Setup(m => m.GetById(id)).Returns(exams.Find(e => e.Id == id));
            ExamAssessment expected = exams.Find(e => e.Id == id);

            // Act
            ExamAssessment assessment = mock.Object.GetById(id);

            // Assert
            assessment.Should().NotBeNull().And.Be(expected);
        }

        [Fact]
        public void GetAllPassFails_IfQueryIsCorrect_ShouldReturnAllPassFails()
        {
            // Arrange
            var mock = new Mock<IMockRepository<PassFailGrade>>();
            mock.Setup(m => m.GetAll()).Returns(passGrades);

            // Act
            List<PassFailGrade> passFails = (List<PassFailGrade>)mock.Object.GetAll();

            // Assert
            passFails.Should().NotBeEmpty().And.HaveCount(3);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetPassFailById_IfQueryIsCorrect_ShouldReturnPassFail(int id)
        {
            // Arrange
            var mock = new Mock<IMockRepository<PassFailGrade>>();
            mock.Setup(m => m.GetById(id)).Returns(passGrades.Find(p => p.Id == id));
            PassFailGrade expected = passGrades.Find(p => p.Id == id);

            // Act
            PassFailGrade passGrade = mock.Object.GetById(id);

            // Assert
            passGrade.Should().NotBeNull().And.Be(expected);
        }

        [Fact]
        public void GetAllPoints_IfQueryIsCorrect_ShouldReturnAllPoints()
        {
            // Arrange
            var mock = new Mock<IMockRepository<PointGrade>>();
            mock.Setup(m => m.GetAll()).Returns(pointGrades);

            // Act
            List<PointGrade> points = (List<PointGrade>)mock.Object.GetAll();

            // Assert
            points.Should().NotBeEmpty().And.HaveCount(3);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetPointById_IfQueryIsCorrect_ShouldReturnPoint(int id)
        {
            // Arrange
            var mock = new Mock<IMockRepository<PointGrade>>();
            mock.Setup(m => m.GetById(id)).Returns(pointGrades.Find(p => p.Id == id));
            PointGrade expected = pointGrades.Find(p => p.Id == id);

            // Act
            PointGrade pointGrade = mock.Object.GetById(id);

            // Assert
            pointGrade.Should().NotBeNull().And.Be(expected);
        }
    }
}
