using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Collections.Generic;
using WeddingPhotos.Data.Entities;
using WeddingPhotos.Data;
using System.Linq;

namespace WeddingPhotos.Functions
{
    public class ImageGet
    {
        public static IActionResult Run(HttpRequest req, TraceWriter log)
        {
            return new OkObjectResult("OK");
        }
    }    
}