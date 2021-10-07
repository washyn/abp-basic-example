using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Washyn.EntityFrameworkCore
{
    public class EntityFrameworkCoreDbContextFactory : IDesignTimeDbContextFactory<EntityFrameworkCoreDbContext>
    {
        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Washyn.Web/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }

        public EntityFrameworkCoreDbContext CreateDbContext(string[] args)
        {
            //TODO: check if this need
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<EntityFrameworkCoreDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));
            // Console.WriteLine(configuration.GetConnectionString("Default"));
            return new EntityFrameworkCoreDbContext(builder.Options);
        }
    }
}