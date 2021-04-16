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

        public async Task<IEnumerable<CounterAgent>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                string procedure = "spCounterAgent_GetAll";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<CounterAgent>(sql: procedure, commandType: CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
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
