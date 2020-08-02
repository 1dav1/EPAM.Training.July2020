using ClientClassLibrary;
using StateClassLibrary;
using System;
using System.IO;
using System.Text;

namespace Client
{
    // writes the received message to binary file
    public class BinWriter : Writer
    {
        public string PrepareMessage(string message)
        {
            StringBuilder builder = new StringBuilder(DateTime.Now.ToString());
            return builder.Append(": " + Encoder.Encode(message)).ToString();
        }

        public void Handle(AsyncClient client, string file)
        {
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
