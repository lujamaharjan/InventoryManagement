using InventoryManagement.Domain;
using InventoryManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Persistance
{
    public class InventoryManagementDbContext:DbContext
    {
        public InventoryManagementDbContext(DbContextOptions<InventoryManagementDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryManagementDbContext).Assembly);
        }

        // Add Dbset for new table mapping
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }
        public DbSet<CategoryItem> CategoriesItem { get; set; } 
    }
}
