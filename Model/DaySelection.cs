using practice_test_wpf_1;
using System.Collections.ObjectModel;
using System;

public class DaySelection
{
    public DateTime Date { get; set; }
    public ObservableCollection<Punct> SelectedPuncts { get; set; }

    public DaySelection(DateTime date, ObservableCollection<Punct> selectedPuncts)
    {
        Date = date;
        SelectedPuncts = selectedPuncts;
    }
}
