using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Plugin.Media;

namespace WeddingPhotos.Mobile.ViewModels
{
    public class MainPageModel
    {
        public MainPageModel()
        {
            AddPhoto = new Command(TakePhoto);
            
        }

        public ICommand AddPhoto { get; set; }
        public ImageSource Source { get; set; }

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
    }
}
