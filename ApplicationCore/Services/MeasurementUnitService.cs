using ApplicationCore.Interfaces.RepositoryInterfaces;
using ApplicationCore.Interfaces.ServiceInterfaces;
using ApplicationCore.Resources;
using AutoMapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class MeasurementUnitService : IMeasurementUnitService
    {
        private readonly IMeasurementUnitRepository _measurementUnitRepository;
        private readonly IMapper _mapper;

        public MeasurementUnitService(IMapper mapper, IMeasurementUnitRepository measurementUnitRepository)
        {
            _mapper = mapper;
            _measurementUnitRepository = measurementUnitRepository;
        }

        public async Task<List<MeasurementUnitResource>> GetAllMeasurementUnitsAsync(CancellationToken cancellationToken = default)
        {
            var measurementUnits = await _measurementUnitRepository.GetAllAsync(cancellationToken);

            var measurementUnitResources = _mapper.Map<List<MeasurementUnitResource>>(measurementUnits);

            return measurementUnitResources;
        }
    }
}
