using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread_02
{
    class WorkerClass
    {
        public delegate void MyMessageEvent(object s, MyEventArgs e);
        public event MyMessageEvent MyEvent;

        public void ThreadWork()
        {
            Thread.Sleep(5000);
            OnMyEvent(this, Thread.CurrentThread.Name, "MessageBox message from workerthread");
            Thread.Sleep(5000);
            OnMyEvent(this, Thread.CurrentThread.Name, "Hello from workerthread");
        }

        public virtual void OnMyEvent(object s, string threadName, string message)
        {
            //if (MyEvent == null) return;

            //MyEventArgs myEventArgs = new MyEventArgs() { ThreadName = threadName, Message = message };
            //MyEvent(this, myEventArgs);
            MyEvent?.Invoke(this, new MyEventArgs() { ThreadName = threadName, Message = message });
        }
    }

    class MyEventArgs : EventArgs
    {
        public string ThreadName { get; set; }
        public string Message { get; set; }
    }
}
