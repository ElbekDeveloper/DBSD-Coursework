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
        [HttpGet]
        [Route("{id:int}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Individual Product", Type = typeof(GetProductResource))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<GetProductResource>> GetProductById([FromRoute]int id, CancellationToken cancellationToken = default)
        {
            return Ok(await _productService.GetProductByIdAsync(id, cancellationToken));
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Product Creation", Type = typeof(int))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PostProduct([FromBody] AddProductResource productResource, CancellationToken cancellationToken = default)
        {
            return Ok(await _productService.CreateProductAsync(productResource, cancellationToken));
        }

        [HttpDelete]
        [Route("{id:int}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Product Deleted", Type = typeof(int))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            return Ok(await _productService.DeleteProductAsync(id, cancellationToken));
        }
    }
}
