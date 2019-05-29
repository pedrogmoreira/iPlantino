using iPlantino.Domain.Models.Authentication;
using iPlantino.Infra.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iPlantino.Infra.Data.Mappings
{
    public class UserEntityMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ConfigureKey("id_user");

            entity.ToTable("tbl_user", "authentication");

            entity.Property(e => e.Email)
                .IsRequired(false)
                .HasColumnName("email")
                .HasColumnType("varchar(512)");

            entity.Property(e => e.Deleted)
                .HasColumnName("deleted")
                .HasColumnType("date");

            entity.Property(e => e.Hash)
                .IsRequired()
                .HasColumnName("hash")
                .HasColumnType("varchar(100)");

            entity.Property(e => e.Login)
                .IsRequired()
                .HasColumnName("login")
                .HasColumnType("varchar(20)");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar(256)");

            entity.Property(e => e.Telephone)
                .IsRequired(false)
                .HasColumnName("telephone")
                .HasColumnType("varchar(15)");

            entity.Ignore(x => x.Permissions);

            entity.AddInclusionDate();

            entity.HasData(new User("administrador", "admin", "123456", null, null));
        }
    }
}