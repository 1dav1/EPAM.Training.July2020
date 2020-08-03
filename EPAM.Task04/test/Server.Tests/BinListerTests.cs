using ServerClassLibrary;
using System;
using System.Net;
using Xunit;

namespace Server.Tests
{
    public class BinListerTests
    {
        private readonly string message = "Test message<EOF>";
        private readonly string ip = "127.0.0.1";

        [Fact]
        public void BinListerPrepareMessage_IfArgumentsAreNotNull_ShouldPrepareMessageForListing()
        {
            // Arrange
            IPEndPoint point = new IPEndPoint(IPAddress.Parse(ip), 8005);
            BinLister lister = new BinLister();
            string expected = "127.0.0.1: Test message<EOF>" + Environment.NewLine;

            // Act
            string result = lister.PrepareMessage(point, message);

            // Assert
            result.Should().NotBeNullOrEmpty().And.Be(expected);
        }

        [Fact]
        public void BinListerPrepareMessage_IfArgumentsAreNull_ShouldThrowArgumentNullException()
        {
            // Arrenge
            BinLister lister = new BinLister();
            IPEndPoint endPoint = null;
            string message = null;

            // Act
            Action action = () => lister.PrepareMessage(endPoint, message);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void BinListerHandle_IfArgumentsAreNull_ShouldThrowArgumentNullException()
        {
            BinLister lister = new BinLister();
            AsyncListener listener = null;
            string file = null;

            // Act
            Action action = () => lister.Handle(listener, file);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }
    }
}
