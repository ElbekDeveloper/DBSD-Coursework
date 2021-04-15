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
        Task<int> CreateProductAsync(AddProductResource product, CancellationToken cancellationToken = default);

        Task<int> DeleteProductAsync(int id, CancellationToken cancellationToken = default);
    }
}
