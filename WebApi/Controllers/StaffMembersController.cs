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
  public class StaffMembersController : ControllerBase {
    private readonly IStaffMemberService _staffMemberService;

    public StaffMembersController(IStaffMemberService staffMemberService) {
      _staffMemberService = staffMemberService;
    }

    [HttpGet]
    [SwaggerResponse((int) HttpStatusCode.OK, Description = "All Staff Members",
                     Type = typeof(List<StaffMemberResource>))]
    [SwaggerResponse((int) HttpStatusCode.InternalServerError)]
    public async Task<ActionResult<IEnumerable<StaffMemberResource>>>
    GetManufacturers(CancellationToken cancellationToken = default) {
      return Ok(
          await _staffMemberService.GetAllStaffMembersAsync(cancellationToken));
    }
  }
}
