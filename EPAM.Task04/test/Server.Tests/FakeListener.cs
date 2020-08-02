using StateClassLibrary;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Server.Tests
{
    // fake listener for testing the functionality
    public class FakeListener
    {
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;
        public string ip = "127.0.0.1";
        public const int PORT = 8005; 

        public void ReadCallback(string message)
        {
            try
            {
                if (message.IndexOf("<EOF>") > -1)
                {
                    EndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), PORT);
                    MessageReceivedEventArgs args = new MessageReceivedEventArgs
                    {
                        Message = message,
                        EndPoint = endPoint,
                    };
                    OnMessageReceived(args);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Connection closed.");
            }
        }

        public virtual void OnMessageReceived(MessageReceivedEventArgs args)
        {
            EventHandler<MessageReceivedEventArgs> handler = MessageReceived;
            handler?.Invoke(this, args);
        }
    }
}
