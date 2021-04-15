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
    public class MeasurementUnitRepository : BaseRepository, IMeasurementUnitRepository
    {
        public MeasurementUnitRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Task<int> CreateAsync(MeasurementUnit entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(MeasurementUnit entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MeasurementUnit>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                string procedure = "spMeasurementUnit_GetAll";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<MeasurementUnit>(sql: procedure, commandType: CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public Task<MeasurementUnit> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(MeasurementUnit entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
