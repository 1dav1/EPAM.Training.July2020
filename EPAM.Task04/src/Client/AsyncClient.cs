using StateClassLibrary;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client
{
    public class AsyncClient
    {
        private const int PORT = 8005;

        // response from the srver
        private string Response { get; set; }

        // message to be sent
        private string Message { get; set; }

        // manual events for thread synchronization
        private ManualResetEvent Connected { get; set; }
        private ManualResetEvent Sent { get; set; }
        private ManualResetEvent Received { get; set; }

        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public AsyncClient(string message = "Test message.<EOF>")
        {
            Connected = new ManualResetEvent(false);
            Sent = new ManualResetEvent(false);
            Received = new ManualResetEvent(false);
            Response = string.Empty;
            Message = message;
        }

        public void StartClient()
        {
            try
            {
                // retreive information about the host by name
                IPHostEntry ipHostInfo = Dns.GetHostEntry("DESKTOP-09ADG3A");

                // get IP address
                IPAddress ipAddress = ipHostInfo.AddressList[2];

                // establish the remote endpoint
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, PORT);
                Socket socket;

                while (true)
                {
                    Connected.Reset();
                    Received.Reset();
                    Sent.Reset();

                    //create new socket
                    socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                    // attempt to connect to the remote endpoint
                    socket.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), socket);
                    Connected.WaitOne();

                    Console.WriteLine("Enter a message:");
                    StringBuilder builder = new StringBuilder(Console.ReadLine());
                    if (builder.ToString().ToUpper() != "QUIT")
                    {
                        Message = builder.Append("<EOF>").ToString();

                        // send the message
                        Send(socket);
                        Sent.WaitOne();

                        // receive a response from server
                        Receive(socket);
                        Received.WaitOne();

                        socket.Shutdown(SocketShutdown.Both);
                        socket.Close();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ConnectCallback(IAsyncResult result)
        {
            try
            {
                // get the socket from the state object
                Socket socket = (Socket)result.AsyncState;

                // complete the connection
                socket.EndConnect(result);
                Connected.Set();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Receive(Socket socket)
        {
            try
            {
                // create new state object for receiving a response and pass the socket to it
                State state = new State
                {
                    Socket = socket,
                };

                // asynchronousely receive a response
                socket.BeginReceive(state.Buffer, 0, state.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ReceiveCallback(IAsyncResult result)
        {
            try
            {
                // get the state object and the socket from the asynchronous result object
                State state = (State)result.AsyncState;
                Socket socket = state.Socket;

                // get the number of the received bytes
                int bytesRead = socket.EndReceive(result);

                state.StringBuilder.Append(Encoding.UTF8.GetString(state.Buffer, 0, bytesRead));

                // if any response received
                if (state.StringBuilder.Length > 1 && state.StringBuilder.ToString().IndexOf("<EOF>") > -1)
                {
                    // remove the <EOF> postfix
                    Response = state.StringBuilder.Replace("<EOF>", string.Empty).ToString();

                    // create EventArgs object to store information about the event
                    MessageReceivedEventArgs args = new MessageReceivedEventArgs
                    {
                        Message = Response,
                    };

                    // call method to invoke the event
                    OnMessageReceived(args);
                }
                Received.Set();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Send(Socket socket)
        {
            byte[] byteData = Encoding.UTF8.GetBytes(Message);

            // send message asynchronousely
            socket.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), socket);
        }

        private void SendCallback(IAsyncResult result)
        {
            try
            {
                // retreive socket from the state object
                Socket socket = (Socket)result.AsyncState;

                int bytesSent = socket.EndSend(result);
                Sent.Set();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // raise the event when a message received
        protected virtual void OnMessageReceived(MessageReceivedEventArgs e)
        {
            EventHandler<MessageReceivedEventArgs> handler = MessageReceived;
            handler?.Invoke(this, e);
        }
    }
}
