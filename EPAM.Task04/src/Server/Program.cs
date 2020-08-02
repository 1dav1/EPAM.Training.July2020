using ServerClassLibrary;
using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncListener listener = new AsyncListener();
            Console.WriteLine("Server is up.");

            // set up the message handlers
            XmlLister lister = new XmlLister();
            TxtLister txtLister = new TxtLister();
            BinLister lister1 = new BinLister();

            lister.Handle(listener, "test.xml");
            txtLister.Handle(listener, "testtxt.txt");
            lister1.Handle(listener, "testbin.dat");

            // start listening incoming requests
            listener.StartListening();
        }
    }
}
