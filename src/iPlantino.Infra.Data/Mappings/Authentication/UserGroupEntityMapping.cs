using iPlantino.Domain.Models.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iPlantino.Infra.Data.Mappings
{
    public class UserGroupEntityMapping : IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> entity)
        {
            entity.ToTable("tbl_user_group", "authentication");

            entity.HasKey(x => new { x.IdGroup, x.IdUser });

            entity.Property(e => e.IdGroup)
                .HasColumnName("id_group");

            entity.Property(e => e.IdUser)
                .HasColumnName("id_user");

            entity.HasOne(d => d.Group)
                .WithMany(p => p.UsersGroup)
                .HasForeignKey(d => d.IdGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_group_group");

            entity.HasOne(d => d.User)
                .WithMany(p => p.UsersGroup)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_group_user");
        }
    }
}