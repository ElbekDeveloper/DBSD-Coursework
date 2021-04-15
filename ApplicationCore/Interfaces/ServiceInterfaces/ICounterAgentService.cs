using ApplicationCore.Resources;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.ServiceInterfaces {
  public interface ICounterAgentService {
    Task<List<CounterAgentResource>> GetAllCounterAgentsAsync(
        CancellationToken cancellationToken = default);
  }
}
