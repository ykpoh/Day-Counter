using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayCounter.ViewModel
{
    public class CounterGroup : INotifyPropertyChanged
    {
        public CounterGroup()
        {
            Items = new List<CounterData>();
        }
        public List<CounterData> Items { get; set; }
        public string Title { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
