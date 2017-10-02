using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using WeddingPhotos.Data;
using WeddingPhotos.Data.Entities;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;
using System.Reflection;
using System.IO;

namespace WeddingPhotos.Functions
{
    public class ItinerarySeed
    {
        public static async Task<IActionResult> Run(HttpRequest req, TraceWriter log)
        {
            log.Info("loading blob database file");
            var storageAccount = new CloudStorageAccount(
                new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                    "hoeflingwedding",
                    "HAItH1JIV7jWPLgHVq7cpcYPmZ7OXqb298HKpkxpNCcxYFIx9mCxV7VJJ4opd/+H8rsJIoc5hbH+kw+jSClPaA=="
                ),
                true
            );

            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("databases");
            var block = container.GetBlockBlobReference("wedding.db");
            var path = @"/home/andrew/hoeflingsoftware/hoefling-wedding-app/Source/WeddingPhotos.Functions/bin/Debug/netstandard2.0/wedding-azure.db";
            using (var fileStream = File.OpenWrite(path))
            {
                await block.DownloadToStreamAsync(fileStream);
            }

            IEnumerable<Event> events = null;

            using (var context = new WeddingDbContext(path))
            {
                events = new []
                {
                    new Event
                    {
                        Title = "All Aboard",
                        Description = "All Aboard Description"
                    }
                };

                context.Events.RemoveRange(context.Events);
                context.Events.AddRange(events);
                context.SaveChanges();
            }

            return new OkObjectResult(events);
        }
    }    
}