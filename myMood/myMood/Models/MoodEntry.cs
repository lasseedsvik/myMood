using SQLite;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace myMood.Models
{
    [Table("MoodEntries")]
    public class MoodEntry
    {
        [PrimaryKey, AutoIncrement, Column("MoodEntryID")]
        public int MoodEntryID { get; set; }

        [Indexed, NotNull]
        public DateTime EntryDate { get; set; }

        [NotNull]
        public double Stress { get; set; }

        [NotNull]
        public double Sleep { get; set; }

        [NotNull]
        public double AchivedGoals { get; set; }
        public string Comment { get; set; }
        
        public MoodEntry()
        {
            Stress = 1;
            Sleep = 3;
            AchivedGoals = 3;
            EntryDate = DateTime.Today;
        }
    }
}
