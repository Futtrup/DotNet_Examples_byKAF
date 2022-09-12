using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_01_TCP
{
    public partial class Form1 : Form
    {
        TcpListener listener;
        TcpClient client;

        public Form1()
        {
            InitializeComponent();

            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Debug("Server app starting...");
            Thread srvThread = new Thread(StartServer);
            srvThread.IsBackground = true;
            srvThread.Start();
        }

        private void StartServer()
        {
            listener = new TcpListener(IPAddress.Any, 8000);
            listener.Start();

            Debug("Listening for client on port 8000");

            while (true)
            {
                try
                {
                    client = listener.AcceptTcpClient();
                    ThreadPool.QueueUserWorkItem(ClientHandler, client);
                }
                catch (Exception ex)
                {
                    Debug(ex.Message);
                }
            }
        }

        private void ClientHandler(object obj)
        {
            using (var client = (TcpClient)obj)
            using (var stream = client.GetStream())
            {
                Debug("Client connected: " + client.Client.RemoteEndPoint);

                if (stream.CanRead)
                {
                    byte[] buf = new byte[1024];
                    int received = stream.Read(buf, 0, buf.Length);
                    string clientMessage = Encoding.ASCII.GetString(buf, 0, received);
                    Debug("Message from client: " + clientMessage);
                }
                else
                {
                    MessageBox.Show("Sorry.  You cannot read from this NetworkStream.");
                }

                Debug("Client disconnected: " + client.Client.RemoteEndPoint);
            }
        }

        public void Debug(string msg)
        {
            if (lstBx_ConLog.InvokeRequired)
                lstBx_ConLog.Invoke(new Action(() => lstBx_ConLog.Items.Add(msg)));
            else
                lstBx_ConLog.Items.Add(msg);
        }
    }
}
