using GraphQL.Types;
using GraphQL;
using GraphQLDemoAPI.Models.Employee;
using GraphQLDemoAPI.Services;
using GraphQLDemoAPI.Models.Product;
using GraphQLDemoAPI.Models.GraphQl.Mutations;
using GraphQLDemoAPI.Models.GraphQl.Queries;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IServiceSender, ServiceBusSender>();
builder.Services.AddSingleton<IProductService, ProductService>();

//GraphQL service registration
builder.Services.AddSingleton<EmployeeQuery>();
builder.Services.AddSingleton<EmployeeDetailsType>();

//wazne ¿eby w jednym schema trzymaæ query i mutacje
builder.Services.AddSingleton<ProductMutation>();
builder.Services.AddSingleton<ProductType>();
builder.Services.AddSingleton<ISchema, ProductDetailsSchema>();

builder.Services.AddGraphQL(b => b
    .AddAutoSchema<EmployeeQuery>());

builder.Services.AddGraphQL(b => b
    .AddAutoSchema<ProductMutation>()
    .AddSystemTextJson());   // serializer

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
