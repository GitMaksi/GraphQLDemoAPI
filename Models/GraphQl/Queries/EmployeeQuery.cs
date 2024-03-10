using GraphQL;
using GraphQL.Types;
using GraphQLDemoAPI.Models.Employee;
using GraphQLDemoAPI.Services;
using System.Xml.Linq;

namespace GraphQLDemoAPI.Models.GraphQl.Queries
{
    public class EmployeeQuery : ObjectGraphType
    {
        public EmployeeQuery(IEmployeeService employeeService)
        {
            Field<ListGraphType<EmployeeDetailsType>>(Name = "Employees", resolve: x => employeeService.GetEmployees());
            Field<ListGraphType<EmployeeDetailsType>>(Name = "Employee",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: x => employeeService.GetEmployee(x.GetArgument<int>("id")));
        }
    }
}
