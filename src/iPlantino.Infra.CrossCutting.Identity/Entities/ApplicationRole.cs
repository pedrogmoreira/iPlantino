using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace iPlantino.Infra.CrossCutting.Identity.Entities
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole(Guid id,string name)
        {
            Id = id;
            Name = name;
        }
        public ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
        public ICollection<AplicationUserRole> UserRoles { get; set; }
    }
}