using API.MeetingPlanner.Business;
using API.MeetingPlanner.Frontier.Dto;
using API.MeetingPlanner.Frontier.Interfaces.Business;
using API.MeetingPlanner.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace VLIConecta.PosVendas.Controllers.Api.v1.Bics
{
    [Route("api/v1/meetings")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly IMeetingsBusiness meetingsBusiness;
        public MeetingsController(IMeetingsBusiness meetingsBusiness)
        {
            this.meetingsBusiness = meetingsBusiness;
        }

        [HttpPost("query")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<MeetingDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult QueryMeetings(
            [FromBody] MeetingQueryInputModel input
        )
        {
            var result = meetingsBusiness.QueryMeetings(input.BuildDto());
            return Ok(result);
        }

        [HttpPost("add")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult AddMeeting(
            [FromBody] MeetingInputModel input
        )
        {
            meetingsBusiness.AddMeeting(input.BuildDto());
            return Ok();
        }

        [HttpPost("edit")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult EditMeeting(
            [FromBody] MeetingUpdateInputModel input
        )
        {
            meetingsBusiness.EditMeetingById(input.BuildDto());
            return Ok();
        }

        [HttpPost("delete")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult DeleteMeetings(
            [FromBody] IEnumerable<int> input
        )
        {
            meetingsBusiness.DeleteMeetingsById(input);
            return Ok();
        }
    }
}
