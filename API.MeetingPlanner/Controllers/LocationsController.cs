using API.MeetingPlanner.Frontier.Dto;
using API.MeetingPlanner.Frontier.Interfaces.Business;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace VLIConecta.PosVendas.Controllers.Api.v1.Bics
{
    [Route("api/v1/locations")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationsBusiness locationsBusiness;
        public LocationsController(ILocationsBusiness locationsBusiness)
        {
            this.locationsBusiness = locationsBusiness;
        }

        [HttpGet("locations")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<LocationDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetLocations()
        {
            var result = locationsBusiness.GetLocations();
            if (result.Any())
            {
                return Ok(result);
            }
            return NoContent();
        }

    }
}
