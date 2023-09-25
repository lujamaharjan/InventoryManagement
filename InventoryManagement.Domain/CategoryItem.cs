using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain
{
    /// <summary>
    ///     Domain Model Represneting Mapping Between Item And 
    ///    Their Category
    /// </summary>
    public class CategoryItem
    {
        public Guid CategoryId { get; set; }
        public Guid ItemId { get; set; }  
    }
}
