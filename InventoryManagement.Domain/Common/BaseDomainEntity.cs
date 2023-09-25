using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
