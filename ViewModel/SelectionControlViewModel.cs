using System.ComponentModel;
using System.Windows.Input;

namespace practice_test_wpf_1
{
    public class SelectionControlViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Punct _punct;

        public Punct Punct
        {
            get { return _punct; }
            set
            {
                _punct = value;
                OnPropertyChanged(nameof(Punct));
            }
        }

        public ICommand SelectedCommand { get; private set; }
        public ICommand UnselectedCommand { get; private set; }

        public SelectionControlViewModel(Punct punct)
        {
            Punct = punct;
            SelectedCommand = new RelayCommand(SelectPunct);
            UnselectedCommand = new RelayCommand(UnselectPunct);
        }

        private void SelectPunct(object parameter)
        {
            Punct.selected = true;
        }

        private void UnselectPunct(object parameter)
        {
            Punct.selected = false;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
