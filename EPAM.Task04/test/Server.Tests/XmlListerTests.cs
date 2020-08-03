using ServerClassLibrary;
using System;
using Xunit;

namespace Server.Tests
{
    public class XmlListerTests
    {
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
