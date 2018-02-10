using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myMood.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Entries : ContentPage
	{
		public Entries ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            EntriesList.ItemsSource = App.MoodDatabase.GetMoodEntries();
        }
    }
}