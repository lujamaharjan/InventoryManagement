using InventoryManagement.Application.Contracts.Persistance;
using InventoryManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Persistance.Repositories
{
    public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
    {
        public InventoryManagementDbContext _context { get; set; }
        public CategoryRepository(InventoryManagementDbContext context): base(context)
        {
            _context = context;
        }
    }
}
