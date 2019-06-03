using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace iPlantino.Infra.CrossCutting.Identity.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser(Guid id, string name, string email, string userName) : base()
        {
            Id = id;
            Name = name;
            Email = email;
            UserName = userName;
        }

        public string Name { get; set; }

        public ICollection<AplicationUserClaim> UserClaims { get; set; }
        public ICollection<AplicationUserLogin> UserLogins { get; set; }
        public ICollection<ApplicationUserToken> UserTokens { get; set; }
        public ICollection<AplicationUserRole> UserRoles { get; set; }
    }
}