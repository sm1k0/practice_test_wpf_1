using System;
using System.Windows.Controls;

namespace practice_test_wpf_1
{
    public partial class DayControl : UserControl
    {
        public DayControlViewModel ViewModel { get; set; }

        public DayControl(DateTime date) : this(date, "", "")
        {
        }

        public DayControl(DateTime date, string imageSource, string someText)
        {
            InitializeComponent();
            ViewModel = new DayControlViewModel(date, imageSource, someText);
            DataContext = ViewModel;
            Day.Content = date.Day;
        }

    }
}
