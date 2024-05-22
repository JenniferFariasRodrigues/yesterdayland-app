// Just to support Microsoft.Data.Sql
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace YesterdaylandAPI.Data
{
    public class YesterdaylandContextFactory : IDesignTimeDbContextFactory<YesterdaylandContext>
    {
        public YesterdaylandContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<YesterdaylandContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new YesterdaylandContext(optionsBuilder.Options);
        }
    }
}
