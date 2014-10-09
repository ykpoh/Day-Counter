using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayCounter.ViewModel
{
    public class CounterData : INotifyPropertyChanged
    {
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        private DateTime _date;
        public DateTime Date {
            get
            {
                return _date;
            }
            set
            {
                if (value != _date)
                {
                    _date = value;
                    NotifyPropertyChanged("Date");
                }
            }
        }

        private string _days;
        public string Days 
        {
            get
            {
                return _days;
            }
            set
            {
                if (value != _days)
                {
                    _days = value;
                    NotifyPropertyChanged("Days");
                }
            }
        }

        private string _displaydate;
        public string DisplayDate
        {
            get
            {
                return _displaydate;
            }
            set
            {
                if (value != _displaydate)
                {
                    _displaydate = value;
                    NotifyPropertyChanged("DisplayDate");
                }
            }
        }

        private string _filepath;
        public string FilePath 
        {
            get
            {
                return _filepath;
            }
            set
            {
                if (value != _filepath)
                {
                    _filepath = value;
                    NotifyPropertyChanged("FilePath");
                }
            }
        }

        private TimeSpan _originaldays;
        public TimeSpan OriginalDays
        {
            get
            {
                return _originaldays;
            }
            set
            {
                if (value != _originaldays)
                {
                    _originaldays = value;
                    NotifyPropertyChanged("OriginalDays");
                }
            }
        }

        private string _description;
        public string Description 
        {
            get
            {
                return _description;
            }
            set
            {
                if (value != _description)
                {
                    _description = value;
                    NotifyPropertyChanged("Description");
                }
            }
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
