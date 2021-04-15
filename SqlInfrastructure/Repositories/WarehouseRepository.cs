using ApplicationCore.Interfaces.RepositoryInterfaces;
using Dapper;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace SqlInfrastructure.Repositories
{
    public class WarehouseRepository : BaseRepository, IWarehouseRepository
    {
        public WarehouseRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Task<int> CreateAsync(Warehouse entity, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Warehouse>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                string procedure = "spWarehouse_GetAll";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Warehouse>(sql: procedure, commandType: CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public Task<Warehouse> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> UpdateAsync(Warehouse entity, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
