using InventoryManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contracts.Persistance
{
    public interface IItemRepository:IGenericRepository<Item>
    {
        Task DecreaseItemQuantity(Guid itemId, int quantity);
        Task IncreaseItemQuantity(Guid itemId, int quantity);
    }
}
