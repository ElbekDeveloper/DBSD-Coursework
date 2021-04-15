using ApplicationCore.Resources;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.ServiceInterfaces
{
    public interface IMeasurementUnitService
    {
        Task<List<MeasurementUnitResource>> GetAllMeasurementUnitsAsync(CancellationToken cancellationToken = default);
    }
}
