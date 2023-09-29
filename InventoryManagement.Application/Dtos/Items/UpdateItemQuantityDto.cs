using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Dtos.Items
{
    public class UpdateItemQuantityDto
    {
        public Guid ItemId { get; set; }
        public int ChangedQuantity { get; set; }
    }
}
