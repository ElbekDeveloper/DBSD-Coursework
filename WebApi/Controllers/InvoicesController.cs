using ApplicationCore.Helpers.Filters;
using ApplicationCore.Interfaces.ServiceInterfaces;
using ApplicationCore.Resources;
using CsvHelper;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : Controller
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        //[HttpGet]
        //[SwaggerResponse((int)HttpStatusCode.OK, Description = "All Invoices", Type = typeof(List<GetInvoiceResource>))]
        //[SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        //public async Task<ActionResult<IEnumerable<GetInvoiceResource>>> GetInvoices(CancellationToken cancellationToken = default)
        //{
        //    return Ok(await _invoiceService.GetAllInvoicesAsync(cancellationToken));
        //}

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "All Invoices", Type = typeof(List<GetInvoiceResource>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetInvoiceResource>>> GetInvoices([FromQuery]InvoiceFilter invoiceFilter,CancellationToken cancellationToken = default)
        {
            return Ok(await _invoiceService.GetAllInvoicesWithFiltersAsync(invoiceFilter,cancellationToken));
        }

        [HttpPut]
        [Route("{id:int}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Invoice Updated", Type = typeof(int))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateInvoice([FromRoute] int id, [FromBody] AddInvoiceResource invoiceResource, CancellationToken cancellationToken = default)
        {
            return Ok(await _invoiceService.UpdateInvoiceAsync(id, invoiceResource, cancellationToken));
        }
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Invoice Creation", Type = typeof(int))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PostInvoice([FromBody] AddInvoiceResource invoiceResource, CancellationToken cancellationToken = default)
        {
            return Ok(await _invoiceService.CreateInvoice(invoiceResource, cancellationToken));
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


        // Import and Export endpoints

        [HttpGet("export/json")]
        public async Task<ActionResult> ExportJson([FromQuery]InvoiceFilter invoiceFilter, CancellationToken cancellationToken)
        {
            var list = await _invoiceService.GetAllInvoicesWithFiltersAsync(invoiceFilter, cancellationToken);


            var memory = new MemoryStream();
            var writer = new StreamWriter(memory);
            var serializer = new JsonSerializer();
            serializer.Serialize(writer, list);
            writer.Flush();

            memory.Position = 0;
            if (memory != Stream.Null)
                return File(memory, "application/json", $"Export_{DateTime.Now}.json");

            return NotFound();
        }

        [HttpGet("export/xml")]
        public async Task<ActionResult> ExportXml([FromQuery]InvoiceFilter invoiceFilter, CancellationToken cancellationToken)
        {
            var list = await _invoiceService.GetAllInvoicesWithFiltersAsync(invoiceFilter, cancellationToken);
            var memory = new MemoryStream();
            var writer = new StreamWriter(memory);
            var serializer = new XmlSerializer(typeof(List<GetInvoiceResource>));
            serializer.Serialize(writer, list);
            writer.Flush();

            memory.Position = 0;
            if (memory != Stream.Null)
                return File(memory, "application/xml", $"Export_{DateTime.Now}.xml");

            return NotFound();
        }


        [HttpGet("export/csv")]
        public async Task<ActionResult> ExportCsv([FromQuery]InvoiceFilter invoiceFilter, CancellationToken cancellationToken)
        {
            var list = await _invoiceService.GetAllInvoicesWithFiltersAsync(invoiceFilter, cancellationToken);

            var memory = new MemoryStream();
            var writer = new StreamWriter(memory);
            var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(list);
            writer.Flush();

            memory.Position = 0;
            if (memory != Stream.Null)
                return File(memory, "text/csv", $"Export_{DateTime.Now}.csv");

            return NotFound();
        }


        [HttpPost("import/json")]
        public async Task<ActionResult> ImportJson(IFormFile importFile)
        {
            IList<AddInvoiceResource> invoices = null;
            if (importFile != null)
            {
                using (var stream = importFile.OpenReadStream())
                using (var reader = new StreamReader(stream))
                {
                    var serializer = new JsonSerializer();
                    invoices =
                        (List<AddInvoiceResource>)serializer.Deserialize(reader, typeof(List<AddInvoiceResource>));
                }

                foreach (var inv in invoices)
                    await _invoiceService.CreateInvoice(inv);
            }

            return Ok(invoices);
        }


        [HttpPost("import/csv")]
        public async Task<ActionResult> ImportCsv(IFormFile importFile)
        {
            var invoices = new List<AddInvoiceResource>();
            if (importFile != null)
            {
                using (var stream = importFile.OpenReadStream())
                using (var reader = new StreamReader(stream))
                {
                    var serializer = new CsvReader(reader, CultureInfo.InvariantCulture);
                    invoices = serializer.GetRecords<AddInvoiceResource>().ToList<AddInvoiceResource>();
                }

                foreach (var inv in invoices)
                    await _invoiceService.CreateInvoice(inv);
            }
            else
            {
                ModelState.AddModelError("", "Empty file");
            }

            return Ok(invoices);
        }

        [HttpPost("import/xml")]
        public async Task<ActionResult> ImportXml(IFormFile importFile)
        {
            var invoices = new List<AddInvoiceResource>();
            if (importFile != null)
            {
                using (var stream = importFile.OpenReadStream())
                using (var reader = new StreamReader(stream))
                {
                    var serializer = new XmlSerializer(typeof(List<AddInvoiceResource>));
                    invoices = (List<AddInvoiceResource>)serializer.Deserialize(reader);
                }

                foreach (var inv in invoices)
                    await _invoiceService.CreateInvoice(inv);
            }
            else
            {
                ModelState.AddModelError("", "Empty file");
            }

            return Ok(invoices);
        }
    }
}
