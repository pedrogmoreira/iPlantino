using iPlantino.Domain.Device.Models;
using iPlantino.Infra.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iPlantino.Infra.Data.Mappings.Device
{
    public class ArduinoEntityMapping : IEntityTypeConfiguration<Arduino>
    {
        public void Configure(EntityTypeBuilder<Arduino> entity)
        {
            entity.ToTable("arduino", Schemas.DEVICE);

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedNever();

            entity.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(x => x.Observation)
                .HasColumnName("observation")
                .HasMaxLength(256);

            entity.Property(x => x.MacAdrress)
                .HasColumnName("mac_address")
                .IsRequired()
                .HasMaxLength(256);

            entity.AddInclusionDate();
        }
    }
}
