using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using iPlantino.Infra.Data.Helpers;
using iPlantino.Domain.Device.Models;

namespace iPlantino.Infra.Data.Mappings.Device
{
    public class HumidityEntityMapping : IEntityTypeConfiguration<Humidity>
    {
        public void Configure(EntityTypeBuilder<Humidity> entity)
        {
            entity.ToTable("humidity", Schemas.DEVICE);

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedNever();

            entity.Property(x => x.Measurement)
                .HasColumnName("measurement")
                .IsRequired();

            entity.AddInclusionDate();
        }
    }
}
