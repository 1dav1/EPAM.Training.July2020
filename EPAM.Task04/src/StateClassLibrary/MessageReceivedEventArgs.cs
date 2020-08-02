using System.Net;

namespace StateClassLibrary
{
    // information about the event
    public class MessageReceivedEventArgs
    {
        public EndPoint EndPoint { get; set; }
        public string Message { get; set; }
    }
}
