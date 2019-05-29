using iPlantino.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Migrate
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /* Azure Connection String */
                optionsBuilder.UseSqlServer("Server=tcp:uniceub-db.database.windows.net,1433;Initial Catalog=iPlantino;Persist Security Info=False;User ID=adminceub;Password=Passw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(GroupEntityMapping).Assembly;

            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly(assembly, "iPlantino.Infra.Data.Mappings");
        }
    }
}