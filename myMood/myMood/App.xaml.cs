using myMood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace myMood
{
	public partial class App : Application
	{
        static MoodDatabaseController moodDatabase;

        public App()
        {
            InitializeComponent();

            MainPage = new myMood.Views.MainPage();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static MoodDatabaseController MoodDatabase
        {
            get
            {
                if (moodDatabase == null)
                    moodDatabase = new MoodDatabaseController();

                return moodDatabase;
            }
        }
    }
}
