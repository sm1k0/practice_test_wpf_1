using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Newtonsoft.Json;

namespace practice_test_wpf_1
{
    public class DayInfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Punct> _selectedPuncts;
        private List<DaySelect> _choiceDay;
        private readonly string _imagesFolder = "../Helpers/Images";
        private readonly string _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "calendar_info.json");
        private DateTime _selectedDate;
        public ObservableCollection<Punct> SelectedPuncts
        {
            get { return _selectedPuncts; }
            set
            {
                _selectedPuncts = value;
                OnPropertyChanged("SelectedPuncts");
            }
        }
        
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
            }
        }


        public ICommand SaveAndExitCommand { get; private set; }
        public ICommand SaveChangesCommand { get; private set; }
        public DayInfoViewModel(DateTime selectedDate)
        {
            SelectedPuncts = new ObservableCollection<Punct>(GetAllPuncts());

            LoadSelectedPuncts();

            SaveChangesCommand = new RelayCommand(param => SaveChanges());
        }


        private List<Punct> GetAllPuncts()
        {
            return new List<Punct>
            {
                new Punct("Луна", Path.Combine(_imagesFolder, "moon.png"), false),
                new Punct("Венера", Path.Combine(_imagesFolder, "venus.png"), false),
                new Punct("Юпитер", Path.Combine(_imagesFolder, "juptr.png"), false),
                new Punct("Сатурн", Path.Combine(_imagesFolder, "saturn.png"), false),
                new Punct("Марс", Path.Combine(_imagesFolder, "mars.png"), false),
                new Punct("Меркурий", Path.Combine(_imagesFolder, "mercury.png"), false)
            };
        }

        private void LoadSelectedPuncts()
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                _choiceDay = JsonConvert.DeserializeObject<List<DaySelect>>(json);
                if (_choiceDay != null && _choiceDay.Count > 0)
                {
                    var todayChoice = _choiceDay.FirstOrDefault(day => day.date == DateTime.Now.ToString("dd.MM.yyyy"));
                    if (todayChoice != null)
                    {
                        foreach (var punct in todayChoice.puncts)
                        {
                            var existingPunct = SelectedPuncts.FirstOrDefault(p => p.name == punct.name);
                            if (existingPunct != null)
                            {
                                existingPunct.selected = punct.selected;
                            }
                        }
                    }
                }
            }
        }

        public void SaveChanges()
        {
            List<Punct> selected = SelectedPuncts.Where(item => item.selected).ToList();
            DaySelect daySelect = _choiceDay.Find(item => item.date == DateTime.Now.ToString("dd.MM.yyyy"));

            if (daySelect == null)
            {
                daySelect = new DaySelect(DateTime.Now.ToString("dd.MM.yyyy"), selected);
                _choiceDay.Add(daySelect);
            }
            else
            {
                daySelect.puncts = selected;
            }

            string json = JsonConvert.SerializeObject(_choiceDay);
            File.WriteAllText(_filePath, json);

            swappage.Swap(new CalendarMain());
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
