using InventoryManagement.Application.Contracts.Persistance;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace InventoryManagement.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly string _connectionString = string.Empty;
        public GenericRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("InventoryManagementConnectionString");
        }

        public async Task<T> IGenericRepository<T>.Add(T entity)
        {
            using(var db = new SqlConnection(_connectionString))
            {

            }
        }

        public async Task<T> IGenericRepository<T>.Delete(T entity)
        {
            throw new NotImplementedException();
        }

        Task<bool> IGenericRepository<T>.Exists(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<T> IGenericRepository<T>.Get(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<T>> IGenericRepository<T>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<T> IGenericRepository<T>.Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
