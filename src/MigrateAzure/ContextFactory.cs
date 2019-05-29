using Microsoft.EntityFrameworkCore.Design;

namespace Migrate
{
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            //var optionsBuilder = new DbContextOptionsBuilder<Context>();

            return new Context();
        }
    }
}