using InventoryManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain
{
    /// <summary>
    ///   Domain Model Representing Item Category
    /// </summary>
    public class Category: BaseDomainEntity
    {
        public string Name { get; set; } = String.Empty;
    }
}
