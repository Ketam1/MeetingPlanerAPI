using API.RegisterScreen.Frontier.Interfaces.Business;
using API.RegisterScreen.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace VLIConecta.PosVendas.Controllers.Api.v1.Bics
{
    [Route("api/v1/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersBusiness usersBusiness;
        public UsersController(IUsersBusiness usersBusiness)
        {
            this.usersBusiness = usersBusiness;
        }

        [HttpGet("allUsers")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<UserModel>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAllUsers()
        {
            var usersDto = usersBusiness.GetAllUsers();

            if (usersDto is not null)
            {
                return Ok(usersDto.Select(contact => new UserModel(contact)));
            }
            return NoContent();
        }

        [HttpGet("userByUserId")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetContactByContactId(
            [FromQuery] Guid userId
        )
        {
            var userDto = usersBusiness.GetUserByUserId(userId);

            if (userDto is not null)
            {
                return Ok(new UserModel(userDto));
            }
            return NoContent();
        }
        

        [HttpPost("user")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult AddUser(
            [FromBody] UserInputModel input
        )
        {
            usersBusiness.AddUser(
                input.Name,
                input.PhoneNumber,
                input.Email,
                input.Whatsapp
            );

            return Ok();
        }

        [HttpDelete("user")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult DeleteUserByUserId(
            [FromQuery] Guid userId
        )
        {
            var removedUser = usersBusiness.DeleteUserByUserId(userId);

            if (removedUser is not null)
            {
                return Ok();
            } 
            return NotFound();
        }

        [HttpPut("user")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult UpdateUserByUserId(
            [FromBody] UserUpdateInputModel input
        )
        {
            var updatedContact = usersBusiness.UpdateUserByUserId(
                input.UserId,
                input.Name,
                input.PhoneNumber,
                input.Email,
                input.Whatsapp
            );

            if (updatedContact is not null)
            {
                return Ok();
            }
            return NotFound();
        }


    }
}
