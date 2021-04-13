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
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "All Products", Type = typeof(List<GetProductResource>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetProductResource>>> GetProducts(CancellationToken cancellationToken =default)
        {
            return Ok(await _productService.GetAllProductsAsync(cancellationToken));
        }
    }
}
