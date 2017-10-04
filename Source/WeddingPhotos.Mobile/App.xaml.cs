using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using WeddingPhotos.Mobile.Views;
using Xamarin.Forms;

namespace WeddingPhotos.Mobile
{
    public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new MainPage());
		}

		protected override void OnStart ()
		{
            // Handle when your app starts
            MobileCenter.Start("ios=afd6d39c-a94a-4453-8c9e-a46f0540e7dc;" +
                               "android=667f6702-2840-4719-8ac5-16ab4e2307de;",
                               typeof(Analytics), typeof(Crashes));
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
