﻿using InventoryManagement.Application.Contracts.Persistance;
using InventoryManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Persistance.Repositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {

        private readonly InventoryManagementDbContext _context;
        public ItemRepository(InventoryManagementDbContext context):base(context) 
        {
            _context = context;
        }

    }
}
