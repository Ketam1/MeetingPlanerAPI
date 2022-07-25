using API.RegisterScreen.Frontier.Dto;

namespace API.RegisterScreen.Frontier.Interfaces.Repository
{
    public interface IContactListRepository
    {
        void AddContactByUserId(
            Guid userId,
            Guid contactId,
            string name,
            string phoneNumber,
            string email,
            string whatsapp
        );
        void AddUser(
            Guid userId,
            string name,
            string phoneNumber,
            string email,
            string whatsapp
        );
        IEnumerable<ContactDto>? GetContactsByUserId(Guid userId);
        ContactDto? GetContactByContactId(Guid contactId);
        Guid? DeleteContactByContactId(Guid contactId);
        Guid? UpdateContactByContactId(Guid contactId, string name, string phoneNumber, string email, string whatsapp);
        IEnumerable<UserDto> GetAllUsers();
        UserDto? GetUserByUserId(Guid userId);
        Guid? DeleteUserByUserId(Guid userId);
        Guid? UpdateUserByUserId(
            Guid userId,
            string name,
            string phoneNumber,
            string email,
            string whatsapp
        );
    }
}

