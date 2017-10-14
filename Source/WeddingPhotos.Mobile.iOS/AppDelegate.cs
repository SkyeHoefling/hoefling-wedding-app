
using System;
using FFImageLoading.Helpers;
using Foundation;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using FFImageLoading.Forms.Touch;
using FFImageLoading;
using System.Reflection;

namespace WeddingPhotos.Mobile.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
			
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
            ImageService.Instance.Initialize(config);

            Corcav.Behaviors.Infrastructure.Init();
            var carouselView = typeof(Xamarin.Forms.CarouselView);
            var aseembly = Assembly.Load(carouselView.FullName);

            RegisterDependencies();

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
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
                Error($"{errorMessage}{Environment.NewLine}{ex.ToString()}");
            }
        }
    }
}
