using Datamodels.Models.Product;

namespace GraphQLDemoAPI.Services
{
    public interface IProductService
    {
        public Task<ProductModel> CreateProduct(ProductModel product);
        public Task<ProductModel> UpdateProduct(ProductModel product);
        public Task<ProductModel> DeleteProduct(string productName);
        public Task<ProductModel> GetProduct(string productName);
        public Task<ProductModel> GetProducts();
    }
}
