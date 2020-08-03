using ClientClassLibrary;
using StateClassLibrary;
using System;
using System.IO;
using System.Text;

namespace Client
{
    /// <include file='docs.xml' path='docs/members[@name="txtwriter"]/TxtWriter/*'/>
    public class TxtWriter : Writer
    {
        /// <include file='docs.xml' path='docs/members[@name="txtwriter"]/PrepareMessage/*'/>
        public string PrepareMessage(string message)
        {
            if (message is null)
                throw new ArgumentNullException();

            StringBuilder builder = new StringBuilder(DateTime.Now.ToString());
            return builder.Append(": " + Encoder.Encode(message)).ToString();
        }

        /// <include file='docs.xml' path='docs/members[@name="txtwriter"]/Handle/*'/>
        public void Handle(AsyncClient client, string file)
        {
            if (client is null || file is null)
                throw new ArgumentNullException();

            client.MessageReceived += delegate (object sender, MessageReceivedEventArgs args)
            {
                string converted = PrepareMessage(args.Message);
                using StreamWriter writer = new StreamWriter(file, true);
                writer.WriteLine(converted);
            };
        }
    }
}
