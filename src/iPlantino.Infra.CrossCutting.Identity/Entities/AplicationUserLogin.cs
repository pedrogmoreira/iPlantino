using Microsoft.AspNetCore.Identity;
using System;

namespace iPlantino.Infra.CrossCutting.Identity.Entities
{
    public class AplicationUserLogin : IdentityUserLogin<Guid>
    {
        public ApplicationUser User { get; set; }
    }
}