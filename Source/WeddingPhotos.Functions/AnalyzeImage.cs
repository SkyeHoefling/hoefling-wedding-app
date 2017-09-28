using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;

namespace WeddingPhotos.Functions
{
    public class AnalyzeImage
    {
        public static IActionResult Run(HttpRequest req, TraceWriter log)
        {
            log.Info("Hello World log message");
            return new OkObjectResult("Hello World");
        }
    }    
}