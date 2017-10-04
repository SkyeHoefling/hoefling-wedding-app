using System;
using System.Threading.Tasks;

namespace WeddingPhotos.Mobile.Services
{
    public interface IImagePropertiesService
    {
        Task<(int width, int height)> RetrieveWdithHeightUriAsync(Uri uri);
    }
}
