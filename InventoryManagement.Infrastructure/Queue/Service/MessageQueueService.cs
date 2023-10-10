using RabbitMQ.Client;
using InventoryManagement.Infrastructure.Queue.Contracts;
using System.Text;

namespace InventoryManagement.Infrastructure.Queue.Service;

public class MessageQueueService : IMessageQueueService
{
    private readonly ConnectionFactory _factory;
    public MessageQueueService(string hostName)
    {
        _factory = new ConnectionFactory { HostName = hostName};
    }
    public void SendMessage(string message)
    {
        using(var connection = _factory.CreateConnection())
        using(var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "smsQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "", routingKey: "smsQueue", basicProperties: null, body: body);
        }
    }
}
