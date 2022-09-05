using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExchange_02_PushDriven
{
    class Program
    {
        static int localCachedValue;
        static DataProviderClass dataProvider;

        static void Main(string[] args)
        {
            Console.WriteLine("This is a simple app showing an implementation of PUSH driven data exhange");

            dataProvider = new DataProviderClass();
            dataProvider.NewValueEvent += DataProvider_NewValueEvent;
            dataProvider.StartGeneratingValues();

            Console.ReadLine();
        }

        private static void DataProvider_NewValueEvent(object s, MyEventArgs e)
        {
            Console.WriteLine("New value recieved from data provider object: " + e.Value);
            localCachedValue = e.Value;
        }
    }
}
