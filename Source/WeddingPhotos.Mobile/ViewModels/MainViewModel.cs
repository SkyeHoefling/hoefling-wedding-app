using GalaSoft.MvvmLight;
using Plugin.Media;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using WeddingPhotos.Mobile.Services;
using Xamarin.Forms;

namespace WeddingPhotos.Mobile.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IImageService _imageService;
        private readonly IImagePropertiesService _imagePropertiesService;
        public MainViewModel(
            IImageService imageService,
            IImagePropertiesService imagePropertiesService)
        {
            _imageService = imageService;
            _imagePropertiesService = imagePropertiesService;
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
                Images.Insert(0, new Models.Image
                {
                    Source = ImageSource.FromStream(() =>
                    {
                        var stream = photo.GetStream();
                        photo.Dispose();
                        return stream;
                    }),
                    Height = 500
                });
        }

        private async void Initialize()
        {
            var images = await Task.WhenAll((await _imageService.GetAllImagesAsync())
                .Select(async x => new Models.Image
                {
                    Source = x,
                    Height = (await _imagePropertiesService.RetrieveWdithHeightUriAsync((x as UriImageSource).Uri)).height
                }));
            Images = new ObservableCollection<Models.Image>(images);
            RaisePropertyChanged(nameof(Images));
        }
    }
}
