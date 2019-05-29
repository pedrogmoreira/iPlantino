using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace iPlantino.Infra.Data.Context
{
    public class iPlantinoContext : DbContext
    {
        public iPlantinoContext(DbContextOptions<iPlantinoContext> options) :
           base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly(GetType().Assembly, "iPlantino.Infra.Data.Mappings");

            base.OnModelCreating(modelBuilder);
        }
    }
}
