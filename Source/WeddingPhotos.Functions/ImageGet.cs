using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Collections.Generic;
using WeddingPhotos.Data.Entities;
using WeddingPhotos.Data;
using System.Linq;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;

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

            var credentials = new StorageCredentials("hoeflingwedding", "HAItH1JIV7jWPLgHVq7cpcYPmZ7OXqb298HKpkxpNCcxYFIx9mCxV7VJJ4opd/+H8rsJIoc5hbH+kw+jSClPaA==");
            var storageAccount = new CloudStorageAccount(credentials, true);

            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("photos");
            var block = container.GetBlockBlobReference($"{name}.jpg");

            Stream stream = await block.OpenReadAsync();
            var response = new OkObjectResult(stream);
            response.ContentTypes.Add(new MediaTypeHeaderValue("image/jpeg"));
            return response;
        }
    }    
}