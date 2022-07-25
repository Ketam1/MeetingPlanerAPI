
using API.RegisterScreen.Frontier.Entities;

namespace API.RegisterScreen.Frontier.Dto
{
    public class ContactDto
    {
        public Guid ContactId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }

        public ContactDto(ContactEntity contact)
        {
            Name = contact.Name;
            PhoneNumber = contact.PhoneNumber;
            Email = contact.Email;
            Whatsapp = contact.Whatsapp;
        }
    }
}
