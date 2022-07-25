using API.RegisterScreen.Frontier.Dto;
using System.Collections.Generic;
using System.Linq;

namespace API.RegisterScreen.Model
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public IEnumerable<ContactModel> Contacts { get; set; }

        public UserModel(UserDto user)
        {
            Name = user.Name;
            PhoneNumber = user.PhoneNumber;
            Email = user.Email;
            Whatsapp = user.Whatsapp;
            Contacts = user.Contacts.Select(contact => new ContactModel(contact));
        }
    }
}
