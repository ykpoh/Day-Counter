using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayCounter.ViewModel
{
    public class CounterModel : INotifyPropertyChanged
    {
        public CounterModel()
        {
            this.Items = new ObservableCollection<CounterGroup>();
        }

        public ObservableCollection<CounterGroup> Items { get; private set; }


        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public CounterGroup MyCounter { get; set; }

        public const string CustomCounterKey = "CustomCounter";
        public bool IsDataLoaded { get; set; }
        public void LoadData()
        {
            //load data into the model
            MyCounter = LoadYourCounter();
            IsDataLoaded = true;
        }

        private CounterGroup LoadYourCounter()
        {
            CounterGroup data;
            string dataFromAppSettings;

            if (IsolatedStorageSettings.ApplicationSettings.TryGetValue(CustomCounterKey, out dataFromAppSettings))
            {
                data = JsonConvert.DeserializeObject<CounterGroup>(dataFromAppSettings);
            }
            else
            {
                data = new CounterGroup();
                data.Title = "My Counter";
            }
            return data;
        }

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

 
