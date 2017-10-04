﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using WeddingPhotos.Mobile.Droid.Services;
using WeddingPhotos.Mobile.Services;

namespace WeddingPhotos.Mobile.Droid
{
    [Activity (Label = "WeddingPhotos.Mobile", Icon = "@drawable/icon", Theme="@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar; 

			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
            RegisterDependencies();
			LoadApplication (new App());
		}

        private void RegisterDependencies()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<IImagePropertiesService, ImagePropertiesService>();
        }
    }
}

