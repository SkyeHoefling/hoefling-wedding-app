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
    public class ImageGet
    {
        public static async Task<IActionResult> Run(HttpRequest req, TraceWriter log)
        {
            req.Query.TryGetValue("name", out StringValues values);
            var name = values.FirstOrDefault();

            if(string.IsNullOrWhiteSpace(name)){
                return new BadRequestResult();
            }

            IImageHandler imageHandler = new AzureImageHandler();
            var stream = await imageHandler.GetImageAsync(name);

            var response = new OkObjectResult(stream);
            response.ContentTypes.Add(new MediaTypeHeaderValue("image/jpeg"));
            return response;
        }
    }    
}