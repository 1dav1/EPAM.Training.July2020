using ClientClassLibrary;
using System;
using Xunit;

namespace Client.Tests
{
    public class ConsoleWriterTests
    {
        [Fact]
        public void Handle_IfArgumentIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            ConsoleWriter writer = new ConsoleWriter();
            AsyncClient client = null;

            // Act
            Action action = () => writer.Handle(client);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }
    }
}
