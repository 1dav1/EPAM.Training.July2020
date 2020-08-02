using StateClassLibrary;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace ServerClassLibrary
{
    public class TxtLister
    {
        public string Message { get; set; }

        public string PrepareMessage(EndPoint endPoint, string message)
        {
            if (endPoint is null || message is null)
                throw new ArgumentNullException();

            StringBuilder stringBuilder = new StringBuilder(IPAddress.Parse(((IPEndPoint)endPoint).Address.ToString()).ToString());
            stringBuilder.Append(": " + message);
            return stringBuilder.ToString();
        }

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
