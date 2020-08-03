using ClientClassLibrary;
using StateClassLibrary;
using System;
using System.IO;
using System.Text;

namespace Client
{
    // writes the received message to binary file
    /// <include file='docs.xml' path='docs/members[@name="binwriter"]/BinWriter/*'/>
    public class BinWriter : Writer
    {
        /// <include file='docs.xml' path='docs/members[@name="binwriter"]/PrepareMessage/*'/>
        public string PrepareMessage(string message)
        {
            if (message is null)
                throw new ArgumentNullException();

            StringBuilder builder = new StringBuilder(DateTime.Now.ToString());
            return builder.Append(": " + Encoder.Encode(message)).ToString();
        }

        /// <include file='docs.xml' path='docs/members[@name="binwriter"]/Handle/*'/>
        public void Handle(AsyncClient client, string file)
        {
            if (client is null || file is null)
                throw new ArgumentNullException();

            client.MessageReceived += delegate (object sender, MessageReceivedEventArgs args)
            {
                string converted = PrepareMessage(args.Message);
                using FileStream stream = new FileStream(file, FileMode.Append, FileAccess.Write, FileShare.None);
                using BinaryWriter binaryWriter = new BinaryWriter(stream);
                binaryWriter.Write(converted);
            };
        }
    }
}
