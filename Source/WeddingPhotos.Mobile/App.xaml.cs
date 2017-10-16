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
            RegisterDependencies();   
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

        private void RegisterDependencies()
        {
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ImageGalleryViewModel>();
            SimpleIoc.Default.Register<ShipViewModel>();
            SimpleIoc.Default.Register<ShipDeckViewModel>();
            SimpleIoc.Default.Register<Services.IImageService, Services.ImageService>();
            SimpleIoc.Default.Register<IDialogService>(() => new DialogService());
            RegisterNavigation();
        }

        private void RegisterNavigation()
        {
            var nav = new MVVM.NavigationService();
            nav.Configure(nameof(Locator.Main), typeof(MainPage));
            nav.Configure(nameof(Locator.Gallery), typeof(ImageGalleryPage));
            nav.Configure(nameof(Locator.Ship), typeof(ShipPage));
            nav.Configure(nameof(Locator.ShipDeck), typeof(ShipDeckPage));
            SimpleIoc.Default.Register<INavigationService>(() => nav);

            var main = new NavigationPage(new HomePage());
            nav.Initialize(main);

            MainPage = main;
        }
    }
}
