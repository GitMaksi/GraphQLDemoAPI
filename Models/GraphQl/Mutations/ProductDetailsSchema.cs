using GraphQL.Types;
using GraphQLDemoAPI.Models.GraphQl.Queries;

namespace GraphQLDemoAPI.Models.GraphQl.Mutations
{
    public class ProductDetailsSchema : Schema
    {
        public ProductDetailsSchema(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<EmployeeQuery>();
            Mutation = serviceProvider.GetRequiredService<ProductMutation>();
        }
    }
}
