using iPlantino.Infra.CrossCutting.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iPlantino.Infra.Data.Mappings.Identity
{
    public class UserClaimEntityMapping : IEntityTypeConfiguration<AplicationUserClaim>
    {
        public void Configure(EntityTypeBuilder<AplicationUserClaim> entity)
        {
            entity.ToTable("user_claim", Schemas.IDENTITY);

            entity.HasIndex(e => e.UserId)
                .HasName("user_claim_id_index");

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserClaims)
                .HasForeignKey(d => d.UserId);

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            entity.Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            entity.Property(x => x.ClaimType)
               .HasColumnName("claim_type");

            entity.Property(x => x.ClaimValue)
               .HasColumnName("claim_value");
        }
    }
}