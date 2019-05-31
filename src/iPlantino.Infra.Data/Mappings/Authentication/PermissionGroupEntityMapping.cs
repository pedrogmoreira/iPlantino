using iPlantino.Domain.Models.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iPlantino.Infra.Data.Mappings.Authentication
{
    public class PermissionGroupEntityMapping : IEntityTypeConfiguration<PermissionGroup>
    {
        public void Configure(EntityTypeBuilder<PermissionGroup> entity)
        {
            entity.ToTable("tbl_permission_group", "authentication");

            entity.HasKey(x => new { x.IdGroup, x.IdPermission });

            entity.Property(e => e.IdGroup)
                .HasColumnName("id_group");

            entity.Property(e => e.IdPermission)
                .HasColumnName("id_permission");

            entity.HasOne(d => d.Group)
                .WithMany(p => p.PermissionsGroup)
                .HasForeignKey(d => d.IdGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_permission_group_group");

            entity.HasOne(d => d.Permission)
                .WithMany(p => p.PermissionGroup)
                .HasForeignKey(d => d.IdPermission)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_permission_group_permission");
        }
    }
}