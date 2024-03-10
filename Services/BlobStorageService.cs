using Azure.Storage.Blobs;
using GraphQLDemoAPI.Services;
using System.Text;

public class BlobServiceService : IBlobStorageService
{
    private readonly BlobServiceClient _blobServiceClient;

    public BlobServiceService()
    {
        _blobServiceClient = new BlobServiceClient("");
    }

    public async Task UploadProductJsonAsync(string productName, string productImageUrl)
    {
        var blobContainer = _blobServiceClient.GetBlobContainerClient("product");
        await blobContainer.CreateIfNotExistsAsync();

        string jsonContent = $"{{\"productName\": \"{productName}\", \"productImageURL\": \"{productImageUrl}\"}}";
        var fileName = $"{Guid.NewGuid()}.json";

        var blobClient = blobContainer.GetBlobClient(fileName);

        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonContent)))
        {
            await blobClient.UploadAsync(ms);
        }
    }
}
