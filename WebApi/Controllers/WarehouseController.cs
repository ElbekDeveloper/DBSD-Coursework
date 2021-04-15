using ApplicationCore.Interfaces.ServiceInterfaces;
using ApplicationCore.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Controllers {
  [Route("api/[controller]/")]
  [ApiController]
  public class WarehouseController : ControllerBase {
    private readonly IWarehouseService _warehouseService;

    public WarehouseController(IWarehouseService warehouseService) {
      _warehouseService = warehouseService;
    }

    [HttpGet]
    [SwaggerResponse((int) HttpStatusCode.OK, Description = "All Warehouses",
                     Type = typeof(List<WarehouseResource>))]
    [SwaggerResponse((int) HttpStatusCode.InternalServerError)]
    public async Task<ActionResult<IEnumerable<WarehouseResource>>>
    GetManufacturers(CancellationToken cancellationToken = default) {
      return Ok(
          await _warehouseService.GetAllWarehousesAsync(cancellationToken));
    }
  }
}
