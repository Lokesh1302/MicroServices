using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using OrderSystem.Events;
using System.Threading.Tasks;

namespace OrderSystem.EventPublisher
{
    public interface IServiceBusEventPublisher
    {
        Task PublishEvent(IEvents e);
    }

    public class ServiceBusEventPublisher : IServiceBusEventPublisher
    {
        private string _connectionString;
        private string _topicName;
        private TopicClient client;
        public ServiceBusEventPublisher(string ConnectionString, string TopicName)
        {
            _connectionString = ConnectionString;
            _topicName = TopicName;
            client = new TopicClient(_connectionString, _topicName);
        }
        public async Task PublishEvent(IEvents @event)
        {
            string messageString;
            Message msg = new Message();
            switch (@event)
            {
                case OrderEvents.OrderPlaced op:
                    var settings = new JsonSerializerSettings();
                    settings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                    messageString = JsonConvert.SerializeObject((OrderEvents.OrderPlaced)@event , settings);
                    msg.Body = System.Text.Encoding.ASCII.GetBytes(messageString);
                    break;
            }
            await client.SendAsync(msg);
        }
    }
}
