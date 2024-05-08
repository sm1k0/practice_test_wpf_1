using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using System.Globalization;

namespace practice_test_wpf_1
{
    public partial class CalendarMain : Page
    {
        private CalendarMainViewModel viewModel;
        List<DaySelect> daySelects;
        public static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string filePath = System.IO.Path.Combine(desktopPath, "calendar_info.json");
        public CalendarMain()
        {
            InitializeComponent();
            viewModel = new CalendarMainViewModel();
            DataContext = viewModel;

            daySelects = tudasuda.deser<List<DaySelect>>(filePath);

        }

        private DateTime GetToDay(int day)
        {
            string monthText = MonthSelect.Text;
            DateTime month;

            if (DateTime.TryParseExact(monthText, "MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out month))
            {
                return new DateTime(month.Year, month.Month, day);
            }
            else
            {
                throw new FormatException("Invalid date format");
            }
        }


        private void nazad_data_Click(object sender, RoutedEventArgs e)
        {
            viewModel.PreviousMonthCommand.Execute(null);
        }

        private void vpered_data_Click(object sender, RoutedEventArgs e)
        {
            viewModel.NextMonthCommand.Execute(null);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            int index = chisla_month.SelectedIndex;

            if (index == -1)
            {
                return;
            }

            int day = index + 1;
            DateTime date = GetToDay(day);

            daySelects.Remove(daySelects.Find((item) => item.date == date.ToString("dd.MM.yyyy")));

            tudasuda.ser(filePath, daySelects);

            viewModel.UpdateDaysOfMonth();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            int index = chisla_month.SelectedIndex;

            if (index == -1)
            {
                return;
            }

            int day = index + 1;
            DateTime date = GetToDay(day);

            swappage.Swap(new DayInfoPage(date));
        }

        private void ListBoxItem_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                var listBoxItem = sender as ListBoxItem;

                if (listBoxItem != null)
                {
                    int index = chisla_month.SelectedIndex;

                    if (index == -1)
                    {
                        return;
                    }

                    int day = index + 1;
                    DateTime date = GetToDay(day);
                    swappage.Swap(new DayInfoPage(date));
                }
            }

        }

        private void MonthSelect_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime smena_data = Convert.ToDateTime(MonthSelect.Text);
            MonthLabel.Content = smena_data.ToString("MMMM, yyyy");
            viewModel.UpdateDaysOfMonth();
        }
    }
}
