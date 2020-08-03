using StateClassLibrary;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace ServerClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="txtlister"]/TxtLister/*'/>
    public class TxtLister
    {
        /// <include file='docs.xml' path='docs/members[@name="txtlister"]/PrepareMessage/*'/>
        public string PrepareMessage(EndPoint point, string message)
        {
            if (point is null || message is null)
                throw new ArgumentNullException();

            StringBuilder stringBuilder = new StringBuilder(IPAddress.Parse(((IPEndPoint)point).Address.ToString()).ToString());
            stringBuilder.Append(": " + message);
            return stringBuilder.ToString();
        }

        /// <include file='docs.xml' path='docs/members[@name="txtlister"]/Handle/*'/>
        public void Handle(AsyncListener listener, string file)
        {
            if (listener is null || file is null)
                throw new ArgumentNullException();

            listener.MessageReceived += (object sender, MessageReceivedEventArgs args) =>
            {
                string message = PrepareMessage(args.EndPoint, args.Message);
                using StreamWriter writer = new StreamWriter(file, true);
                writer.WriteLine(message.ToString());
            };
        }
    }
}
