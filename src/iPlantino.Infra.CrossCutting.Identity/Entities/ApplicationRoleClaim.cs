using Microsoft.AspNetCore.Identity;
using System;

namespace iPlantino.Infra.CrossCutting.Identity.Entities
{
    public class ApplicationRoleClaim : IdentityRoleClaim<Guid>
    {
        public ApplicationRole Role { get; set; }
    }
}