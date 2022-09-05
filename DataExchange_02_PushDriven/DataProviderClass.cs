using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace DataExchange_02_PushDriven
{
    class DataProviderClass
    {
        public delegate void MyMessageEvent(object s, MyEventArgs e);
        public event MyMessageEvent NewValueEvent;
        private Random rnd = new Random();
        private Timer timer;

        public void StartGeneratingValues()
        {
            timer = new Timer();
            timer.Interval = rnd.Next(2000, 10000);
            timer.AutoReset = false;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            OnNewValueEvent(rnd.Next(10, 10000000));
            timer.Interval = rnd.Next(2000, 10000);
            timer.Start();
        }

        public virtual void OnNewValueEvent(int value)
        {
            NewValueEvent?.Invoke(this, new MyEventArgs() { Value = value });
        }
    }

    class MyEventArgs : EventArgs
    {
        public int Value { get; set; }
    }
}
