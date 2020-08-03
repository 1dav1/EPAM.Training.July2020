using System;
using Xunit;

namespace Client.Tests
{
    public class EncoderTests
    {
        private readonly string engMessage = "Test message";
        private readonly string rusMessage = "Тестовое сообщение";

        [Fact]
        public void Encode_IfArgumentIsNotNull_ShouldReturnConvertedString()
        {
            // Arrange
            string engExpected = "Tyestovoye soobshcheniye";
            string rusExpected = "Тэст мэссагэ";

            // Act
            string engResult = Encoder.Encode(rusMessage);
            string rusResult = Encoder.Encode(engMessage);

            // Assert
            engResult.Should().NotBeNullOrEmpty().And.Be(engExpected);
            rusResult.Should().NotBeNullOrEmpty().And.Be(rusExpected);
        }

        [Fact]
        public void Encode_IfArgumentIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            string message = null;

            // Act
            Action action = () => Encoder.Encode(message);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Encode_IfMessageConsistsOfLatinAndCyrillicCharacters_ShouldThrowArgumentException()
        {
            // Arrange
            string message = "Test сообщение";

            // Act
            Action action = () => Encoder.Encode(message);

            // Assert
            action.Should().Throw<ArgumentException>().WithMessage("*Unknown set*");
        }
    }
}
