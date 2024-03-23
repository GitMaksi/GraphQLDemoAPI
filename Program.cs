using GraphQL.Types;
using GraphQL;
using GraphQLDemoAPI.Services;
using Datamodels.Models.GraphQl.Mutations;
using Datamodels.Models.Product;
using GraphQLDemoAPI.GraphQl.Query;
using DataModels.Models.Product;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ProductQuery>();

builder.Services.AddSingleton<IServiceSender, ServiceBusSender>();
builder.Services.AddSingleton<IProductService, ProductService>();

builder.Services.AddSingleton<ProductMutation>();
builder.Services.AddSingleton<ProductType>();
builder.Services.AddSingleton<ISchema, ProductDetailsSchema>();

builder.Services.AddGraphQL(b => b
    .AddAutoSchema<ProductDetailsSchema>()
    .AddSystemTextJson());   // serializer

//builder.Services.AddGraphQL(b => b
    //.AddAutoSchema<ProductQuery>());


var app = builder.Build();

app.UseGraphQL<ISchema>("/graphql");            // url to host GraphQL endpoint
app.UseGraphQLPlayground(
    "/",                               // url to host Playground at
    new GraphQL.Server.Ui.Playground.PlaygroundOptions
    {
        GraphQLEndPoint = "/graphql",         // url of GraphQL endpoint
        SubscriptionsEndPoint = "/graphql",   // url of GraphQL endpoint
    });

app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.Run();
