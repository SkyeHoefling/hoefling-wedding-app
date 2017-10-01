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
    public class ItineraryGetEvents
    {
        public static IActionResult Run(HttpRequest req, TraceWriter log)
        {
            log.Info("Loading events from database");
            IEnumerable<Event> events = null;
            using (var context = new WeddingDbContext())
            {
                events = context.Events.ToArray();
            }

            return new OkObjectResult(events);
        }
    }    
}