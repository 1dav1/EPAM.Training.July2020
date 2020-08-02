using ClientClassLibrary;
using StateClassLibrary;
using System;

namespace Client
{
    public class ConsoleWriter : Writer
    {
        public void Handle(AsyncClient client)
        {
            client.MessageReceived += delegate (object sender, MessageReceivedEventArgs args)
            {
                Console.WriteLine("Received: {0}", Encoder.Encode(args.Message));
            };
        }
    }
}
