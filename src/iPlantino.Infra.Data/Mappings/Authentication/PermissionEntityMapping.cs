using iPlantino.Domain.Models.Authentication;
using iPlantino.Infra.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iPlantino.Infra.Data.Mappings
{
    public class PermissionEntityMapping : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> entity)
        {
            entity.ConfigureKey("id_permission");

            entity.ToTable("tbl_permission", "authentication");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar(50)");

            entity.AddInclusionDate();
        }
    }
}