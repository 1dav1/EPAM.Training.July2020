using ClientClassLibrary;
using StateClassLibrary;
using System;

namespace Client
{
    /// <include file='docs.xml' path='docs/members[@name="consolewriter"]/ConsoleWriter/*'/>
    public class ConsoleWriter : Writer
    {
        /// <include file='docs.xml' path='docs/members[@name="consolewriter"]/Handle/*'/>
        public void Handle(AsyncClient client)
        {
            if (client is null)
                throw new ArgumentNullException();

            client.MessageReceived += delegate (object sender, MessageReceivedEventArgs args)
            {
                Console.WriteLine("Received: {0}", Encoder.Encode(args.Message));
            };
        }
    }
}
