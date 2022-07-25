using API.RegisterScreen.Frontier.Dto;
using API.RegisterScreen.Frontier.Interfaces.Business;
using API.RegisterScreen.Frontier.Interfaces.Repository;

namespace API.RegisterScreen.Business
{
    public class UsersBusiness : IUsersBusiness
    {
        private readonly IContactListRepository ContactListRepository;

        public UsersBusiness(
            IContactListRepository contactListRepository
        )
        {
            ContactListRepository = contactListRepository;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            return ContactListRepository.GetAllUsers();
        }

        public UserDto? GetUserByUserId(Guid userId)
        {
            return ContactListRepository.GetUserByUserId(userId);
        }

        public Guid? DeleteUserByUserId(Guid userId)
        {
            return ContactListRepository.DeleteUserByUserId(userId);
        }

        public Guid? UpdateUserByUserId(
            Guid userId,
            string name,
            string phoneNumber,
            string email,
            string whatsapp
        )
        {
            return ContactListRepository.UpdateUserByUserId(userId, name, phoneNumber, email, whatsapp);
        }

        public void AddUser(
            string name,
            string phoneNumber,
            string email,
            string whatsapp
        )
        {
            ContactListRepository.AddUser(
                Guid.NewGuid(),
                name,
                phoneNumber,
                email,
                whatsapp
            );
        }
    }
}