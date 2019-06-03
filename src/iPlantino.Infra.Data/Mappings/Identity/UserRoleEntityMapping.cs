using iPlantino.Infra.CrossCutting.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iPlantino.Infra.Data.Mappings.Identity
{
    public class UserRoleEntityMapping : IEntityTypeConfiguration<AplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<AplicationUserRole> entity)
        {
            entity.ToTable("user_role", Schemas.IDENTITY);

            entity.HasKey(e => new { e.UserId, e.RoleId });

            entity.HasIndex(e => e.RoleId)
                .HasName("user_role_id_index");

            entity.HasOne(d => d.Role)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId);

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId);

            entity.Property(x => x.UserId)
                .HasColumnName("user_id");

            entity.Property(x => x.RoleId)
                .HasColumnName("role_id");
        }
    }
}