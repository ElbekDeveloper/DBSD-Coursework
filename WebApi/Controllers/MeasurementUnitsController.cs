using ApplicationCore.Interfaces.ServiceInterfaces;
using ApplicationCore.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementUnitsController : ControllerBase
    {
        private readonly IMeasurementUnitService _measurementUnitService;

        public MeasurementUnitsController(IMeasurementUnitService measurementUnitService)
        {
            _measurementUnitService = measurementUnitService;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "All Measurement Units", Type = typeof(List<MeasurementUnitResource>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<IEnumerable<MeasurementUnitResource>>> GetMeasurementUnits(CancellationToken cancellationToken = default)
        {
            return Ok(await _measurementUnitService.GetAllMeasurementUnitsAsync(cancellationToken));
        }
    }
}
