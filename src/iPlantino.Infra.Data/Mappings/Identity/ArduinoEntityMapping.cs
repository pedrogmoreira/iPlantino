using iPlantino.Infra.CrossCutting.Identity.Entities;
using iPlantino.Infra.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace iPlantino.Infra.Data.Mappings.Identity
{
    public class ArduinoEntityMapping : IEntityTypeConfiguration<ApplicationArduino>
    {
        public void Configure(EntityTypeBuilder<ApplicationArduino> entity)
        {
            entity.ToTable("arduino", Schemas.DEVICE);

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
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(256);

            entity.AddInclusionDate();
        }
    }
}
