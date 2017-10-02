using System.IO;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;

namespace WeddingPhotos.Services
{
    public class AzureImageHandler : IImageHandler
    {
        public async Task<Stream> GetImageAsync(string name)
        {
            var credentials = new StorageCredentials("hoeflingwedding", "HAItH1JIV7jWPLgHVq7cpcYPmZ7OXqb298HKpkxpNCcxYFIx9mCxV7VJJ4opd/+H8rsJIoc5hbH+kw+jSClPaA==");
            var storageAccount = new CloudStorageAccount(credentials, true);

            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("photos");
            var block = container.GetBlockBlobReference($"{name}.jpg");

            return await block.OpenReadAsync();
        }
    }    
}