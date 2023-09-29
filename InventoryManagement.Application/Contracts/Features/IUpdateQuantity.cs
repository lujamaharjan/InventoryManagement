using InventoryManagement.Application.Dtos.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contracts.Features
{
    public interface IUpdateQuantity
    {
        Task SubtractItemQuantity(UpdateItemQuantityDto dto);
        Task AddItemQuantity(UpdateItemQuantityDto dto);
    }
}
