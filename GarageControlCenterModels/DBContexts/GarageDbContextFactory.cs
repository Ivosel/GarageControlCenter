using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GarageControlCenterBackend.DBContexts
{
    public class GarageDbContextFactory : IDesignTimeDbContextFactory<GarageDbContext>
    {
        public GarageDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<GarageDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new GarageDbContext(optionsBuilder.Options);
        }
    }
}
