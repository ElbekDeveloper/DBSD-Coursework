using ApplicationCore.Resources;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.ServiceInterfaces {
  public interface IWarehouseService {
    Task<List<WarehouseResource>> GetAllWarehousesAsync(
        CancellationToken cancellationToken = default);
  }
}
