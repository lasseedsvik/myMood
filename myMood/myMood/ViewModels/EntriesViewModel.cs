using myMood.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace myMood.ViewModels
{
    public class EntriesViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<MoodEntry> _moodEntries;
        public ObservableCollection<MoodEntry> MoodEntries
        {
            get { return _moodEntries; }
            set { _moodEntries = value; OnPropertyChanged(); }
        }

        public EntriesViewModel()
        {
            MoodEntries = new ObservableCollection<MoodEntry>(App.MoodDatabase.GetMoodEntries());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
