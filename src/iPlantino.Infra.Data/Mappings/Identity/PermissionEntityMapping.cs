using iPlantino.Domain.AggregatesModel.PermissionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iPlantino.Infra.Data.Mappings.Identity
{ 
    public class PermissionEntityMapping : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> entity)
        {
            entity.ToTable("permission", Schemas.IDENTITY);

            entity.HasKey(k => k.Id);

            entity.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            entity.Property(p => p.Title)
                .HasColumnName("title")
                .HasMaxLength(256)
                .IsRequired(false);

            entity.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
