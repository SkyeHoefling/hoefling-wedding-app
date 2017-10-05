using Microsoft.Practices.ServiceLocation;
using WeddingPhotos.Mobile.ViewModels;

namespace WeddingPhotos.Mobile.MVVM
{
    public class ViewModelLocator
    {
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public ImageGalleryViewModel Gallery
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ImageGalleryViewModel>();
            }
        }

        public ShipViewModel Ship
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ShipViewModel>();
            }
        }
    }
}
