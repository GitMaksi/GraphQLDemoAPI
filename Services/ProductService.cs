using GraphQLDemoAPI.Models.Product;

namespace GraphQLDemoAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IBlobStorageService blobStorageService;

        public ProductService(IBlobStorageService blobStorageService) 
        {
            this.blobStorageService = blobStorageService;
        }

        public async Task<ProductModel> CreateProduct(string productName, string productImageUrl)
        {
            await this.blobStorageService.UploadProductJsonAsync(productName, productImageUrl);

            return new ProductModel
            {
                ProductName = productName,
                ProductImageUrl = productImageUrl
            };
        }
    }
}
