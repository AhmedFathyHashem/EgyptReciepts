using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EgyptReciepts.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class EgyptRecieptsDbContextFactory : IDesignTimeDbContextFactory<EgyptRecieptsDbContext>
{
    public EgyptRecieptsDbContext CreateDbContext(string[] args)
    {
        EgyptRecieptsEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<EgyptRecieptsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new EgyptRecieptsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../EgyptReciepts.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
