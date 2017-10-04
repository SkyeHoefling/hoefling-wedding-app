using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using WeddingPhotos.Mobile.Services;
using WeddingPhotos.Mobile.ViewModels;

namespace WeddingPhotos.Mobile.MVVM
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<IImageService, ImageService>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
    }
}
