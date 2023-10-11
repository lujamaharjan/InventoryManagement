using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.Hosting;

namespace InventoryManagement.Infrastructure.Queue.Service;

public class EmailSender : IHostedService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private int maxRetry = 3;

    public EmailSender(string rabbitMQHostName, string rabbitMQUsername, string rabbitMQPassword)
    {
        var factory = new ConnectionFactory
        {
            HostName = rabbitMQHostName,
            UserName = rabbitMQUsername,
            Password = rabbitMQPassword,
            Port = 5672
        };

        _connection = factory.CreateConnection();

        _channel = _connection.CreateModel();

        _channel.QueueDeclare(queue: "EmailQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                // sending email function
                Console.WriteLine("--------------------------");
                Console.WriteLine("Email Send ....");
                Console.WriteLine("--------------------------");
            };
            _channel.BasicConsume(queue: "EmailQueue", autoAck: true, consumer: consumer);
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            Console.WriteLine("?????????????????");
            Console.WriteLine(ex.Message);
            throw;
        }

    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _channel?.Dispose();
        _connection?.Dispose();
        return Task.CompletedTask;
    }

}

