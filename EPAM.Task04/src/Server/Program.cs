using ServerClassLibrary;
using System;

namespace Server
{
    /// <include file='docs.xml' path='docs/members[@name="program"]/Program/*'/>
    public class Program
    {
        static void Main(string[] args)
        {
            AsyncListener listener = new AsyncListener();
            Console.WriteLine("Server is up.");

            // set up the message handlers
            XmlLister xmlLister = new XmlLister();
            TxtLister txtLister = new TxtLister();
            BinLister binLister = new BinLister();

            xmlLister.Handle(listener, "test.xml");
            txtLister.Handle(listener, "testtxt.txt");
            binLister.Handle(listener, "testbin.dat");

            // start listening for incoming requests
            listener.StartListening();
        }
    }
}
