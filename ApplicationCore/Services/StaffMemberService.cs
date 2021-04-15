using ApplicationCore.Interfaces.RepositoryInterfaces;
using ApplicationCore.Interfaces.ServiceInterfaces;
using ApplicationCore.Resources;
using AutoMapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
public class StaffMemberService : IStaffMemberService
{
    private readonly IStaffMemberRepository _staffMemberRepository;
    private readonly IMapper _mapper;

    public StaffMemberService(IStaffMemberRepository staffMemberRepository, IMapper mapper)
    {
        _staffMemberRepository = staffMemberRepository;
        _mapper = mapper;
    }

    public async Task<List<StaffMemberResource>> GetAllStaffMembersAsync(CancellationToken cancellationToken = default)
    {
        var staffMembers = await _staffMemberRepository.GetAllAsync(cancellationToken);

        var staffMemberResources = _mapper.Map<List<StaffMemberResource>>(staffMembers);

        return staffMemberResources;
    }
}
}
