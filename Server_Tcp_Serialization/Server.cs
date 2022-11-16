using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server_Tcp_Serialization
{
    class Server
    {
        TcpListener listener;
        int port = 13000;

        public Server()
        {

        }

        public void StartServer()
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                Console.WriteLine("Server started...");

                while (true)
                {
                    try
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        Console.WriteLine("Client connected: " + client.Client.RemoteEndPoint);
                        ThreadPool.QueueUserWorkItem(HandleClient, client);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            Console.WriteLine("Hadling communication from client: " + client.Client.RemoteEndPoint);

        }
    }
}
