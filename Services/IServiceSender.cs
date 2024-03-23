namespace GraphQLDemoAPI.Services
{
    public interface IServiceSender
    {
        Task SendMessageAsync<T>(T serviceBusMessage);
        Task Send(string productName, string productUrl);
    }
}
