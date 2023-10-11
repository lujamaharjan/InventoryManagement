using RabbitMQ.Client;
using InventoryManagement.Infrastructure.Queue.Contracts;
using System.Text;
using InventoryManagement.Infrastructure.Dtos.MailDto;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace InventoryManagement.Infrastructure.Queue.Service;

public class MessageQueueService : IMessageQueueService
{
    private readonly ConnectionFactory _factory;
    public MessageQueueService(string hostName)
    {
        _factory = new ConnectionFactory { HostName = hostName};
    }
    public void SendMessage(MailDto dto)
    {
        using(var connection = _factory.CreateConnection())
        using(var channel = connection.CreateModel())
        {
            string body = JsonSerializer.Serialize<MailDto>(dto);
            var bodyAsBytes = Encoding.UTF8.GetBytes(body);
            channel.QueueDeclare(queue: "EmailQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
            channel.BasicPublish(exchange: "", routingKey: "EmailQueue", basicProperties: null, body: bodyAsBytes);
        }
    }
}
