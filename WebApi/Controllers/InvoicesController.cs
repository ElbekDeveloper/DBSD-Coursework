using ApplicationCore.Interfaces.ServiceInterfaces;
using ApplicationCore.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "All Invoices", Type = typeof(List<GetInvoiceResource>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetInvoiceResource>>> GetProducts(CancellationToken cancellationToken = default)
        {
            return Ok(await _invoiceService.GetAllInvoicesAsync(cancellationToken));
        }

        [HttpGet]
        [Route("{id:int}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Individual Invoice", Type = typeof(GetInvoiceResource))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<GetInvoiceResource>> GetInvoiceById([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            return Ok(await _invoiceService.GetInvoiceByIdAsync(id, cancellationToken));
        }


        [HttpDelete]
        [Route("{id:int}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Invoice Deleted", Type = typeof(int))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteInvoice([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            return Ok(await _invoiceService.DeleteInvoiceAsync(id, cancellationToken));
        }
    }
}
