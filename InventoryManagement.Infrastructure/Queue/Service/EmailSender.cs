using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using InventoryManagement.Infrastructure.Dtos.MailDto;
using System.Text.Json.Serialization;
using System.Net.Mail;
using System.Net;


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
                var mailDto = JsonSerializer.Deserialize<MailDto>(message);

                SmtpClient smtpClient = new SmtpClient("");
                smtpClient.Port = 567;
                smtpClient.Credentials = new NetworkCredential("sachin", "password");
                smtpClient.EnableSsl = true;
                foreach(var address in mailDto.Addresses)
                {
                    MailMessage mailMessage = new MailMessage("noreplay.im55@gmail.com", address, mailDto.Subject, mailDto.MailBody);
                    mailMessage.IsBodyHtml = true;
                    smtpClient.Send(mailMessage);
                    mailMessage.Dispose();
                }
                smtpClient.Dispose();
            };
            _channel.BasicConsume(queue: "EmailQueue", autoAck: true, consumer: consumer);
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
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

