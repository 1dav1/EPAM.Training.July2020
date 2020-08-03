using ClientClassLibrary;
using System;
using Xunit;

namespace Client.Tests
{
    public class TxtWriterTests
    {
        private readonly string message = "Test message<EOF>";
        //private readonly string rusMessage = "Тестовое сообщение<EOF>";

        [Fact]
        public void TxtWriterPrepareMessage_IfArgumentsAreNotNull_ShouldPrepareMessageForWriting()
        {
            // Arrange
            TxtWriter writer = new TxtWriter();
            string expected = "Тэст мэссагэ";

            // Act
            string result = writer.PrepareMessage(message);

            // Assert
            result.Should().NotBeNullOrEmpty().And.Be(expected);
        }

        [Fact]
        public void TxtWriterPrepareMessage_IfArgumentsAreNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            TxtWriter writer = new TxtWriter();
            string nullMessage = null;

            // Act
            Action action = () => writer.PrepareMessage(nullMessage);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TxtWriterHandle_IfArgumentsAreNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            AsyncClient client = null;
            string file = null;
            TxtWriter writer = new TxtWriter();

            // Act
            Action action = () => writer.Handle(client, file);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }
    }
}
