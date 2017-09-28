using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;

namespace WeddingPhotos.Functions
{
    public class Diagnostic
    {
        public static IActionResult Run(HttpRequest req, TraceWriter log)
        {
            log.Info("Diagnostic status check");
            return new OkObjectResult("OK");
        }
    }    
}