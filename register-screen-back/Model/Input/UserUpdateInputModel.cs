using System.Collections.Generic;
using System.Linq;

namespace API.RegisterScreen.Model
{
    public class UserUpdateInputModel
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }
    }
}
