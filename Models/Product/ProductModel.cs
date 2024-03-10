using GraphQL.Types;

namespace GraphQLDemoAPI.Models.Product
{
    public class ProductModel
    {
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
    }

    public class ProductType : ObjectGraphType<ProductModel>
    {
        public ProductType()
        {
            Field(x => x.ProductName).Description("The name of the product");
            Field(x => x.ProductImageUrl).Description("The URL of the product image");
        }
    }
}
