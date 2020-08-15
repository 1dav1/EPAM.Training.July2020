using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CustomSerializerClassLibrary.Tests
{
    public class CustomSerializerTests
    {
        private readonly Person person = new Person
        {
            Age = 20,
            FirstName = "TestName",
            Gender = Gender.Male,
        };
        private readonly string jsonPerson = "{\"FirstName\":\"TestName\",\"Age\":20,\"Gender\":0}";
        private readonly string xmlPerson = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n" +
                                            "<Person xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n" +
                                            "  <FirstName>TestName</FirstName>\r\n" +
                                            "  <Age>20</Age>\r\n" +
                                            "  <Gender>Male</Gender>\r\n" +
                                            "</Person>";

        private readonly Product product = new Product
        {
            Name = "TestName",
            Price = 10.5m,
        };
        private readonly string xmlProduct = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n" +
                                             "<Product xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n" +
                                             "  <Name>TestName</Name>\r\n" +
                                             "  <Price>10.5</Price>\r\n" +
                                             "</Product>";

        private readonly string jsonProduct = "{\"Name\":\"TestName\",\"Price\":10.5}";

        private readonly Circle circle = new Circle
        {
            Radius = 100,
        };
        private readonly string xmlCircle = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n" +
                                             "<Circle xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n" +
                                             "  <Radius>100</Radius>\r\n" +
                                             "</Circle>";
        private readonly string jsonCircle = "{\"Radius\":100}";
        private readonly List<Person> people = new List<Person>
            {
                new Person
                {
                    Age = 20,
                    FirstName = "TestName1",
                    Gender = Gender.Male,
                },
                new Person
                {
                    Age = 30,
                    FirstName = "TestName2",
                    Gender = Gender.Female,
                },
                new Person
                {
                    Age = 40,
                    FirstName = "TestName3",
                    Gender = Gender.None,
                },
            };

        [Fact]
        public void BinarySerializeAndDeserializePerson_ShouldReturnCorrectObject()
        {
            // Arrange
            byte[] serialized = FakeCustomSerializer<Person>.BinSerialize(person);
            Person deserialized = FakeCustomSerializer<Person>.BinDeserializeObject(serialized);

            // Act
            Person expected = person;

            // Assert
            deserialized.Should().Be(expected);
        }

        [Fact]
        public void BinarySerializeAndDeserializeProduct_ShouldReturnCorrectObject()
        {
            // Arrange
            byte[] serialized = FakeCustomSerializer<Product>.BinSerialize(product);
            Product deserialized = FakeCustomSerializer<Product>.BinDeserializeObject(serialized);

            // Act
            Product expected = product;

            // Assert
            deserialized.Should().Be(expected);
        }

        [Fact]
        public void BinarySerializeAndDeserializeCircle_ShouldReturnCorrectObject()
        {
            // Arrange
            byte[] serialized = FakeCustomSerializer<Circle>.BinSerialize(circle);
            Circle deserialized = FakeCustomSerializer<Circle>.BinDeserializeObject(serialized);

            // Act
            Circle expected = circle;

            // Assert
            deserialized.Should().Be(expected);
        }

        [Fact]
        public void BinarySerializeAndDeserializePersonCollection_ShouldReturnCorrectCollection()
        {
            // Arrange - Act
            byte[] serialized = FakeCustomSerializer<Person>.BinSerialize(people);
            List<Person> deserialized = (List<Person>)FakeCustomSerializer<Person>.BinDeserializeCollection(serialized);

            // Assert
            deserialized.Should().NotBeEmpty().And.HaveCount(3).And.BeEquivalentTo(people);
        }

        [Fact]
        public void BinarySerializeAndDeserializeObject_IfArgumentIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            Person person = null;
            byte[] nullArray = null;

            // Act
            Action action1 = () => { FakeCustomSerializer<Person>.BinSerialize(person); };
            Action action2 = () => { FakeCustomSerializer<Person>.BinDeserializeObject(nullArray); };

            // Assert
            action1.Should().Throw<ArgumentNullException>();
            action2.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void JsonSerializePerson_ShouldReturnCorrectString()
        {
            // Arrange - Act - Assert
            FakeCustomSerializer<Person>.JsonSerialize(person).Should().Be(jsonPerson);
        }

        [Fact]
        public void JsonDeserializePerson_ShouldReturnCorrectObject()
        {
            // Arrange - Act
            Person testPerson = FakeCustomSerializer<Person>.JsonDeserializeObject(jsonPerson);

            // Assert
            testPerson.Should().Be(person);
        }

        [Fact]
        public void JsonSerializeCircle_ShouldReturnCorrectObject()
        {
            // Arrange - Act
            string serialized = FakeCustomSerializer<Circle>.JsonSerialize(circle);

            // Assert
            serialized.Should().Be(jsonCircle);
        }

        [Fact]
        public void JsonDeserializeCircle_ShouldReturnCorrectObject()
        {
            // Arrange - Act
            Circle deserialized = FakeCustomSerializer<Circle>.JsonDeserializeObject(jsonCircle);

            // Assert
            deserialized.Should().Be(circle);
        }

        [Fact]
        public void JsonSerializeProduct_ShouldReturnCorrectObject()
        {
            // Arrange - Act
            string serialized = FakeCustomSerializer<Product>.JsonSerialize(product);

            // Assert
            serialized.Should().Be(jsonProduct);
        }

        [Fact]
        public void JsonDeserializeProduct_ShouldReturnCorrectObject()
        {
            // Arrange - Act
            Product deserialized = FakeCustomSerializer<Product>.JsonDeserializeObject(jsonProduct);

            // Assert
            deserialized.Should().Be(product);
        }

        [Fact]
        public void JsonSerializeAndDeserializePersonCollection_ShouldReturnCorrectCollection()
        {
            // Arrange
            string serialized = FakeCustomSerializer<Person>.JsonSerialize(people);

            // Act
            List<Person> deserialized = (List<Person>)FakeCustomSerializer<Person>.JsonDeserializeCollection(serialized);

            // Assert
            deserialized.Should().NotBeEmpty().And.HaveCount(3).And.BeEquivalentTo(people);
        }

        [Fact]
        public void JsonSerializeAndDeserializeObject_IfArgumentIsNull_ShouldReturnArgumentIsNullException()
        {
            // Arrange
            Person person = null;
            string nullString = null;

            // Act
            Action action1 = () => { FakeCustomSerializer<Person>.JsonSerialize(person); };
            Action action2 = () => { FakeCustomSerializer<Person>.JsonDeserializeObject(nullString); };

            // Assert
            action1.Should().Throw<ArgumentNullException>();
            action2.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void XmlSerializePerson_ShouldReturnCorrectString()
        {
            // Arrange - Act
            string objectString = FakeCustomSerializer<Person>.XmlSerialize(person);

            // Assert
            objectString.Should().Be(xmlPerson);
        }

        [Fact]
        public void XmlDeserializePerson_ShouldReturnCorrectObject()
        {
            // Arrange - Act
            Person testPerson = FakeCustomSerializer<Person>.XmlDeserializeObject(xmlPerson);

            // Assert
            testPerson.Should().Be(person);
        }

        [Fact]
        public void XmlSerializeProduct_ShouldReturnCorrectObject()
        {
            // Arrange - Act
            string serialized = FakeCustomSerializer<Product>.XmlSerialize(product);

            // Assert
            serialized.Should().Be(xmlProduct);
        }

        [Fact]
        public void XmlDeserializeProduct_ShouldReturnCorrectObject()
        {
            // Arrange - Act
            Product testProduct = FakeCustomSerializer<Product>.XmlDeserializeObject(xmlProduct);

            // Assert
            testProduct.Should().Be(product);
        }

        [Fact]
        public void XmlSerializeCircle_ShouldReturnCorrectObject()
        {
            // Arrange - Act
            string serialized = FakeCustomSerializer<Circle>.XmlSerialize(circle);

            // Assert
            serialized.Should().Be(xmlCircle);
        }

        [Fact]
        public void XmlDeserializeCircle_ShouldReturnCorrectObject()
        {
            // Arrange - Act
            Product testProduct = FakeCustomSerializer<Product>.XmlDeserializeObject(xmlProduct);

            // Assert
            testProduct.Should().Be(product);
        }

        [Fact]
        public void XmlSerializeAndDeserializeCircle_ShouldReturnCorrectObject()
        {
            // Arrange
            string serialized = FakeCustomSerializer<Circle>.XmlSerialize(circle);
            Circle deserialized = FakeCustomSerializer<Circle>.XmlDeserializeObject(serialized);

            // Act
            Circle expected = circle;

            // Assert
            deserialized.Should().Be(expected);
        }

        [Fact]
        public void XmlSerializeAndDeserializePersonCollection_ShouldReturnCorrectCollection()
        {
            // Arrange
            string serialized = FakeCustomSerializer<Person>.XmlSerialize(people);

            // Act
            List<Person> deserialized = (List<Person>)FakeCustomSerializer<Person>.XmlDeserializeCollection(serialized);

            // Assert
            deserialized.Should().NotBeEmpty().And.HaveCount(3).And.BeEquivalentTo(people);
        }

        [Fact]
        public void XmlSerializeAndDeserializeObject_IfArgumentIsNull_ShouldReturnArgumentIsNullException()
        {
            // Arrange
            Person person = null;
            string nullString = null;

            // Act
            Action action1 = () => { FakeCustomSerializer<Person>.XmlSerialize(person); };
            Action action2 = () => { FakeCustomSerializer<Person>.XmlDeserializeObject(nullString); };

            // Assert
            action1.Should().Throw<ArgumentNullException>();
            action2.Should().Throw<ArgumentNullException>();
        }
    }
}
