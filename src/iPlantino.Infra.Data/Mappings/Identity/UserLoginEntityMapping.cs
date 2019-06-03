using iPlantino.Infra.CrossCutting.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iPlantino.Infra.Data.Mappings.Identity
{
    public class UserLoginEntityMapping : IEntityTypeConfiguration<AplicationUserLogin>
    {
        public void Configure(EntityTypeBuilder<AplicationUserLogin> entity)
        {
            entity.ToTable("user_login", Schemas.IDENTITY);

            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId)
                .HasName("user_login_id_index");

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserLogins)
                .HasForeignKey(d => d.UserId);

            entity.Property(x => x.LoginProvider)
                .HasColumnName("login_provider")
                .IsRequired();

            entity.Property(x => x.ProviderKey)
                .HasColumnName("provider_key")
                .IsRequired();

            entity.Property(x => x.ProviderDisplayName)
                .HasColumnName("provider_display_name");

            entity.Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired();
        }
    }
}