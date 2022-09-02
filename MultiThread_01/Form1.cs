using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThread_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox1.Text = "Message from UI thread. Thread ID:" + Thread.CurrentThread.ManagedThreadId;

            StartThreadWork();
        }

        public void StartThreadWork()
        {
            Thread thread = new Thread(ThreadWork);
            thread.IsBackground = true;
            thread.Start();
        }

        public void ThreadWork()
        {
            Thread.Sleep(5000);

            textBox1.Invoke(new Action(() =>
            {
                textBox1.Text = "Message from Workerthread. Thread ID:" + Thread.CurrentThread.ManagedThreadId;
            }));

            Thread.Sleep(2000);
            MessageBox.Show("The thread ID is the same as the UI threads, so the thread handling this event must be the UI thread, even though its invoked from the workerthread");
        }
    }
}
