using System;
using System.ComponentModel;

namespace practice_test_wpf_1
{
    public class DayControlViewModel : INotifyPropertyChanged
    {
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        private string _imageSource;
        public string ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }

        private string _someTextProperty;
        public string SomeTextProperty
        {
            get { return _someTextProperty; }
            set
            {
                _someTextProperty = value;
                OnPropertyChanged(nameof(SomeTextProperty));
            }
        }

        public DayControlViewModel(DateTime date, string imageSource, string someText)
        {
            Date = date;
            ImageSource = imageSource;
            SomeTextProperty = someText;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
