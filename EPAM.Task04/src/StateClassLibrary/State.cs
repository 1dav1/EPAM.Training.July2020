using System.Net.Sockets;
using System.Text;

namespace StateClassLibrary
{
    public class State
    {
        public Socket Socket { get; set; }
        public int BufferSize { get; private set; }
        public byte[] Buffer { get; set; }
        public StringBuilder StringBuilder { get; set; }
        public State(int bufferSize = 1024)
        {
            BufferSize = bufferSize;
            Buffer = new byte[bufferSize];
            StringBuilder = new StringBuilder();
        }
    }
}
