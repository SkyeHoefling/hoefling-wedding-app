using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeddingPhotos.Mobile.Services
{
    public interface IImageService
    {
        Task<IEnumerable<ImageSource>> GetAllImagesAsync();
    }
}
