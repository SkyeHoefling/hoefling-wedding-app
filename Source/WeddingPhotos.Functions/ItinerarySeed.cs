using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;

namespace WeddingPhotos.Functions
{
    public class ItinerarySeed
    {
        public static IActionResult Run(HttpRequest req, TraceWriter log)
        {
            return new OkObjectResult(true);
        }
    }    
}