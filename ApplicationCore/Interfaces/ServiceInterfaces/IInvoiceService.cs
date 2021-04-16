using ApplicationCore.Resources;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.ServiceInterfaces
{
    public interface IInvoiceService
    {
        Task<List<GetInvoiceResource>> GetAllInvoicesAsync(CancellationToken cancellationToken = default);
        Task<GetInvoiceResource> GetInvoiceByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<int> DeleteInvoiceAsync(int id, CancellationToken cancellationToken = default);
    }
}
