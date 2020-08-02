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
        private static ManualResetEvent Connected { get; set; }
        private static ManualResetEvent Sent { get; set; }
        private static ManualResetEvent Received { get; set; }
        private static string response;
        private static string Message { get; set; }

        public delegate string MessageHandler(string message);
        public static event MessageHandler Encode;

        public AsyncClient(string message = "Test message.<EOF>")
        {
            Connected = new ManualResetEvent(false);
            Sent = new ManualResetEvent(false);
            Received = new ManualResetEvent(false);
            response = string.Empty;
            Message = message;
        }

        public static void StartClient()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry("DESKTOP-09ADG3A");
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, PORT);

            using Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            socket.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), socket);
            Connected.WaitOne();

            Send(socket, Message);
            Sent.WaitOne();

            Receive(socket);
            Received.WaitOne();

            Console.WriteLine("Received: {0}", response);

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }

        private static void ConnectCallback(IAsyncResult result)
        {
            using Socket socket = (Socket)result.AsyncState;
            socket.EndConnect(result);
            Connected.Set();
        }

        private static void Receive(Socket socket)
        {
            try
            {
                State state = new State
                {
                    Socket = socket
                };

                socket.BeginReceive(state.Buffer, 0, state.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ReceiveCallback(IAsyncResult result)
        {
            try
            {
                State state = (State)result.AsyncState;
                Socket socket = state.Socket;
                int bytesRead = socket.EndReceive(result);

                if (bytesRead > 0)
                {
                    state.StringBuilder.Append(Encoding.UTF8.GetString(state.Buffer, 0, bytesRead));
                    socket.BeginReceive(state.Buffer, 0, state.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    if (state.StringBuilder.Length > 1)

                        /*****************************************************/
                        /*******************change here***********************/
                        /*****************************************************/
                        response = state.StringBuilder.ToString();
                    response = Encode?.Invoke(response);
                }
                Received.Set();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Send(Socket socket, string message)
        {
            byte[] byteData = Encoding.UTF8.GetBytes(message);
            socket.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), socket);
        }

        private static void SendCallback(IAsyncResult result)
        {
            using Socket socket = (Socket)result.AsyncState;

            int bytesSent = socket.EndSend(result);
            Sent.Set();
        }
    }
}
