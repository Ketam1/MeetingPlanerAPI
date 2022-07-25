using API.RegisterScreen.Frontier.Dto;

namespace API.RegisterScreen.Frontier.Interfaces.Business
{
    public interface IUsersBusiness
    {
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
        void AddUser(
            string name,
            string phoneNumber,
            string email,
            string whatsapp
        );
    }
}
