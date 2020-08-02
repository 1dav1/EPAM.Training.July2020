using StateClassLibrary;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace ServerClassLibrary
{
    public class BinLister
    {
        public string PrepareMessage(EndPoint point, string message)
        {
            StringBuilder builder = new StringBuilder(IPAddress.Parse(((IPEndPoint)point).Address.ToString()).ToString());
            builder.Append(": " + message + Environment.NewLine);

            return builder.ToString();
        }
        public void Handle(AsyncListener listener, string file)
        {
            listener.MessageReceived += delegate (object sender, MessageReceivedEventArgs args)
            {
                string str = PrepareMessage(args.EndPoint, args.Message);
                using FileStream stream = new FileStream(file, FileMode.Append, FileAccess.Write, FileShare.None);
                using BinaryWriter binaryWriter = new BinaryWriter(stream);
                binaryWriter.Write(str);
            };
        }
    }
}
