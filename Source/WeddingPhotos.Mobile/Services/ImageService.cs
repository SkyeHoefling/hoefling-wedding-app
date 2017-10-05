using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeddingPhotos.Mobile.Services
{
    public class ImageService : IImageService
    {
        public async Task<IEnumerable<ImageSource>> GetAllImagesAsync()
        {
            return new ImageSource[]
            {
                new UriImageSource { Uri = new Uri("https://hoeflingweddingfunctions.azurewebsites.net/api/ImageGet?name=me") },
                new UriImageSource { Uri = new Uri("https://hoeflingweddingfunctions.azurewebsites.net/api/ImageGet?name=test") },
                new UriImageSource { Uri = new Uri("https://hoeflingweddingfunctions.azurewebsites.net/api/ImageGet?name=me") },
            };
        }
    }
}
