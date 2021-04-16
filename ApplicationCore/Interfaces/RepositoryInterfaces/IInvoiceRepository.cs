using ApplicationCore.Resources;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.RepositoryInterfaces
{
    public interface IInvoiceRepository:IRepository<Invoice>
    {
        Task<int> CreateInvoiceAsync(AddInvoiceResource entity, CancellationToken cancellationToken = default);
    }
}
