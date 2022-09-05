using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExchange_03_INotifyPropertyChanged
{
    class Program
    {
        static int localCachedValue;
        static string localCachedName;
        static Data data;

        static void Main(string[] args)
        {
            Console.WriteLine("This is a simple app showing an implementation of PUSH driven data exhange, leveranging the INotifyPropertyChanged interface");

            data = new Data();
            data.PropertyChanged += Data_PropertyChanged;
            data.StartGeneratingValues();
            data.StartGeneratingNames();

            Console.ReadLine();
        }

        private static void Data_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Console.WriteLine("Data property changed: " + e.PropertyName);

            if (e.PropertyName == nameof(Data.Name))
            {
                Console.WriteLine("Local cached name is currently: " + localCachedName);
                localCachedName = data.Name;
                Console.WriteLine("Local cached name is now set to: " + localCachedName);
            }

            if (e.PropertyName == nameof(Data.Value))
            {
                Console.WriteLine("Local cached value is currently: " + localCachedValue);
                localCachedValue = data.Value;
                Console.WriteLine("Local cached value is now set to: " + localCachedValue);
            }

            Console.WriteLine();
        }
    }
}
