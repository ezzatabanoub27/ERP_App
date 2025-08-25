using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NewApp.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class NewAppDbContextFactory : IDesignTimeDbContextFactory<NewAppDbContext>
{
    public NewAppDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        NewAppEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<NewAppDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new NewAppDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../NewApp.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
