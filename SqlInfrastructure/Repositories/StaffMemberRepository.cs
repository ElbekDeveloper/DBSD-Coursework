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
    public class StaffMemberRepository : BaseRepository, IStaffMemberRepository
    {
        public StaffMemberRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Task<int> CreateAsync(StaffMember entity, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<StaffMember>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                string procedure = "spStaffMember_GetAll";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<StaffMember>(sql: procedure, commandType: CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public Task<StaffMember> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> UpdateAsync(StaffMember entity, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
