using StateClassLibrary;
using System;
using System.IO;
using System.Text;

namespace Client
{
    public class TxtWriter
    {
        public void Handle(AsyncClient client, string file)
        {
            client.MessageReceived += delegate (object sender, MessageReceivedEventArgs args)
            {
                string encoded = Encoder.Encode(args.Message);
                encoded = new StringBuilder(encoded).Insert(0, DateTime.Now.ToString() + ": ").ToString();
                using StreamWriter writer = new StreamWriter(file, true);
                writer.WriteLine(encoded);
            };
        }
    }
}
