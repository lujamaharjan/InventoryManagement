using InventoryManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain
{
    /// <summary>
    ///    Transaction History class is domain model whose main
    ///    purpose is to track all the items that is gone out and come inside store.
    /// </summary>
    public class TransactionHistory:BaseDomainEntity
    {
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public bool InOut { get; set; }
        public DateTime OccurredDate { get; set; }
    }
}
