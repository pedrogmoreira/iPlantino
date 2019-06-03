using iPlantino.Infra.CrossCutting.Identity.Configurations;
using iPlantino.Infra.CrossCutting.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace iPlantino.Infra.Data.Context
{
    public class IdentityContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid,
        AplicationUserClaim, AplicationUserRole, AplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(IdentityConfigurations.DB_DEFAULT_SCHEMA);

            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly(GetType().Assembly,
                "iPlantino.Infra.Data.Mappings.Identity");
        }
    }
}