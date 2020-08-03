using StateClassLibrary;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServerClassLibrary
{
    /// <include file='docs.xml' path='docs/members[@name="asynclistener"]/AsyncListener/*'/>
    public class AsyncListener
    {
        private static ManualResetEvent Connected { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="asynclistener"]/MessageReceived/*'/>
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        /// <include file='docs.xml' path='docs/members[@name="asynclistener"]/Constructor/*'/>
        public AsyncListener()
        {
            Connected = new ManualResetEvent(false);
            ServicePointManager.DefaultConnectionLimit = 10;
        }

        /// <include file='docs.xml' path='docs/members[@name="asynclistener"]/StartListening/*'/>
        public void StartListening()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[2];
            IPEndPoint endPoint = new IPEndPoint(ipAddress, 8005);

            Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Bind(endPoint);
                socket.Listen(100);

                while (true)
                {
                    Connected.Reset();

                    if (socket.Connected == false)
                    {
                        socket.BeginAccept(new AsyncCallback(AcceptCallback), socket);
                    }
                    else
                    {
                        Connected.Set();
                    }

                    Connected.WaitOne();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AcceptCallback(IAsyncResult asyncResult)
        {
            Connected.Set();

            Socket listener = (Socket)asyncResult.AsyncState;
            Socket handler = listener.EndAccept(asyncResult);

            State state = new State
            {
                Socket = handler
            };
            handler.BeginReceive(state.Buffer, 0, state.BufferSize, 0, new AsyncCallback(ReadCallback), state);
        }

        private void ReadCallback(IAsyncResult asyncResult)
        {
            string message = string.Empty;

            State state = (State)asyncResult.AsyncState;
            Socket handler = state.Socket;

            try
            {
                int bytesRead = handler.EndReceive(asyncResult);

                if (bytesRead > 0)
                {
                    state.StringBuilder.Append(Encoding.UTF8.GetString(state.Buffer, 0, bytesRead));
                    message = state.StringBuilder.ToString();

                    if (message.IndexOf("<EOF>") > -1)
                    {
                        MessageReceivedEventArgs args = new MessageReceivedEventArgs
                        {
                            Message = message,
                            EndPoint = handler.RemoteEndPoint,
                        };
                        OnMessageReceived(args);
                        Send(handler, message);
                    }
                    else
                    {
                        // if not all data received
                        handler.BeginReceive(state.Buffer, 0, state.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                    }
                }
            }
            catch (Exception)
            {
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
        }

        private void Send(Socket handler, string message)
        {
            byte[] byteData = Encoding.UTF8.GetBytes(message);

            handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
        }

        private static void SendCallback(IAsyncResult asyncResult)
        {
            try
            {
                Socket handler = (Socket)asyncResult.AsyncState;
                int bytesSent = handler.EndSend(asyncResult);


                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch (Exception) { }
        }

        /// <include file='docs.xml' path='docs/members[@name="asynclistener"]/OnMessageReceived/*'/>
        public virtual void OnMessageReceived(MessageReceivedEventArgs args)
        {
            EventHandler<MessageReceivedEventArgs> handler = MessageReceived;
            handler?.Invoke(this, args);
        }
    }
}
