using Datamodels.Models.Product;
using DataModels.Models.Product;
using GraphQL;
using GraphQL.Types;
using GraphQLDemoAPI.Services;

namespace GraphQLDemoAPI.GraphQl.Query
{
    public class ProductQuery : ObjectGraphType
    {
        [Obsolete]
        public ProductQuery(IProductService productService)
        {
            FieldAsync<ProductType>(
           "getProduct",
           arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "productName" }),
           resolve: async context => {
               var productName = context.GetArgument<string>("productName");
               return await productService.GetProduct(productName);
           });
        }
    }
}
