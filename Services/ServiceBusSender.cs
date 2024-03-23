using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System.Text;
using DataModels.Models.SBMessages;

namespace GraphQLDemoAPI.Services
{
    public class ServiceBusSender : IServiceSender
    {
        public async Task SendMessageAsync<T>(T serviceBusMessage) where T : IServiceBusMessage
        {
            var client = new ServiceBusClient("");
            var sender = client.CreateSender("createproduct");


            var messageBody = JsonConvert.SerializeObject(serviceBusMessage);
            var message = new ServiceBusMessage(Encoding.UTF8.GetBytes(messageBody));

            await sender.SendMessageAsync(message);
        }
    }
}
