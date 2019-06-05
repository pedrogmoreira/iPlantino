using Microsoft.EntityFrameworkCore;

namespace iPlantino.Infra.Data.Context
{
    public class DeviceContext : DbContext
    {
        public DeviceContext(DbContextOptions<DeviceContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(Schemas.DEVICE);

            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly(GetType().Assembly,
                "iPlantino.Infra.Data.Mappings.Device");
        }
    }
}
