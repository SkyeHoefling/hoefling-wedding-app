using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Linq;
namespace WeddingPhotos.Services
{
    public class AzureImageHandler : IImageHandler
    {
        public async Task<Stream> GetImageAsync(string name)
        {
            var container = GetContainer();
            var block = container.GetBlockBlobReference($"{name}.jpg");

            return await block.OpenReadAsync();
        }

        public async Task<IEnumerable<string>> GetImageNamesAsync()
        {
            var container = GetContainer();
            var blobs = await container.ListBlobsSegmentedAsync(null);
            return blobs.Results.Select(x => 
                x.Uri.Segments
                    .Last()
                    .Split('.')
                    .FirstOrDefault());
        }

        private CloudBlobContainer GetContainer()
        {
            var credentials = new StorageCredentials("hoeflingwedding", "HAItH1JIV7jWPLgHVq7cpcYPmZ7OXqb298HKpkxpNCcxYFIx9mCxV7VJJ4opd/+H8rsJIoc5hbH+kw+jSClPaA==");
            var storageAccount = new CloudStorageAccount(credentials, true);

            var blobClient = storageAccount.CreateCloudBlobClient();
            return blobClient.GetContainerReference("photos");
        }
    }    
}