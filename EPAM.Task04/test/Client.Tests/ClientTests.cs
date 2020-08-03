using StateClassLibrary;
using System;
using Xunit;

namespace Client.Tests
{
    public class ClientTests
    {
        private EventArgs testArgs;
        private readonly string message = "Test message<EOF>";
        //private readonly string ip = "127.0.0.1";

        [Fact]
        public void OnMessageReceived_ShouldInvokeEvent()
        {
            // Arrange
            FakeClient client = new FakeClient();
            testArgs = null;

            // Act
            client.MessageReceived += new EventHandler<MessageReceivedEventArgs>(TestMethod);
            client.ReceiveCallback(message);

            // Assert
            Assert.NotNull(testArgs);
        }

        private void TestMethod(object sender, EventArgs e)
        {
            testArgs = e;
        }
    }
}
