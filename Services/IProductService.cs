using GraphQLDemoAPI.Models.Product;

namespace GraphQLDemoAPI.Services
{
    public interface IProductService
    {
        public Task<ProductModel> CreateProduct(string productName, string productImageUrl);
    }
}
