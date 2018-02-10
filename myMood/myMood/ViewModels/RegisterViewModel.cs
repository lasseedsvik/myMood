﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using myMood.Data;
using System.ComponentModel;
using myMood.Models;

namespace myMood.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public MoodEntry MoodEntry { get; set; }
        public DateTime LowerLimitDate { get; set; }
        public DateTime HighLimitDate { get; set; }

        public Command SaveEntry
        {
            get
            {
                return new Command(() =>
                    App.MoodDatabase.SaveMoodEntry(MoodEntry));
            }
        }

        public RegisterViewModel()
        {
            MoodEntry = App.MoodDatabase.GetMoodEntry(DateTime.Today);
            if (MoodEntry == null)
                MoodEntry = new MoodEntry();
            
            LowerLimitDate = new DateTime(2018, 1, 1);
            HighLimitDate = DateTime.Today;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
