using ApplicationCore.Interfaces.RepositoryInterfaces;
using ApplicationCore.Interfaces.ServiceInterfaces;
using ApplicationCore.Resources;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IMapper _mapper;

        public ManufacturerService(IManufacturerRepository manufacturerRepository, IMapper mapper)
        {
            _manufacturerRepository = manufacturerRepository;
            _mapper = mapper;
        }

        public async Task<List<ManufacturerResource>> GetAllManufacturersAsync(CancellationToken cancellationToken = default)
        {
            var manufacturers = await _manufacturerRepository.GetAllAsync(cancellationToken);

            var manufacturerResources = _mapper.Map<List<ManufacturerResource>>(manufacturers);

            return manufacturerResources;
        }
    }
}
