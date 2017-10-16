using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System.Reflection;
using FFImageLoading.Forms.Droid;
using FFImageLoading.Helpers;
using CarouselView.FormsPlugin.Android;

namespace WeddingPhotos.Mobile.Droid
{
    [Activity (Label = "WeddingPhotos.Mobile", 
        Icon = "@drawable/icon", 
        Theme="@style/MainTheme", 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar; 

			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
            Corcav.Behaviors.Infrastructure.Init();
            CachedImageRenderer.Init();
            var dummy = new CachedImageRenderer();

            var config = new FFImageLoading.Config.Configuration()
            {
                VerboseLogging = true,
                VerbosePerformanceLogging = true,
                VerboseMemoryCacheLogging = true,
                VerboseLoadingCancelledLogging = true,
                Logger = new ImageLogger(),

            };
            InitializePackages();
            RegisterDependencies();
			LoadApplication (new App());
		}

        private void InitializePackages()
        {
            CarouselViewRenderer.Init();
        }

        private void RegisterDependencies()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
        }

        public class ImageLogger : IMiniLogger
        {
            public void Debug(string message)
            {
                Console.WriteLine(message);
            }

            public void Error(string errorMessage)
            {
                Console.WriteLine(errorMessage);
            }

            public void Error(string errorMessage, Exception ex)
            {
                Error($"{errorMessage}{System.Environment.NewLine}{ex.ToString()}");
            }
        }
    }
}

