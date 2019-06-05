using iPlantino.Domain.Device.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iPlantino.Infra.Data.Mappings.Device
{
    public class ArduinoHumidityEntityMapping : IEntityTypeConfiguration<ArduinoHumidity>
    {
        public void Configure(EntityTypeBuilder<ArduinoHumidity> entity)
        {
            entity.ToTable("arduino_has_humidity", Schemas.DEVICE);

            entity.HasKey(e => new { e.ArduinoId, e.HumidityId });

            entity.HasIndex(e => e.ArduinoId)
                .HasName("arduino_has_humidity_id_index");

            entity.HasOne(d => d.Arduino)
                .WithMany(p => p.ArduinoHumidities)
                .HasForeignKey(d => d.ArduinoId);

            entity.HasOne(d => d.Humidity)
                .WithMany(p => p.ArduinoHumidities)
                .HasForeignKey(d => d.HumidityId);

            entity.Property(x => x.ArduinoId)
                .HasColumnName("arduino_id");

            entity.Property(x => x.HumidityId)
                .HasColumnName("humidity_id");
        }
    }
}
