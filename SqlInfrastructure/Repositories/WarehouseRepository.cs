using Microsoft.Extensions.Configuration;
using ApplicationCore.Interfaces.RepositoryInterfaces;
using System.Threading.Tasks;
using Domain.Models;
using System.Threading;
using System.Collections.Generic;

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

        public Task<List<Warehouse>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
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
