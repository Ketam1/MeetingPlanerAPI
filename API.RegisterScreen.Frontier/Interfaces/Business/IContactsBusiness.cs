using API.RegisterScreen.Frontier.Dto;

namespace API.RegisterScreen.Frontier.Interfaces.Business
{
    public interface IContactsBusiness
    {
        void AddContactByUserId(
            Guid userId,
            string name,
            string phoneNumber,
            string email,
            string whatsapp
        );
        IEnumerable<ContactDto>? GetContactsByUserId(Guid userId);
        ContactDto? GetContactByContactId(Guid contactId);
        Guid? DeleteContactByContactId(Guid contactId);
        Guid? UpdateContactByContactId(
            Guid contactId,
            string name,
            string phoneNumber,
            string email,
            string whatsapp
        );

    }
}

