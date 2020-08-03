using ServerClassLibrary;
using System;
using System.Net;
using Xunit;

namespace Server.Tests
{
    public class TxtListerTests
    {
        private readonly string message = "Test message<EOF>";
        private readonly string ip = "127.0.0.1";

        [Fact]
        public void TxtListerPrepareMessage_IfArgumentsAreNotNull_ShouldPrepareMessageForListing()
        {
            // Arrange
            IPEndPoint point = new IPEndPoint(IPAddress.Parse(ip), 8005);
            TxtLister lister = new TxtLister();
            string expected = "127.0.0.1: Test message<EOF>";

            // Act
            string result = lister.PrepareMessage(point, message);

            // Assert
            result.Should().NotBeNullOrEmpty().And.Be(expected);
        }

        [Fact]
        public void TxtListerPrepareMessage_IfArgumentsAreNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            TxtLister lister = new TxtLister();
            IPEndPoint endPoint = null;
            string message = null;

            // Act
            Action action = () => lister.PrepareMessage(endPoint, message);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void TxtListerHandle_IfArgumentsAreNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            TxtLister lister = new TxtLister();
            AsyncListener listener = null;
            string file = null;

            // Act
            Action action = () => lister.Handle(listener, file);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }
    }
}
