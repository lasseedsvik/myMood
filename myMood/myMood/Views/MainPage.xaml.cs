using Xamarin.Forms;

namespace myMood.Views
{
    public partial class MainPage : TabbedPage
	{
		public MainPage()
        {
            InitializeComponent();
            
            NavigationPage.SetHasNavigationBar(this, false);
        }
	}
}
