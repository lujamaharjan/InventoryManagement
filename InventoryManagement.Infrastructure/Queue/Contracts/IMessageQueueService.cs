

namespace InventoryManagement.Infrastructure.Queue.Contracts;

public interface IMessageQueueService
{
    public void SendMessage(string message);
}
