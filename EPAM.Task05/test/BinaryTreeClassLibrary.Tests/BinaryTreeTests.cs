using FluentAssertions;
using ResultClassLibrary;
using System;
using Xunit;

namespace BinaryTreeClassLibrary.Tests
{
    public class BinaryTreeTests
    {
        [Fact]
        public void CreateBinaryTree_ShouldNotThrowExceptions()
        {
            // Arrange - Act
            Action action1 = () => { new BinaryTree<LetterGrade, char>(); };
            Action action2 = () => { new BinaryTree<PercentageGrade, int>(); };
            Action action3 = () => { new BinaryTree<PointGrade, int>(); };

            // Assert
            action1.Should().NotThrow<Exception>();
            action1.Should().NotThrow<Exception>();
            action1.Should().NotThrow<Exception>();
        }

        [Fact]
        public void CreateBinaryTree_ByDefault_RootShouldBeNull()
        {
            // Arrange - Act
            BinaryTree<LetterGrade, char> tree1 = new BinaryTree<LetterGrade, char>();
            BinaryTree<PercentageGrade, int> tree2 = new BinaryTree<PercentageGrade, int>();
            BinaryTree<PointGrade, int> tree3 = new BinaryTree<PointGrade, int>();


            // Assert
            tree1.Root.Should().BeNull();
            tree2.Root.Should().BeNull();
            tree3.Root.Should().BeNull();
        }

        [Fact]
        public void AddAGrade_ToTheEmptyTree_TheRootShouldNotBeNull()
        {
            // Arrange
            LetterGrade letter = new LetterGrade 
            { 
                Date = DateTime.Now, 
                Grade = 'A', 
                Name = "TestName1", 
                Test = "Test1", 
            };
            PercentageGrade percentage = new PercentageGrade
            {
                Date = DateTime.Now,
                Grade = 100,
                Name = "TestName2",
                Test = "Test2",
            };
            PointGrade point = new PointGrade
            {
                Date = DateTime.Now,
                Grade = 10,
                Name = "TestName3",
                Test = "Test3",
            };
            BinaryTree<LetterGrade, char> tree1 = new BinaryTree<LetterGrade, char>();
            BinaryTree<PercentageGrade, int> tree2 = new BinaryTree<PercentageGrade, int>();
            BinaryTree<PointGrade, int> tree3 = new BinaryTree<PointGrade, int>();

            // Act
            tree1.Add(letter);
            tree2.Add(percentage);
            tree3.Add(point);

            // Assert
            tree1.Root.Should().NotBeNull();
            tree2.Root.Should().NotBeNull();
            tree3.Root.Should().NotBeNull();
        }

        [Fact]
        public void AddAGrade_ToTheEmptyTree_TheAddedGradeShouldBecomeTheRoot()
        {
            // Arrange
            LetterGrade letter = new LetterGrade
            {
                Date = DateTime.Now,
                Grade = 'A',
                Name = "TestName1",
                Test = "Test1",
            };
            PercentageGrade percentage = new PercentageGrade
            {
                Date = DateTime.Now,
                Grade = 100,
                Name = "TestName2",
                Test = "Test2",
            };
            PointGrade point = new PointGrade
            {
                Date = DateTime.Now,
                Grade = 10,
                Name = "TestName3",
                Test = "Test3",
            };
            BinaryTree<LetterGrade, char> tree1 = new BinaryTree<LetterGrade, char>();
            BinaryTree<PercentageGrade, int> tree2 = new BinaryTree<PercentageGrade, int>();
            BinaryTree<PointGrade, int> tree3 = new BinaryTree<PointGrade, int>();

            // Act
            tree1.Add(letter);
            tree2.Add(percentage);
            tree3.Add(point);

            // Assert
            tree1.Root.Grades[0].Grade.Should().Be(letter.Grade);
            tree2.Root.Grades[0].Grade.Should().Be(percentage.Grade);
            tree3.Root.Grades[0].Grade.Should().Be(point.Grade);
        }

