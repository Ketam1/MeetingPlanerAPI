
using API.RegisterScreen.Frontier.Entities;

namespace API.RegisterScreen.Frontier.Dto
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public IEnumerable<ContactDto> Contacts { get; set; }

        public UserDto(UserEntity user)
        {
            Name = user.Name;
            PhoneNumber = user.PhoneNumber;
            Email = user.Email;
            Whatsapp = user.Whatsapp;
            Contacts = user.Contacts.Select(contact => new ContactDto(contact));
        }
    }
}
