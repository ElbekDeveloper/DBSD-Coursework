using ApplicationCore.Resources;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.ServiceInterfaces
{
    public interface IInvoiceService
    {
        Task<List<GetInvoiceResource>> GetAllInvoicesAsync(CancellationToken cancellationToken = default);
    }
}
