using GalaSoft.MvvmLight;
using Plugin.Media;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WeddingPhotos.Mobile.Services;
using Xamarin.Forms;

namespace WeddingPhotos.Mobile.ViewModels
{
    public class ImageGalleryViewModel : ViewModelBase
    {
        private readonly IImageService _imageService;
        public ImageGalleryViewModel(IImageService imageService)
        {
            _imageService = imageService;
            Images = new ObservableCollection<ImageSource>();
            AddPhoto = new Command(TakePhoto);

            Initialize();
        }

        public ICommand AddPhoto { get; set; }
        public ObservableCollection<ImageSource> Images { get; set; }

        public async void TakePhoto()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable)
                return;

            var options = new Plugin.Media.Abstractions.StoreCameraMediaOptions();
            var photo = await CrossMedia.Current.TakePhotoAsync(options);

            if (photo != null)
            {
                Images.Insert(0, ImageSource.FromStream(() =>
                {
                    var stream = photo.GetStream();
                    photo.Dispose();
                    return stream;
                }));
                RaisePropertyChanged(nameof(Images));
            }
        }

        private async void Initialize()
        {
            Images = new ObservableCollection<ImageSource>(await _imageService.GetAllImagesAsync());
            RaisePropertyChanged(nameof(Images));
        }
    }
}
