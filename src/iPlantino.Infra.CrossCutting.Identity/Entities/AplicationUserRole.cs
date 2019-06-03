using Microsoft.AspNetCore.Identity;
using System;

namespace iPlantino.Infra.CrossCutting.Identity.Entities
{
    public class AplicationUserRole : IdentityUserRole<Guid>
    {
        public ApplicationRole Role { get; set; }
        public ApplicationUser User { get; set; }
    }
}