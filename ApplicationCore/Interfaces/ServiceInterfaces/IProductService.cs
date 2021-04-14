using ApplicationCore.Resources;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.ServiceInterfaces
{
    public interface IProductService
    {
        Task<List<GetProductResource>> GetAllProductsAsync(CancellationToken cancellationToken = default);
        Task<GetProductResource> GetProductByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
