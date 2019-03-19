using iPlantino.Domain.Core.Cryptography;
using iPlantino.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iPlantino.Domain.Models.Authentication
{
    public class User : Entity
    {
        public User(string name, string login, string password, string telephone, string email)
        {
            Hash = EncryptPassword(password);
            Login = login.ToLower();
            Name = name;
            Telephone = telephone;
            Email = email;
        }

        public string Name { get; private set; }
        public string Login { get; private set; }
        public string Hash { get; private set; }
        public DateTime? Deleted { get; private set; }
        public string Telephone { get; private set; }
        public string Email { get; private set; }

        public IEnumerable<UserGroup> UsersGroup { get; private set; }

        public IEnumerable<string> Permissions
        {
            get
            {
                return UsersGroup
                    ?.Select(x => x.Group)
                    ?.SelectMany(x => x.PermissionsGroup)
                    ?.Select(x => x.Permission)
                    ?.Select(x => x.Name)
                    ?.Distinct();
            }
        }

        public IEnumerable<string> Groups
        {
            get
            {
                return UsersGroup
                    ?.Select(x => x.Group.Name);
            }
        }

        //EF
        protected User() { }

        public bool Authenticate(string login, string password)
        {
            var passwordHash = new PasswordHash();
            return Login == login && passwordHash.ValidatePassword(password, Hash);
        }

        private string EncryptPassword(string password)
        {
            return new PasswordHash().CreateHash(password);
        }

        public void DeleteUser()
        {
            Deleted = DateTime.Now;
        }

        public void Activate()
        {
            Deleted = null;
            //UpdatedAt = DateTime.Now;
        }

        public void ChangePassword(string password)
        {
            Hash = EncryptPassword(password);
            // UpdatedAt = DateTime.Now;
        }

        public void EditUser(string telephone, string email)
        {
            Telephone = telephone;
            Email = email;
            // UpdatedAt = DateTime.Now;
        }
    }
}
