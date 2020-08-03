using ClientClassLibrary;
using System;

namespace Client
{
    /// <include file='docs.xml' path='docs/members[@name="program"]/Program/*'/>
    public class Program
    {
        static void Main(string[] args)
        {
            AsyncClient client = new AsyncClient();
            Console.WriteLine("Hello.");

            // set up the message handlers
            ConsoleWriter consoleWriter = new ConsoleWriter();
            TxtWriter txtWriter = new TxtWriter();
            BinWriter binWriter = new BinWriter();
            consoleWriter.Handle(client);
            txtWriter.Handle(client, "message.txt");
            binWriter.Handle(client, "message.dat");

            // start the client
            client.StartClient();
        }
    }
}
