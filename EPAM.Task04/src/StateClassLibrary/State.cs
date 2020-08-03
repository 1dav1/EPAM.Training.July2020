using System.Net.Sockets;
using System.Text;

namespace StateClassLibrary
{
    // state object for storing data and passing it to callback functions at asynchronous server and client
    /// <include file='docs.xml' path='docs/members[@name="state"]/State/*'/>
    public class State
    {
        /// <include file='docs.xml' path='docs/members[@name="state"]/State/*'/>
        public Socket Socket { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="state"]/BufferSize/*'/>
        public int BufferSize { get; private set; }

        /// <include file='docs.xml' path='docs/members[@name="state"]/Buffer/*'/>
        public byte[] Buffer { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="state"]/StringBuilder/*'/>
        public StringBuilder StringBuilder { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="state"]/Constructor/*'/>
        public State(int bufferSize = 1024)
        {
            BufferSize = bufferSize;
            Buffer = new byte[bufferSize];
            StringBuilder = new StringBuilder();
        }
    }
}
