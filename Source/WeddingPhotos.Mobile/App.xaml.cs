
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using WeddingPhotos.Mobile.MVVM;
using WeddingPhotos.Mobile.ViewModels;
using WeddingPhotos.Mobile.Views;
using Xamarin.Forms;

namespace WeddingPhotos.Mobile
{
    public partial class App : Application
	{
		public App()
		{
            InitializeComponent();

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ImageGalleryViewModel>();
            SimpleIoc.Default.Register<Services.IImageService, Services.ImageService>();

            var nav = new MVVM.NavigationService();
            nav.Configure(nameof(Locator.Main), typeof(MainPage));
            nav.Configure(nameof(Locator.Gallery), typeof(ImageGalleryPage));
            SimpleIoc.Default.Register<INavigationService>(() => nav);

            var main = new  NavigationPage(new MainPage());
            nav.Initialize(main);

            MainPage = main;
        }

        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator
        {
            get
            {
                return _locator ?? (_locator = new ViewModelLocator());
            }
        }

		protected override void OnStart()
		{
            // Handle when your app starts
            MobileCenter.Start("ios=afd6d39c-a94a-4453-8c9e-a46f0540e7dc;" +
                               "android=667f6702-2841-4719-8ac5-16ab4e2307de;",
                               typeof(Analytics), typeof(Crashes));
        }

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
