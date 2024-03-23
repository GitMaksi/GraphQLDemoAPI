using Datamodels.Models.Product;
using DataModels.Models.Product;
using GraphQL;
using GraphQL.Types;
using GraphQLDemoAPI.Services;

namespace GraphQLDemoAPI.GraphQl.Query
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(IProductService productService)
        {
            Field<ListGraphType<ProductType>>()
             .Name("GetProduct")
             .Argument<StringGraphType>("ProductName", "Use this argument to filter products by their name.")
             .Resolve(context =>
             {
                 var productName = context.GetArgument<string>("ProductName");
                 return productService.GetProduct(productName);
             });
        }
    }
}
