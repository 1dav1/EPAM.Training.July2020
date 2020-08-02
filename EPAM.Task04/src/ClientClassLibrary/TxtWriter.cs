using ClientClassLibrary;
using StateClassLibrary;
using System;
using System.IO;
using System.Text;

namespace Client
{
    public class TxtWriter : Writer
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
                using StreamWriter writer = new StreamWriter(file, true);
                writer.WriteLine(converted);
            };
        }
    }
}
