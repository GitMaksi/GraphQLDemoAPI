using Datamodels.Models.Product;
using DataModels.Models.Product;
using GraphQL;
using GraphQL.Types;
using GraphQLDemoAPI.Services;

namespace Datamodels.Models.GraphQl.Mutations
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IProductService productService)
        {
            Field<ProductType>(
                "addProduct",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "productName" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "productImageUrl" }
                ),
                resolve: context =>
                {
                    var productName = context.GetArgument<string>("productName");
                    var productImageURL = context.GetArgument<string>("productImageUrl");
                    var product = new ProductModel() { ProductName = productName, ProductImageUrl = productImageURL };
                    return productService.CreateProduct(product);
                }
            );
        }
    }
}
