using ApplicationCore.Interfaces.RepositoryInterfaces;
using ApplicationCore.Interfaces.ServiceInterfaces;
using ApplicationCore.Resources;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task<List<GetInvoiceResource>> GetAllInvoicesAsync(CancellationToken cancellationToken = default)
        {
            var invoices = await _invoiceRepository.GetAllAsync(cancellationToken);
            var invoiceResources = _mapper.Map<List<GetInvoiceResource>>(invoices);

            return invoiceResources;
        }
    }
}
