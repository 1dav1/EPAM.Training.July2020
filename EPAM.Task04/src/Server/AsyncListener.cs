using StateClassLibrary;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    class AsyncListener
    {
        public static ManualResetEvent Connected { get; set; }
        public AsyncListener()
        {
            Connected = new ManualResetEvent(false);
        }

        public static void StartListening()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[1];
            IPEndPoint endPoint = new IPEndPoint(ipAddress, 8005);

            using Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(endPoint);
            socket.Listen(100);

            while (true)
            {
                Connected.Reset();

                socket.BeginAccept(new AsyncCallback(AcceptCallback), socket);

                Connected.WaitOne();
            }
        }

        public static void AcceptCallback(IAsyncResult asyncResult)
        {
            Connected.Set();

            Socket listener = (Socket)asyncResult.AsyncState;
            Socket handler = listener.EndAccept(asyncResult);

            State state = new State();
            state.Socket = handler;
            handler.BeginReceive(state.Buffer, 0, state.BufferSize, 0, new AsyncCallback(ReadCallback), state);
        }

        public static void ReadCallback(IAsyncResult asyncResult)
        {
            string message = string.Empty;

            State state = (State)asyncResult.AsyncState;
            Socket handler = state.Socket;

            int bytesRead = handler.EndReceive(asyncResult);

            if (bytesRead > 0)
            {
                state.StringBuilder.Append(Encoding.UTF8.GetString(state.Buffer, 0, bytesRead));
                message = state.StringBuilder.ToString();

                /*************change here*****************/
                if (message.IndexOf("<EOF>") > -1)
                {
                    Send(handler, message);
                }
                else
                {
                    // if not all data received
                    handler.BeginReceive(state.Buffer, 0, state.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                }
            }
        }

        private static void Send(Socket handler, string message)
        {
            byte[] byteData = Encoding.UTF8.GetBytes(message);

            handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
        }

        private static void SendCallback(IAsyncResult asyncResult)
        {
            using Socket handler = (Socket)asyncResult.AsyncState;
            int bytesSent = handler.EndSend(asyncResult);

            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
    }
}
