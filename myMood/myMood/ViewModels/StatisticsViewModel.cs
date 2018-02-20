using System;

namespace myMood.ViewModels
{
    public class StatisticsViewModel
    {
        public DateTime MinLimitDate { get; set; }
        public DateTime MaxLimitDate { get; set; }
        public DateTime ChartDate { get; set; }
        public DateTime ChartDateTo { get; set; }

        public StatisticsViewModel()
        {
            MinLimitDate = new DateTime(2018, 1, 1);
            MaxLimitDate = DateTime.Today;
            ChartDate = DateTime.Today.AddDays(-7);
            ChartDateTo = DateTime.Today;
        }
    }
}
