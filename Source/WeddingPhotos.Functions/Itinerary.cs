using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;

namespace WeddingPhotos.Functions
{
    public class Itinerary
    {
        public static IActionResult Run(HttpRequest req, TraceWriter log)
        {
            log.Info("Diagnostic status check");
            var events = new[]
            {
                new {
                    Day = 1,
                    Title = "All Aboard",
                    Description = "Ipsum lopar"
                },
                new {
                    Day = 2,
                    Title = "Ipsum Event",
                    Description = "some description"
                }
            };
            
            return new OkObjectResult(events);
        }
    }    
}