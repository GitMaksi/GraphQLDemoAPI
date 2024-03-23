using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System.Text;
using DataModels.Models.SBMessages;

namespace GraphQLDemoAPI.Services
{
    public class ServiceBusSender : IServiceSender
    {
        public async Task Send(string productName, string productUrl)
        {
            var client = new ServiceBusClient("The operation is not allowed by RBAC. If role assignments were recently changed, please wait several minutes for role assignments to become effective.");
            var sender = client.CreateSender("createproduct");

            var message = new ServiceBusMessage($"{productName},{productUrl}");

            await sender.SendMessageAsync(message);
        }

        async Task IServiceSender.SendMessageAsync<T>(T serviceBusMessage)
        {
            var client = new ServiceBusClient("");
            var sender = client.CreateSender("createproduct"); 

            var messageBody = JsonConvert.SerializeObject(serviceBusMessage);
            var message = new ServiceBusMessage(Encoding.UTF8.GetBytes(messageBody));

            await sender.SendMessageAsync(message);
        }
    }
}
