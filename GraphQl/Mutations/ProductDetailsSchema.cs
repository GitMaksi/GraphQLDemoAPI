using GraphQL.Types;
using GraphQLDemoAPI.GraphQl.Query;
using Microsoft.Extensions.DependencyInjection;

namespace Datamodels.Models.GraphQl.Mutations
{
    public class ProductDetailsSchema : Schema
    {
        public ProductDetailsSchema(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<ProductQuery>();
            Mutation = serviceProvider.GetRequiredService<ProductMutation>();
        }
    }
}
