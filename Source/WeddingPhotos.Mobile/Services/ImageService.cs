using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeddingPhotos.Mobile.Services
{
    public class ImageService : IImageService
    {
        public Task<IEnumerable<ImageSource>> GetAllImagesAsync()
        {
            return Task.Run<IEnumerable<ImageSource>>(() => new[]
            {
                new UriImageSource { Uri = new Uri("https://hoeflingweddingfunctions.azurewebsites.net/api/ImageGet?name=me") },
                new UriImageSource { Uri = new Uri("https://hoeflingweddingfunctions.azurewebsites.net/api/ImageGet?name=test") },
                new UriImageSource { Uri = new Uri("https://hoeflingweddingfunctions.azurewebsites.net/api/ImageGet?name=me") },
            });
        }
    }
}
