using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataExchange_01_PullDriven
{
    class DataProviderClass
    {
        public int Value
        {
            get
            {
                lock (this)
                {
                    return _value;
                }
            }
        }
        private int _value = 0;

        Thread thread;
        Random rnd;

        public void StartDataProviding_SepperateThread()
        {
            rnd = new Random();
            thread = new Thread(GenerateData);
            thread.IsBackground = true;
            thread.Start();
        }

        private void GenerateData()
        {
            while (true)
            {
                Thread.Sleep(5000);

                lock (this)
                {
                    _value += rnd.Next(1, 10);
                }
            }
        }
    }
}
