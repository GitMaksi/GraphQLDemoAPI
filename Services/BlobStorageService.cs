using Azure.Storage.Blobs;
using GraphQLDemoAPI.Services;
using System.Text;

public class BlobServiceService : IBlobStorageService
{
    private readonly BlobServiceClient _blobServiceClient;

    public BlobServiceService()
    {
        _blobServiceClient = new BlobServiceClient("DefaultEndpointsProtocol=https;AccountName=maxecommercestorage;AccountKey=Ne0w+PAco1G4XGTMSgtJva24eDnOBsoB1m3+oFc6czMqh+kRJUitbykIPPsonCfYDgPzmhxZNgKB+AStjA50yQ==;EndpointSuffix=core.windows.net");
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
