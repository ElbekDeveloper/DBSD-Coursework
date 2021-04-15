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

namespace WebApi.Controllers
{
[Route("api/[controller]/")]
[ApiController]
public class CounterAgentsController : ControllerBase
{
    private readonly ICounterAgentService _counterAgentService;

    public CounterAgentsController(ICounterAgentService counterAgentService)
    {
        _counterAgentService = counterAgentService;
    }


    [HttpGet]
    [SwaggerResponse((int)HttpStatusCode.OK, Description = "All Counter Agents", Type = typeof(List<CounterAgentResource>))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult<IEnumerable<CounterAgentResource>>> GetManufacturers(CancellationToken cancellationToken = default)
    {
        return Ok(await _counterAgentService.GetAllCounterAgentsAsync(cancellationToken));
    }
}
}
