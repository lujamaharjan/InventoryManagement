using InventoryManagement.Application.Contracts.Features;
using InventoryManagement.Application.Contracts.Persistance;
using InventoryManagement.Application.Dtos.Items;
using InventoryManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Features
{
    public class UpdateQuantity:IUpdateQuantity
    {
        private readonly IItemRepository _iItemRepository;
        private readonly ITransactionHistoryRepository _transactionHistoryRepository;
        public UpdateQuantity(IItemRepository itemRepository, ITransactionHistoryRepository transactionHistoryRepository)
        {
            _iItemRepository = itemRepository;
            _transactionHistoryRepository = transactionHistoryRepository;
        }

        public async Task SubtractItemQuantity(UpdateItemQuantityDto dto)
        {
            var item = await _iItemRepository.Get(dto.ItemId);
            await _iItemRepository.DecreaseItemQuantity(dto.ItemId, dto.ChangedQuantity);
            await _transactionHistoryRepository.Add(new TransactionHistory
            {
                ItemId = item.Id,
                Quantity = dto.ChangedQuantity,
                InOut = false,
                OccurredDate = DateTime.UtcNow,
            }) ;
            
        }

        public async Task AddItemQuantity(UpdateItemQuantityDto dto)
        {
            var item = await _iItemRepository.Get(dto.ItemId);
            await _iItemRepository.IncreaseItemQuantity(dto.ItemId, dto.ChangedQuantity);
            await _transactionHistoryRepository.Add(new TransactionHistory
            {
                ItemId = item.Id,
                Quantity = dto.ChangedQuantity,
                InOut = true,
                OccurredDate = DateTime.UtcNow,
            });
        }
    }
}
