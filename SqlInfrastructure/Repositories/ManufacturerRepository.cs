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
    public class ManufacturerRepository : BaseRepository, IManufacturerRepository
    {
        public ManufacturerRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Task<int> CreateAsync(Manufacturer entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Manufacturer entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Manufacturer>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                string procedure = "spManufacturer_GetAll";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Manufacturer>(sql: procedure, commandType: CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public Task<Manufacturer> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Manufacturer entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
