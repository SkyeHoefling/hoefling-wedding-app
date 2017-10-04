using GalaSoft.MvvmLight;
using Plugin.Media;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WeddingPhotos.Mobile.Services;
using Xamarin.Forms;

namespace WeddingPhotos.Mobile.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IImageService _imageService;
        public MainViewModel(IImageService service)
        {
            _imageService = service;
            Images = new ObservableCollection<Models.Image>();
            AddPhoto = new Command(TakePhoto);

            Initialize();
        }

        public ICommand AddPhoto { get; set; }
        public ObservableCollection<Models.Image> Images { get; set; }

        public async void TakePhoto()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable)
                return;

            var options = new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
            };
            var photo = await CrossMedia.Current.TakePhotoAsync(options);

            if (photo != null)
                ImageSource.FromStream(() => {
                    var stream = photo.GetStream();
                    photo.Dispose();
                    return stream;
                });
        }

        private async void Initialize()
        {
            Images = new ObservableCollection<Models.Image>((await _imageService.GetAllImagesAsync())
                .Select(x =>
                {
                    return new Models.Image
                    {
                        Source = x,
                        Height = 300
                    };
                }));
            RaisePropertyChanged(nameof(Images));
        }
    }
}
