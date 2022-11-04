using API.MeetingPlanner.Frontier.Dto;
using API.MeetingPlanner.Frontier.Interfaces.Business;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MeetingPlanner.Controllers
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

        [HttpGet("getAll")]
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
