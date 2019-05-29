using iPlantino.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace iPlantino.Infra.Data.Helpers
{
    public static class MappingHelper
    {
        public static void ConfigureKey<T>(this EntityTypeBuilder<T> entity, string columnsName) where T : Entity
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id)
                .HasDefaultValueSql("newid()");

            entity.Property(e => e.Id)
               .HasColumnName(columnsName);
        }

        public static void AddInclusionDate<T>(this EntityTypeBuilder<T> entity) where T : Entity
        {
            entity.Property(e => e.CreatedAt)
                .HasColumnName("inclusion_date")
                .HasDefaultValueSql("getutcdate()");

            //entity.Property(e => e.UpdatedAt)
            //    .HasColumnName("data_atualizacao")
            //    .HasDefaultValueSql("Now()");
        }

        public static void IgnoreInclusion<T>(this EntityTypeBuilder<T> entity) where T : Entity
        {
            entity.Ignore(e => e.CreatedAt);
            //entity.Ignore(e => e.UpdatedAt);
        }
    }
}
