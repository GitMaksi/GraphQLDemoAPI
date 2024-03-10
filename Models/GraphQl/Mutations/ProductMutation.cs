using GraphQL;
using GraphQL.Types;
using GraphQLDemoAPI.Models.Product;
using GraphQLDemoAPI.Services;

namespace GraphQLDemoAPI.Models.GraphQl.Mutations
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
                    return productService.CreateProduct(productName, productImageURL);
                }
            );
        }
    }
}
