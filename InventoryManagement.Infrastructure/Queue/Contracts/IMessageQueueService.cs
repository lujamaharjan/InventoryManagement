

using InventoryManagement.Infrastructure.Dtos.MailDto;

namespace InventoryManagement.Infrastructure.Queue.Contracts;

public interface IMessageQueueService
{
    public void SendMessage(MailDto mailDto);
}
