using iPlantino.Domain.Models.Authentication;
using iPlantino.Infra.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iPlantino.Infra.Data.Mappings.Authentication
{
    public class GroupEntityMapping : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> entity)
        {
            entity.ConfigureKey("id_group");

            entity.ToTable("tbl_group", "authentication");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar(50)");

            entity.Property(e => e.Observation)
                .IsRequired()
                .HasColumnName("observation")
                .HasColumnType("varchar(512)");

            entity.AddInclusionDate();
        }
    }
}