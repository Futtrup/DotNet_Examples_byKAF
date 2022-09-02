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

namespace MultiThread_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Thread.CurrentThread.Name = "UI thread";
            Message(Thread.CurrentThread.Name, "Message from UI thread");

            StartThreadWork();
        }

        public void StartThreadWork()
        {
            WorkerClass workObj = new WorkerClass();
            workObj.MyEvent += MyCustomClass_MyEvent;

            Thread workerThread = new Thread(workObj.ThreadWork);

            workerThread.Name = "MyWorkerThread";
            workerThread.IsBackground = true;
            workerThread.Start();
        }

        private void MyCustomClass_MyEvent(object s, MyEventArgs e)
        {
            Message(e.ThreadName, e.Message);
        }

        public void Message(string callerName, string msg)
        {
            if (InvokeRequired)
            {
                textBox1.Invoke(new Action(() =>
                {
                    textBox1.Text = MessageFormatter(callerName, msg);
                }));
            }
            else
            {
                textBox1.Text = MessageFormatter(callerName, msg);
            }
        }

        public string MessageFormatter(string callerName, string msg)
        {
            return "Caller:" + callerName + "  ||  Message:" + msg + "  ||  Thread handling this event:" + Thread.CurrentThread.Name;
        }
    }
}
