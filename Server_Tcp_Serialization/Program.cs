using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server_Tcp_Serialization
{
    class Program
    {
        static Server srv;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Tcp Server listening for Tcp Clients for Deserialization of objects");

            srv = new Server();
            Thread srvThread = new Thread(srv.StartServer);
            srvThread.IsBackground = false;
            srvThread.Start();

            Console.ReadLine();
        }
    }
}
