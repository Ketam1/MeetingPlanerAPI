
namespace API.RegisterScreen.Frontier.Entities
{
    public class UserEntity
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public IEnumerable<ContactEntity> Contacts { get; set; }
}
}
