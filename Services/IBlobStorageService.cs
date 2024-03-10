namespace GraphQLDemoAPI.Services
{
    public interface IBlobStorageService
    {
        Task UploadProductJsonAsync(string productName, string productImageUrl);
    }
}
