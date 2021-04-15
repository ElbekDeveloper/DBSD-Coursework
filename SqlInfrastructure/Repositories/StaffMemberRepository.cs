using Microsoft.Extensions.Configuration;
using ApplicationCore.Interfaces.RepositoryInterfaces;
using System.Threading.Tasks;
using Domain.Models;
using System.Threading;
using System.Collections.Generic;

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

        public Task<List<StaffMember>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
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
