using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataExchange_01_PullDriven
{
    class Program
    {
        static int localCachedValue;
        static DataProviderClass dataProvider;

        static void Main(string[] args)
        {
            Console.WriteLine("This is a simple app showing an implementation of PULL driven data exhange");

            dataProvider = new DataProviderClass();
            dataProvider.StartDataProviding_SepperateThread();

            StartPullingData();
        }

        static void StartPullingData()
        {
            Console.WriteLine("Star reading data every 2 seconds...");
            int interval = 2000;            
            while (true)
            {
                Thread.Sleep(interval);
                localCachedValue = dataProvider.Value;
                Console.WriteLine("Read value:" + localCachedValue);
            }
        }
    }
}
