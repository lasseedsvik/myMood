using myMood.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace myMood.Data
{
    public class MoodDatabaseController
    {
        static object locker = new object();

        SQLiteConnection db;

        public MoodDatabaseController()
        {
            db = DependencyService.Get<ISQLite>().GetConnection();
            db.CreateTable<MoodEntry>();
        }

        //public MoodEntry GetMoodEntry(int moodEntryID)
        //{
        //        return db.Table<MoodEntry>()
        //                    .Where(i => i.MoodEntryID == moodEntryID)
        //                    .FirstOrDefault();
        //}

        public IEnumerable<MoodEntry> GetMoodEntries()
        {
            return db.Table<MoodEntry>().OrderByDescending(e => e.EntryDate);
        }

        public MoodEntry GetMoodEntry(DateTime entryDate)
        {
            return db.Table<MoodEntry>()
                        .Where(i => i.EntryDate == entryDate)
                        .FirstOrDefault();
        }

        public IQueryable<MoodEntry> GetMoodentries(DateTime startDate, DateTime endDate)
        {
            return db.Table<MoodEntry>()
                    .Where(e => e.EntryDate >= startDate && e.EntryDate <= endDate)
                    .OrderBy(e => e.EntryDate)
                    .AsQueryable();                    
        }

        public int SaveMoodEntry(MoodEntry entry)
        {
            lock (locker)
            {
                var existing = GetMoodEntry(entry.EntryDate);

                if (existing != null)
                {
                    entry.MoodEntryID = existing.MoodEntryID;

                    db.Update(entry);
                }
                else
                {
                    db.Insert(entry);

                }
            }
            return entry.MoodEntryID;
        }

        public int DeleteMoodEntry(int moodEntryID)
        {
            lock(locker)
            {
                return db.Delete<MoodEntry>(moodEntryID);
            }
        }
    }
}
