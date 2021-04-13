using ApplicationCore.Interfaces.RepositoryInterfaces;
using ApplicationCore.Interfaces.ServiceInterfaces;
using ApplicationCore.Resources;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<GetProductResource>> GetAllProductsAsync(CancellationToken cancellationToken = default)
        {

            var products = await _productRepository.GetAllAsync(cancellationToken);
            var productResources = _mapper.Map<List<GetProductResource>>(products);

            return productResources;

        }
    }
}
