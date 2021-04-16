using ApplicationCore.Helpers.Filters;
using ApplicationCore.Resources;
using Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.RepositoryInterfaces
{
public interface IInvoiceRepository:IRepository<Invoice>
{
    Task<List<Invoice>> GetInvoicesWithFilters(InvoiceFilter invoice, CancellationToken cancellationToken = default);
    Task<int> CreateInvoiceAsync(AddInvoiceResource entity, CancellationToken cancellationToken = default);
    Task<int> UpdateInvoiceAsync(int id, AddInvoiceResource entity, CancellationToken cancellationToken = default);
}
}
