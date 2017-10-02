using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Collections.Generic;
using WeddingPhotos.Data.Entities;
using WeddingPhotos.Data;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using WeddingPhotos.Services;

namespace WeddingPhotos.Functions
{
    public class ImageGetAll
    {
        public static async Task<IActionResult> Run(HttpRequest req, TraceWriter log)
        {
            IImageHandler imageHandler = new AzureImageHandler();            
            var names = await imageHandler.GetImageNamesAsync();
            
            return new OkObjectResult(names);
        }
    }    
}