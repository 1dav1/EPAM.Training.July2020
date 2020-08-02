using System;
using System.Net;

namespace StateClassLibrary
{
    // information about the event
    public class MessageReceivedEventArgs : EventArgs
    {
        public EndPoint EndPoint { get; set; }
        public string Message { get; set; }
    }
}
