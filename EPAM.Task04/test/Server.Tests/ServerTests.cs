using FluentAssertions;
using ServerClassLibrary;
using StateClassLibrary;
using System;
using System.Net;
using Xunit;

namespace Server.Tests
{
    public class ServerTests
    {
        private EventArgs testArgs;
        private readonly string message = "Test message<EOF>";
        private readonly string ip = "127.0.0.1";

        [Fact]
        public void OnMessageReceived_ShouldInvokeEvent()
        {
            // Arrange
            FakeListener listener = new FakeListener();
            TxtLister lister = new TxtLister();
            string message = "Test message<EOF>";
            testArgs = null;

            // Act
            listener.MessageReceived += new EventHandler<MessageReceivedEventArgs>(TestMethod);
            listener.ReadCallback(message);

            // Assert
            Assert.NotNull(testArgs);
        }

        private void TestMethod(object sender, EventArgs e)
        {
            testArgs = e;
        }

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

        [Fact]
        public void XmlListerHandle_IfArgumentsAreNull_ShouldThrowArgumentNullException()
        {
            XmlLister lister = new XmlLister();
            AsyncListener listener = null;
            string file = null;

            // Act
            Action action = () => lister.Handle(listener, file);

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }
    }
}
