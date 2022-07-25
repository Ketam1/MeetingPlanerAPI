using API.RegisterScreen.Frontier.Dto;
using API.RegisterScreen.Frontier.Entities;
using API.RegisterScreen.Frontier.Interfaces.Repository;
using System.Text;
using XSerializer;

namespace API.RegisterScreen.Repository
{
    public class ContactListRepository : IContactListRepository
    {
        IEnumerable<UserEntity> UserDataBase;
        XmlSerializer<IEnumerable<UserEntity>> serializer = new XmlSerializer<IEnumerable<UserEntity>>();
        public ContactListRepository()
        {
            using (FileStream fs = new FileStream(@"store.xml", FileMode.OpenOrCreate))
            {
                fs.Position = 0;
                var streamReader = new StreamReader(fs);
                var usersXml = streamReader.ReadToEnd();
                UserDataBase = serializer.Deserialize(usersXml);
            }
        }

        public void AddContactByUserId(
            Guid userId,
            Guid contactId,
            string name,
            string phoneNumber,
            string email,
            string whatsapp
        )
        {
            UserDataBase = (List<UserEntity>)UserDataBase.Where(x => x.UserId == userId).Select(user =>
            {
                user.Contacts = user.Contacts.Append(new ContactEntity
                {
                    ContactId = contactId,
                    Name = name,
                    PhoneNumber = phoneNumber,
                    Email = email,
                    Whatsapp = whatsapp
                });
                return user;
            });
            applyChanges(UserDataBase);
        }

        public void AddUser(
            Guid userId,
            string name,
            string phoneNumber,
            string email,
            string whatsapp
        )
        {
            UserDataBase = UserDataBase.Append(new UserEntity
            {
                UserId = userId,
                Name = name,
                PhoneNumber = phoneNumber,
                Email = email,
                Whatsapp = whatsapp
            });
            applyChanges(UserDataBase);
        }

        public Guid? DeleteContactByContactId(Guid contactId)
        {
            if(!CheckContactIdExist(contactId, UserDataBase))
            {
                return null;
            }
            UserDataBase = UserDataBase.Select(user => {
                user.Contacts = user.Contacts.Where(contact => contact.ContactId != contactId);
                return user;
            });
            applyChanges(UserDataBase);
            return contactId;
        }

        public Guid? DeleteUserByUserId(Guid userId)
        {
            if (!CheckUserIdExist(userId, UserDataBase))
            {
                return null;
            }
            UserDataBase = UserDataBase.Where(user => user.UserId != userId);
            applyChanges(UserDataBase);
            return userId;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            return UserDataBase.Select(user => new UserDto(user));
        }

        public ContactDto? GetContactByContactId(Guid contactId)
        {
            if (!CheckContactIdExist(contactId, UserDataBase))
            {
                return null;
            }

            var contactsEntity = UserDataBase.SelectMany(user => { 
                return user.Contacts.Where(contact => contact.ContactId != contactId);
            });
            var contact = contactsEntity.FirstOrDefault();

            if(contact is null)
            {
                return null;
            }
            return new ContactDto(contact);
        }

        public IEnumerable<ContactDto>? GetContactsByUserId(Guid userId)
        {
            if (!CheckUserIdExist(userId, UserDataBase))
            {
                return null;
            }
            var contactsEntity = UserDataBase
                .Where(user => user.UserId == userId)
                .SelectMany(user => user.Contacts);
            if (contactsEntity is null){
                return null;
            }
            return contactsEntity.Select(contact => new ContactDto(contact));
        }

        public UserDto? GetUserByUserId(Guid userId)
        {
            if (!CheckUserIdExist(userId, UserDataBase))
            {
                return null;
            }
            var usersEntity = UserDataBase.Where(user => user.UserId == userId);
            var user = usersEntity.FirstOrDefault();
            if(user is null){
                return null;
            }
            return new UserDto(user);
        }

        public Guid? UpdateContactByContactId(
            Guid contactId,
            string name,
            string phoneNumber,
            string email,
            string whatsapp
        )
        {
            if (!CheckContactIdExist(contactId, UserDataBase))
            {
                return null;
            }
            UserDataBase = UserDataBase.Select(user => {
                user.Contacts = user.Contacts.Select(contact =>
                {
                    if (contact.ContactId == contactId)
                    {
                        contact.Name = name;
                        contact.PhoneNumber = phoneNumber;
                        contact.Email = email;
                        contact.Whatsapp = whatsapp;
                    }
                    return contact;
                });
                return user;
            });
            applyChanges(UserDataBase);
            return contactId;
        }

        public Guid? UpdateUserByUserId(
            Guid userId,
            string name,
            string phoneNumber,
            string email,
            string whatsapp
        )
        {
            if (!CheckUserIdExist(userId, UserDataBase))
            {
                return null;
            }
            UserDataBase = UserDataBase.Select(user =>
            {
                if (user.UserId == userId)
                {
                    user.Name = name;
                    user.PhoneNumber = phoneNumber;
                    user.Email = email;
                    user.Whatsapp = whatsapp;
                }
                return user;
            });
            applyChanges(UserDataBase);
            return userId;
        }


        #region Private Methos
        private bool CheckUserIdExist(
            Guid userId, 
            IEnumerable<UserEntity> userDatabase
        )
        {
            return userDatabase.Where(user => user.UserId == userId).Any();
        }

        private bool CheckContactIdExist(
            Guid contactId,
            IEnumerable<UserEntity> userDatabase
        )
        {
            return userDatabase.Any(user =>
            {
                var expectedUser = user.Contacts.Where(contact => contact.ContactId == contactId);
                if (expectedUser.Any())
                {
                    return true;
                };
                return false;
            });
        }

        private void applyChanges(IEnumerable<UserEntity> users)
        {
            using (FileStream fs = new FileStream(@"store.xml", FileMode.OpenOrCreate))
            {
                var usersXml = serializer.Serialize(users);
                fs.SetLength(0);
                fs.Write(Encoding.ASCII.GetBytes(usersXml));
            }
        }
        #endregion
    }
}