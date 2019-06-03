using Microsoft.AspNetCore.Identity;
using System;

namespace iPlantino.Infra.CrossCutting.Identity.Entities
{
    public class ApplicationUserToken : IdentityUserToken<Guid>
    {
        public ApplicationUser User { get; set; }
    }
}