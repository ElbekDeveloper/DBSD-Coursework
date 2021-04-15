using ApplicationCore.Interfaces.RepositoryInterfaces;
using ApplicationCore.Interfaces.ServiceInterfaces;
using ApplicationCore.Resources;
using AutoMapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Services {
  public class WarehouseService : IWarehouseService {
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IMapper _mapper;

    public WarehouseService(IWarehouseRepository warehouseRepository,
                            IMapper mapper) {
      _warehouseRepository = warehouseRepository;
      _mapper = mapper;
    }

    public async Task<List<WarehouseResource>>
    GetAllWarehousesAsync(CancellationToken cancellationToken = default) {
      var warehouses =
          await _warehouseRepository.GetAllAsync(cancellationToken);

      var warehouseResources = _mapper.Map<List<WarehouseResource>>(warehouses);

      return warehouseResources;
    }
  }
}
