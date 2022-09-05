using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DataExchange_03_INotifyPropertyChanged
{
    class Data : INotifyPropertyChanged
    {
        private int _value;
        public int Value
        {
            get => _value;
            set => SetField(ref _value, value);
        }

        private string _name;

        public string Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        private Random rnd = new Random();
        private Timer timer1;
        public void StartGeneratingValues()
        {
            timer1 = new Timer();
            timer1.Interval = rnd.Next(2000, 10000);
            timer1.AutoReset = false;
            timer1.Elapsed += Timer1_Elapsed;
            timer1.Start();
        }

        private void Timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            Value = rnd.Next(1, 100);
            timer1.Interval = rnd.Next(2000, 10000);
            timer1.Start();
        }

        private Timer timer2;
        private List<string> names = new List<string> { "Jess", "Jay", "Jen", "Jack", "Jan" };
        public void StartGeneratingNames()
        {
            timer2 = new Timer();
            timer2.Interval = rnd.Next(2000, 10000);
            timer2.AutoReset = false;
            timer2.Elapsed += Timer2_Elapsed;
            timer2.Start();
        }

        private void Timer2_Elapsed(object sender, ElapsedEventArgs e)
        {
            Name = names.OrderBy(a => rnd.NextDouble()).First();
            timer2.Interval = rnd.Next(2000, 10000);
            timer2.Start();
        }
    }
}
