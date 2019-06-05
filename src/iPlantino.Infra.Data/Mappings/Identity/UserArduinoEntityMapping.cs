using iPlantino.Infra.CrossCutting.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iPlantino.Infra.Data.Mappings.Identity
{
    public class UserArduinoEntityMapping : IEntityTypeConfiguration<ApplicationUserArduino>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserArduino> entity)
        {
            entity.ToTable("user_arduino", Schemas.IDENTITY);

            entity.HasKey(e => new { e.UserId, e.ArduinoId});

            entity.HasIndex(e => e.ArduinoId)
                .HasName("user_arduino_id_index");

            entity.HasOne(d => d.Arduino)
                .WithOne(p => p.UserArduino);

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserArduinos)
                .HasForeignKey(d => d.UserId);

            entity.Property(x => x.UserId)
                .HasColumnName("user_id");

            entity.Property(x => x.ArduinoId)
                .HasColumnName("arduino_id");
        }
    }
}
