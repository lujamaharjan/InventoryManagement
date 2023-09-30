using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contracts.Features
{
    public interface ITrackItemQuantity
    {
        Task<int> GetItemQuantity(Guid itemId);
    }
}
