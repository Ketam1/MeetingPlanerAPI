using API.RegisterScreen.Frontier.Dto;
using System.Collections.Generic;
using System.Linq;

namespace API.RegisterScreen.Model
{
    public class ContactModel
    {
        public Guid ContactId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }

        public ContactModel(ContactDto contact)
        {
            Name = contact.Name;
            PhoneNumber = contact.PhoneNumber;
            Email = contact.Email;
            Whatsapp = contact.Whatsapp;
        }
    }
}
