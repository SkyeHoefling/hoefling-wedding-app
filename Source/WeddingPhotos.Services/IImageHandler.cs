using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace WeddingPhotos.Services
{
    public interface IImageHandler
    {
        Task<Stream> GetImageAsync(string name);        
        Task<IEnumerable<string>> GetImageNamesAsync();
    }
}