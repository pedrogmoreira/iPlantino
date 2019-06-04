using iPlantino.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iPlantino.Infra.CrossCutting.EntityFramework.Extensions
{
    public static class MapHelper
    {
        public static void ConfigureCreateAtAndUpdteAt<T>(this EntityTypeBuilder<T> entity) where T : Entity
        {
            entity.Property(e => e.CreatedAt)
                .HasColumnName("data_inclusao")
                .HasDefaultValueSql("Now()");

            //entity.Property(e => e.)
            //    .IsRequired(false)
            //    .HasColumnName("data_atualizacao");
        }

        public static void IgnoreInclusao<T>(this EntityTypeBuilder<T> entity) where T : Entity
        {
            entity.Ignore(e => e.CreatedAt);
            //entity.Ignore(e => e.UpdatedAt);
        }

        public static void ConfigureKey<T>(this EntityTypeBuilder<T> entity, string columnsName) where T : Entity
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id)
                .HasDefaultValueSql("gen_random_uuid()");

            entity.Property(e => e.Id)
               .HasColumnName(columnsName);
        }
    }
}
