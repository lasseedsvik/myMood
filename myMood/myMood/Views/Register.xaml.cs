using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using myMood.Helpers;
using myMood.ViewModels;

namespace myMood.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Register : ContentPage
	{
        private double StepValue = 0.1;

        public Register()
        {
            InitializeComponent();

            BindingContext = new RegisterViewModel();
        }
        
        private void SliderSleep_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            LabelSleep.Text = FormatHelpers.FormatSliderValue(e.NewValue, StepValue);

            FileImageSource objFileImageSource = (FileImageSource)ImageSleep.Source;

            string currentFile = objFileImageSource.File;
            string smiley = SmileyHelper.GetSmileyImage(e.NewValue);

            if (currentFile != smiley)
                ImageSleep.Source = smiley;
        }

        private void SliderStress_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            LabelStress.Text = FormatHelpers.FormatSliderValue(e.NewValue, StepValue);

            FileImageSource objFileImageSource = (FileImageSource)ImageStress.Source;

            string currentFile = objFileImageSource.File;
            string smiley = SmileyHelper.GetReverseSmileyImage(e.NewValue);

            if (currentFile != smiley)
                ImageStress.Source = smiley;
        }

        private void SliderAchivedGoals_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            LabelAchivedGoals.Text = FormatHelpers.FormatSliderValue(e.NewValue, StepValue);

            FileImageSource objFileImageSource = (FileImageSource)ImageAchivedGoals.Source;

            string currentFile = objFileImageSource.File;
            string smiley = SmileyHelper.GetSmileyImage(e.NewValue);

            if (currentFile != smiley)
                ImageAchivedGoals.Source = smiley;
        }
        
        private void EntryDate_Selected(object sender, DateChangedEventArgs e)
        {
            var entry = App.MoodDatabase.GetMoodEntry(e.NewDate);
            if (entry == null)
                entry = new Models.MoodEntry();

            SliderStress.Value = entry.Stress;
            SliderSleep.Value = entry.Sleep;
            SliderAchivedGoals.Value = entry.AchivedGoals;
            Comment.Text = entry.Comment;
        }
    }
}