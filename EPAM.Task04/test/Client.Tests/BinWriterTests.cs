using ClientClassLibrary;
using System;
using Xunit;

namespace Client.Tests
{
    public class BinWriterTests
    {
        private readonly string message = "Test message<EOF>";

        [Fact]
        public void BinWriterPrepareMessage_IfArgumentsAreNotNull_ShouldPrepareMessageForWriting()
        {
            // Arrange
            BinWriter writer = new BinWriter();
            string expected = "Тэст мэссагэ";

            // Act
            string result = writer.PrepareMessage(message);

            // Assert
            result.Should().NotBeNullOrEmpty().And.Be(expected);
        }

        [Fact]
        public void BinWriterPrepareMessage_IfArgumentsAreNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            BinWriter writer = new BinWriter();
            string nullMessage = null;

            // Act
            Action action = () => writer.PrepareMessage(nullMessage);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void BinWriterHandle_IfArgumentsAreNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            AsyncClient client = null;
            string file = null;
            BinWriter writer = new BinWriter();

            // Act
            Action action = () => writer.Handle(client, file);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }
    }
}
