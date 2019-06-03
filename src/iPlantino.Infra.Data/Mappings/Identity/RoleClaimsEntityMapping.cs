using iPlantino.Infra.CrossCutting.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iPlantino.Infra.Data.Mappings.Identity
{
    public class RoleClaimsEntityMapping : IEntityTypeConfiguration<ApplicationRoleClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationRoleClaim> entity)
        {
            entity.ToTable("role_claims", Schemas.IDENTITY);

            entity.HasIndex(e => e.RoleId)
                .HasName("role_claims_id_index");

            entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleClaims)
                    .HasForeignKey(d => d.RoleId);

            entity.Property(e => e.RoleId)
                .HasColumnName("role_id")
                .IsRequired();

            entity.Property(x => x.Id)
               .HasColumnName("id")
               .IsRequired();

            entity.Property(x => x.ClaimType)
               .HasColumnName("claim_type");

            entity.Property(x => x.ClaimValue)
               .HasColumnName("claim_value");
        }
    }
}