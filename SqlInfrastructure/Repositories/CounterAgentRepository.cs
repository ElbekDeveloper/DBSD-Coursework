using Domain.Models;
using Microsoft.Extensions.Configuration;
using ApplicationCore.Interfaces.RepositoryInterfaces;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace SqlInfrastructure.Repositories
{
    public class CounterAgentRepository : BaseRepository, ICounterAgentRepository
    {
        public CounterAgentRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Task<int> CreateAsync(CounterAgent entity, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<CounterAgent>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<CounterAgent> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> UpdateAsync(CounterAgent entity, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
