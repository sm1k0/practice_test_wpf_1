using System;
using System.Windows;
using System.Windows.Controls;

namespace practice_test_wpf_1
{
    public partial class DayInfoPage : Page
    {
        private DayInfoViewModel viewModel; 
        private DateTime selectedDate;

        public DayInfoPage(DateTime selectedDate)
        {
            InitializeComponent();
            this.selectedDate = selectedDate; 
            viewModel = new DayInfoViewModel(selectedDate.Date) ;
            DataContext = viewModel;
        }




        private void nazad_bez_save_Click(object sender, RoutedEventArgs e)
        {
            swappage.Swap(new CalendarMain());
        }


        private void nazad_save_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SaveChanges();
        }

    }
}
