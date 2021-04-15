using ApplicationCore.Interfaces.RepositoryInterfaces;
using ApplicationCore.Interfaces.ServiceInterfaces;
using ApplicationCore.Resources;
using AutoMapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace ApplicationCore.Services
{
    public class CounterAgentService : ICounterAgentService
    {
        private readonly ICounterAgentRepository _counterAgentRepository;
        private readonly IMapper _mapper;

        public CounterAgentService(ICounterAgentRepository counterAgentRepository, IMapper mapper)
        {
            _counterAgentRepository = counterAgentRepository;
            _mapper = mapper;
        }

        public async Task<List<CounterAgentResource>> GetAllCounterAgentsAsync(CancellationToken cancellationToken = default)
        {
            var counterAgents = await _counterAgentRepository.GetAllAsync(cancellationToken);

            var counterAgentResources = _mapper.Map<List<CounterAgentResource>>(counterAgents);

            return counterAgentResources;
        }
    }
}
