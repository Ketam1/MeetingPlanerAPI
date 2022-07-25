using API.RegisterScreen.Frontier.Dto;
using API.RegisterScreen.Frontier.Interfaces.Business;
using API.RegisterScreen.Frontier.Interfaces.Repository;

namespace API.RegisterScreen.Business
{
    public class ContactsBusiness : IContactsBusiness
    {
        private readonly IContactListRepository ContactListRepository;

        public ContactsBusiness(
            IContactListRepository contactListRepository
        )
        {
            ContactListRepository = contactListRepository;
        }
        public void AddContactByUserId(
            Guid userId, 
            string name,
            string phoneNumber,
            string email,
            string whatsapp
        )
        {
            ContactListRepository.AddContactByUserId(
                userId,
                Guid.NewGuid(),
                name,
                phoneNumber,
                email,
                whatsapp
            );
        }

        public IEnumerable<ContactDto>? GetContactsByUserId(Guid userId)
        {
            return ContactListRepository.GetContactsByUserId(userId);
        }

        public ContactDto? GetContactByContactId(Guid contactId)
        {
            return ContactListRepository.GetContactByContactId(contactId);
        }

        public Guid? DeleteContactByContactId(Guid contactId)
        {
            return ContactListRepository.DeleteContactByContactId(contactId);
        }

        public Guid? UpdateContactByContactId(Guid contactId, string name, string phoneNumber, string email, string whatsapp)
        {
            return ContactListRepository.UpdateContactByContactId(
                contactId,
                name,
                phoneNumber,
                email,
                whatsapp
            );
        }

    }
}

