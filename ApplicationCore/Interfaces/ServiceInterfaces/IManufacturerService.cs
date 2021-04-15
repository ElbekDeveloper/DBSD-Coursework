using ApplicationCore.Resources;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.ServiceInterfaces
{
    public interface IManufacturerService
    {
        Task<List<ManufacturerResource>> GetAllManufacturersAsync(CancellationToken cancellationToken = default);
    }
}
