using StateClassLibrary;
using System;
using Xunit;

namespace Server.Tests
{
    public class ServerTests
    {
        private EventArgs testArgs;

        [Fact]
        public void OnMessageReceived_ShouldInvokeEvent()
        {
            // Arrange
            FakeListener listener = new FakeListener();
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
    }
}
