using System.Windows.Controls;

namespace practice_test_wpf_1
{
    public partial class SelectionControl : UserControl
    {
        public SelectionControl()
        {
            InitializeComponent();
            DataContext = new SelectionControlViewModel(new Punct("", "", false)); 
        }
    }
}
