using Datamodels.Models.Product;
using DataModels.Models.SBMessages;

namespace GraphQLDemoAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IServiceSender serviceSender;

        public ProductService(IServiceSender serviceSender)
        {
            this.serviceSender = serviceSender;
        }

        public async Task<ProductModel> CreateProduct(ProductModel product)
        {
            await this.serviceSender.SendMessageAsync(new UpdateProductMessage() { Product = product });

            return product;
        }

        public async Task<ProductModel> DeleteProduct(string productName)
        {
            await this.serviceSender.SendMessageAsync(new DeleteProductMessage() { ProductName = productName });

            return new ProductModel();
        }

        public Task<ProductModel> GetProduct(string productName)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> UpdateProduct(ProductModel product)
        {
            await this.serviceSender.SendMessageAsync(new UpdateProductMessage() { Product = product });

            return product;
        }
    }
}
