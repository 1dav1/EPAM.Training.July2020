using StateClassLibrary;
using System;
using System.IO;
using System.Text;

namespace Client
{
    // writes the received message to binary file
    public class BinWriter
    {
        public void Handle(AsyncClient client, string file)
        {
            client.MessageReceived += delegate (object sender, MessageReceivedEventArgs args)
            {
                string encoded = Encoder.Encode(args.Message);
                encoded = new StringBuilder(encoded).Insert(0, DateTime.Now.ToString() + ": ").ToString();
                using FileStream stream = new FileStream(file, FileMode.Append, FileAccess.Write, FileShare.None);
                using BinaryWriter binaryWriter = new BinaryWriter(stream);
                binaryWriter.Write(encoded);
            };
        }
    }
}
