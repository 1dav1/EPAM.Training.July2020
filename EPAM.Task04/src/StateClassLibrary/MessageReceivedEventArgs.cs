using System;
using System.Net;

namespace StateClassLibrary
{
    // information about the event
    /// <include file='docs.xml' path='docs/members[@name="args"]/Args/*'/>
    public class MessageReceivedEventArgs : EventArgs
    {
        /// <include file='docs.xml' path='docs/members[@name="args"]/EndPoint/*'/>
        public EndPoint EndPoint { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="args"]/Message/*'/>
        public string Message { get; set; }
    }
}
