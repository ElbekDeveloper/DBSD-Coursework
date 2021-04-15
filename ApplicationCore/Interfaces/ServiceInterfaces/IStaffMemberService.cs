using ApplicationCore.Resources;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.ServiceInterfaces
{
    public interface IStaffMemberService
    {
        Task<List<StaffMemberResource>> GetAllStaffMembersAsync(CancellationToken cancellationToken = default);
    }
}
