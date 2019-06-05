using iPlantino.Infra.Data.Mappings.Device;
using iPlantino.Infra.Data.Mappings.Identity;
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
            var identityAssembly = typeof(UserEntityMapping).Assembly;
            var deviceAssembly = typeof(HumidityEntityMapping).Assembly;

            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly(identityAssembly, "iPlantino.Infra.Data.Mappings.Identity");
            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly(deviceAssembly, "iPlantino.Infra.Data.Mappings.Device");
        }
    }
}