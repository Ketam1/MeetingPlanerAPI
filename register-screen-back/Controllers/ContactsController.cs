using API.RegisterScreen.Frontier.Interfaces.Business;
using API.RegisterScreen.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace VLIConecta.PosVendas.Controllers.Api.v1.Bics
{
    [Route("api/v1/contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsBusiness contactsBusiness;
        public ContactsController(IContactsBusiness contactsBusiness)
        {
            this.contactsBusiness = contactsBusiness;
        }

        [HttpGet("contactByContactId")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<ContactModel>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetContactByContactId(
            [FromQuery] Guid contactId
        )
        {
            var contactDto = contactsBusiness.GetContactByContactId(contactId);

            if (contactDto is not null)
            {
                return Ok(new ContactModel(contactDto));
            }
            return NoContent();
        }

        [HttpGet("contactsByUserId")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<ContactModel>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetContactsByUserId(
            [FromQuery] Guid userId
        )
        {
            var contactsDto = contactsBusiness.GetContactsByUserId(userId);

            if (contactsDto is not null)
            {
                return Ok(contactsDto.Select(contact => new ContactModel(contact)));
            }
            return NoContent();
        }

        [HttpPost("contact")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult AddContactByUserId(
            [FromBody] ContactInputModel input
        )
        {
            contactsBusiness.AddContactByUserId(
                input.UserId,
                input.Name,
                input.PhoneNumber,
                input.Email,
                input.Whatsapp
            );

            return Ok();
        }

        [HttpDelete("contact")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult DeleteContactByContactId(
            [FromQuery] Guid userId
        )
        {
            var removedContact = contactsBusiness.DeleteContactByContactId(userId);

            if (removedContact is not null)
            {
                return Ok();
            } 
            return NotFound();
        }

        [HttpPut("contact")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult UpdateContactByContactId(
            [FromBody] ContactUpdateInputModel input
        )
        {
            var updatedContact = contactsBusiness.UpdateContactByContactId(
                input.ContactId,
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
