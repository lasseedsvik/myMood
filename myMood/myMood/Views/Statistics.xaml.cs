using myMood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts.Forms;
using SkiaSharp;
using Microcharts;
using Entry = Microcharts.Entry;
using myMood.ViewModels;
using myMood.Helpers;

namespace myMood.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Statistics : ContentPage
    {
        public Statistics()
        {
            InitializeComponent();
            
            var vm = new StatisticsViewModel();

            UpdateCharts(vm.ChartDate, vm.ChartDateTo);

            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            var vm = new StatisticsViewModel();

            UpdateCharts(vm.ChartDate, vm.ChartDateTo);

            BindingContext = vm;
        }

        private void UpdateCharts(DateTime chartDate, DateTime chartDateTo)
        {
            Chart1.Chart = new BarChart() {
                MaxValue = 5,
                LabelTextSize = 24,
                Entries = GetSleepEntries(chartDate, chartDateTo)
            };

            Chart2.Chart = new BarChart() {
                MaxValue = 5,
                LabelTextSize = 24,
                Entries = GetStressEntries(chartDate, chartDateTo)
            };

            Chart3.Chart = new BarChart() {
                MaxValue = 5,
                LabelTextSize = 24,
                Entries = GetAchivedGoalsEntries(chartDate, chartDateTo)
            };
        }

        private void ChartDateChanged(object sender, DateChangedEventArgs e)
        {
            var chartDate = e.NewDate;
            var chartDateTo = e.NewDate.AddDays(7);
            var vm = new StatisticsViewModel()
            {
                ChartDate = chartDate,
                ChartDateTo = chartDateTo
            };
    
            UpdateCharts(chartDate, chartDateTo);

            BindingContext = vm;
        }

        private List<Entry> GetSleepEntries(DateTime startDate, DateTime endDate)
        {
            var entries = App.MoodDatabase.GetMoodentries(startDate, endDate);
            var sleepentries = new List<Entry>();

            foreach (var e in entries)
            {
                sleepentries.Add(new Entry((float)e.Sleep)
                {
                    Color = SKColor.Parse("#266489"),
                    Label = FormatHelpers.FormatSliderValue(e.Sleep, 0.1),
                    ValueLabel = e.EntryDate.ToString("d/M")
                });
            }                

            return sleepentries;
        }

        private List<Entry> GetStressEntries(DateTime startDate, DateTime endDate)
        {
            var entries = App.MoodDatabase.GetMoodentries(startDate, endDate);
            var stressentries = new List<Entry>();

            foreach (var e in entries)
            {
                stressentries.Add(new Entry((float)e.Stress)
                {
                    Color = SKColor.Parse("#90D585"),
                    Label = FormatHelpers.FormatSliderValue(e.Stress, 0.1),
                    ValueLabel = e.EntryDate.ToString("d/M")
                });
            }

            return stressentries;
        }

        private List<Entry> GetAchivedGoalsEntries(DateTime startDate, DateTime endDate)
        {
            var entries = App.MoodDatabase.GetMoodentries(startDate, endDate);
            var goalentries = new List<Entry>();

            foreach (var e in entries)
            {
                goalentries.Add(new Entry((float)e.AchivedGoals)
                {
                    Color = SKColor.Parse("#68B9C0"),
                    Label = FormatHelpers.FormatSliderValue(e.AchivedGoals, 0.1),
                    ValueLabel = e.EntryDate.ToString("d/M")
                });
            }

            return goalentries;
        }
    }
}