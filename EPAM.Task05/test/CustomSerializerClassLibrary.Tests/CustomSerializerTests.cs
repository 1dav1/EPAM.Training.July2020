using FluentAssertions;
using System;
using Xunit;

namespace CustomSerializerClassLibrary.Tests
{
    public class CustomSerializerTests
    {
        Person person = new Person { Age = 20, FirstName = "TestName", Gender = Gender.Male, };
        Person person1 = new Person { Age = 10, FirstName = "TestName2", Gender = Gender.Female, };
        Person person2 = new Person { Age = 30, FirstName = "TestName3", Gender = Gender.None, };

        [Fact]
        public void Test1()
        {
            byte[] pers = FakeCustomSerializer<Person>.BinSerialize(person);
            Person test = FakeCustomSerializer<Person>.BinDeserializeObject(pers);
            Person expected = person;
            test.Should().Be(expected);
        }
    }
}