        [Fact]
        public void Add_GradesOfTheSameValue_GradesShouldBeStoredInCollectionOfTheNode()
        {
            // Arrange
            BinaryTree<LetterGrade, char> tree = new BinaryTree<LetterGrade, char>();
            LetterGrade letter1 = new LetterGrade
            {
                Date = DateTime.Now,
                Grade = 'A',
                Name = "TestName1",
                Test = "Test1",
            };
            LetterGrade letter2 = new LetterGrade
            {
                Date = DateTime.Now,
                Grade = 'A',
                Name = "TestName2",
                Test = "Test1",
            };

            // Act
            tree.Add(letter1);
            tree.Add(letter2);

            // Assert
            tree.Root.Grades.Should().NotBeEmpty().And.HaveCount(2);
        }

        [Fact]
        public void AddLetterGrades_OfDifferentValue_TheSmallerValueShouldBeLeftNodeTheBiggerValueShouldBeRightNode()
        {
            // Arrange
            BinaryTree<LetterGrade, char> tree = new BinaryTree<LetterGrade, char>();
            LetterGrade letter1 = new LetterGrade
            {
                Date = DateTime.Now,
                Grade = 'B',
                Name = "TestName1",
                Test = "Test1",
            };
            LetterGrade letter2 = new LetterGrade
            {
                Date = DateTime.Now,
                Grade = 'A',
                Name = "TestName2",
                Test = "Test1",
            };
            LetterGrade letter3 = new LetterGrade
            {
                Date = DateTime.Now,
                Grade = 'C',
                Name = "TestName2",
                Test = "Test1",
            };

            // Act
            tree.Add(letter1);
            tree.Add(letter2);
            tree.Add(letter3);

            // Assert
            tree.Root.Grades[0].Grade.Should().Be(letter1.Grade);
            tree.Root.LeftNode.Grades[0].Grade.Should().Be(letter3.Grade);
            tree.Root.RightNode.Grades[0].Grade.Should().Be(letter2.Grade);
        }

        [Fact]
        public void AddPercentageGrades_OfDifferentValue_TheSmallerValueShouldBeLeftNodeTheBiggerValueShouldBeRightNode()
        {
            // Arrange
            BinaryTree<PercentageGrade, int> tree = new BinaryTree<PercentageGrade, int>();
            PercentageGrade percentage1 = new PercentageGrade
            {
                Date = DateTime.Now,
                Grade = 80,
                Name = "TestName1",
                Test = "Test1",
            };
            PercentageGrade percentage2 = new PercentageGrade
            {
                Date = DateTime.Now,
                Grade = 100,
                Name = "TestName2",
                Test = "Test1",
            };
            PercentageGrade percentage3 = new PercentageGrade
            {
                Date = DateTime.Now,
                Grade = 70,
                Name = "TestName2",
                Test = "Test1",
            };

            // Act
            tree.Add(percentage1);
            tree.Add(percentage2);
            tree.Add(percentage3);

            // Assert
            tree.Root.Grades[0].Grade.Should().Be(percentage1.Grade);
            tree.Root.LeftNode.Grades[0].Grade.Should().Be(percentage3.Grade);
            tree.Root.RightNode.Grades[0].Grade.Should().Be(percentage2.Grade);
        }

        [Fact]
        public void AddPointGrades_OfDifferentValue_TheSmallerValueShouldBeLeftNodeTheBiggerValueShouldBeRightNode()
        {
            // Arrange
            BinaryTree<PointGrade, int> tree = new BinaryTree<PointGrade, int>();
            PointGrade point1 = new PointGrade
            {
                Date = DateTime.Now,
                Grade = 8,
                Name = "TestName1",
                Test = "Test1",
            };
            PointGrade point2 = new PointGrade
            {
                Date = DateTime.Now,
                Grade = 10,
                Name = "TestName2",
                Test = "Test1",
            };
            PointGrade point3 = new PointGrade
            {
                Date = DateTime.Now,
                Grade = 7,
                Name = "TestName2",
                Test = "Test1",
            };

            // Act
            tree.Add(point1);
            tree.Add(point2);
            tree.Add(point3);

            // Assert
            tree.Root.Grades[0].Grade.Should().Be(point1.Grade);
            tree.Root.LeftNode.Grades[0].Grade.Should().Be(point3.Grade);
            tree.Root.RightNode.Grades[0].Grade.Should().Be(point2.Grade);
        }


