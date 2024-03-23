namespace GraphQLDemoAPI.Services
{
    public interface IServiceSender
    {
        Task SendMessageAsync<T>(T serviceBusMessage);
    }
}
