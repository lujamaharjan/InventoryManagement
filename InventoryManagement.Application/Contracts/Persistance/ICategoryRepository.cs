using InventoryManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contracts.Persistance
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
    }
}
