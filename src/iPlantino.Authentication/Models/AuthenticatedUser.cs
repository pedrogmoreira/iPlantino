using System;
using System.Collections.Generic;

namespace iPlantino.Authentication.Models
{
    public class AuthenticatedUser
    {
        public AuthenticatedUser(Guid id, string name, string login, string email, IEnumerable<string> permissions)
        {
            Id = id;
            Name = name;
            Login = login;
            Email = email;
            Permissions = permissions;
        }

        public Guid Id { get; private set; }
        public string Login { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }

        public IEnumerable<string> Permissions { get; private set; }
    }
}