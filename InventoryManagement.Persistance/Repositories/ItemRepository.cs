using InventoryManagement.Application.Contracts.Persistance;
using InventoryManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Persistance.Repositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {

        private readonly InventoryManagementDbContext _context;
        public ItemRepository(InventoryManagementDbContext context):base(context) 
        {
            _context = context;
        }

        public async Task DecreaseItemQuantity(Guid itemId, int quantity)
        {
            var item = await Get(itemId);
            if(item.Quantity < quantity)
            {
                throw new Exception("Invalid Quantity");
            }
            item.Quantity -= quantity;
            await _context.SaveChangesAsync();
        }

        public async Task IncreaseItemQuantity(Guid itemId, int quantity)
        {
            var item = await Get(itemId);
            item.Quantity += quantity;
            await _context.SaveChangesAsync();
        }


    }
}
