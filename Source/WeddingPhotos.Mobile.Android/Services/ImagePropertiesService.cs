using System;
using System.Threading.Tasks;
using WeddingPhotos.Mobile.Services;

namespace WeddingPhotos.Mobile.Droid.Services
{
    internal class ImagePropertiesService : IImagePropertiesService
    {
        public Task<(int width, int height)> RetrieveWdithHeightUriAsync(Uri uri)
        {
            return Task.Run(() => (500, 500));
        }
    }
}