        [Fact]
        public void Add_IfTheArgumentIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            BinaryTree<LetterGrade, char> tree1 = new BinaryTree<LetterGrade, char>();
            BinaryTree<PercentageGrade, int> tree2 = new BinaryTree<PercentageGrade, int>();
            BinaryTree<PointGrade, int> tree3 = new BinaryTree<PointGrade, int>();
            LetterGrade letter = null;
            PercentageGrade percentage = null;
            PointGrade point = null;

            // Act
            Action action1 = () => { tree1.Add(letter); };
            Action action2 = () => { tree2.Add(percentage); };
            Action action3 = () => { tree3.Add(point); };

            // Assert
            action1.Should().Throw<ArgumentNullException>();
            action2.Should().Throw<ArgumentNullException>();
            action3.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void FindLetterGrade_IfTheGradeIsInTheTree_ShouldReturnTheGrade()
        {
            // Arrange
            BinaryTree<LetterGrade, char> tree1 = new BinaryTree<LetterGrade, char>();
            BinaryTree<PercentageGrade, int> tree2 = new BinaryTree<PercentageGrade, int>();
            BinaryTree<PointGrade, int> tree3 = new BinaryTree<PointGrade, int>();

            LetterGrade letter = new LetterGrade
            {
                Date = DateTime.Now,
                Grade = 'B',
                Name = "TestName1",
                Test = "Test1",
            };
            PercentageGrade percentage = new PercentageGrade
            {
                Date = DateTime.Now,
                Grade = 100,
                Name = "TestName2",
                Test = "Test2",
            };
            PointGrade point = new PointGrade
            {
                Date = DateTime.Now,
                Grade = 10,
                Name = "TestName3",
                Test = "Test3",
            };
            tree1.Add(letter);
            tree2.Add(percentage);
            tree3.Add(point);

            // Act
            LetterGrade letterResult = tree1.Find(letter);
            PercentageGrade percentageResult = tree2.Find(percentage);
            PointGrade pointResult = tree3.Find(point);

            // Assert
            letterResult.Grade.Should().Be(letter.Grade);
            percentageResult.Grade.Should().Be(percentage.Grade);
            pointResult.Grade.Should().Be(point.Grade);
        }

        [Fact]
        public void FindLetterGrade_IfTheGradeIsNotInTheTree_ShouldReturnNull()
        {
            // Arrange
            BinaryTree<LetterGrade, char> tree1 = new BinaryTree<LetterGrade, char>();
            BinaryTree<PercentageGrade, int> tree2 = new BinaryTree<PercentageGrade, int>();
            BinaryTree<PointGrade, int> tree3 = new BinaryTree<PointGrade, int>();
            LetterGrade letter = new LetterGrade
            {
                Date = DateTime.Now,
                Grade = 'B',
                Name = "TestName1",
                Test = "Test1",
            };
            PercentageGrade percentage = new PercentageGrade
            {
                Date = DateTime.Now,
                Grade = 100,
                Name = "TestName2",
                Test = "Test2",
            };
            PointGrade point = new PointGrade
            {
                Date = DateTime.Now,
                Grade = 10,
                Name = "TestName3",
                Test = "Test3",
            };

            // Act
            LetterGrade letterResult = tree1.Find(letter);
            PercentageGrade percentageResult = tree2.Find(percentage);
            PointGrade pointResult = tree3.Find(point);

            // Assert
            letterResult.Should().BeNull();
            percentageResult.Should().BeNull();
            pointResult.Should().BeNull();
        }
    }
}
