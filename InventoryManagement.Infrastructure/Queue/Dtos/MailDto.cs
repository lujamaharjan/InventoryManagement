namespace InventoryManagement.Infrastructure.Dtos.MailDto;

public class MailDto
{
    public List<string> Addresses {get; set;} = new();
    public string Subject {get; set;} = String.Empty;
    public string MailBody {get; set;} = String.Empty;
}
