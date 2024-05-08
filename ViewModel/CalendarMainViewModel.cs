using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Input;

namespace practice_test_wpf_1
{
    public class CalendarMainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime _selectedMonth;
        public DateTime SelectedMonth
        {
            get { return _selectedMonth; }
            set
            {
                _selectedMonth = value;
                OnPropertyChanged(nameof(SelectedMonth));
            }
        }
         private DaySelect _daySelect;
        public DaySelect DaySelect
        {
            get { return _daySelect; }
            set
            {
                _daySelect = value;
                OnPropertyChanged(nameof(DaySelect));
            }
        }
        private ObservableCollection<DayControl> _daysOfMonth;
        public ObservableCollection<DayControl> DaysOfMonth
        {
            get { return _daysOfMonth; }
            set
            {
                _daysOfMonth = value;
                OnPropertyChanged(nameof(DaysOfMonth));
            }
        }

        public ICommand PreviousMonthCommand { get; private set; }
        public ICommand NextMonthCommand { get; private set; }

        public CalendarMainViewModel()
        {
            SelectedMonth = DateTime.Today;
            UpdateDaysOfMonth();

            PreviousMonthCommand = new RelayCommand(DecrementMonth);
            NextMonthCommand = new RelayCommand(IncrementMonth);
        }

        public void UpdateDaysOfMonth()
        {
            List<DayControl> days = new List<DayControl>();
            int daysInMonth = DateTime.DaysInMonth(SelectedMonth.Year, SelectedMonth.Month);

            for (int i = 1; i <= daysInMonth; i++)
            {
                DateTime date = new DateTime(SelectedMonth.Year, SelectedMonth.Month, i);
                string dateString = date.ToString("dd.MM.yyyy");
                DaySelect daySelect = new DaySelect(dateString, new List<Punct>()); 
                days.Add(new DayControl(date, "", ""));

            }

            DaysOfMonth = new ObservableCollection<DayControl>();
        }



        private void IncrementMonth(object parameter)
        {
            SelectedMonth = SelectedMonth.AddMonths(1);
            UpdateDaysOfMonth();
        }

        private void DecrementMonth(object parameter)
        {
            SelectedMonth = SelectedMonth.AddMonths(-1);
            UpdateDaysOfMonth();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
