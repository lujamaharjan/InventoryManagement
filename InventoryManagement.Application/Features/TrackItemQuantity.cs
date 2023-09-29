using InventoryManagement.Application.Contracts.Features;
using InventoryManagement.Application.Contracts.Persistance;
using InventoryManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Features
{
    public class TrackItemQuantity : ITrackItemQuantity
    {
        private readonly IItemRepository _iItemRepository;
        public TrackItemQuantity(IItemRepository itemRepository)
        {
            _iItemRepository = itemRepository;
        }

        // Parameter:
        //  - Guid itemId
        // Summary:
        //  - find and return quantity of given item
        // Return: 
        //  - int Quantity
        public async Task<int> GetItemQuantity(Guid itemId)
        {
            var item = await _iItemRepository.Get(itemId);
            return item.Quantity;
        }
    }
}
