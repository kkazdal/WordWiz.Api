using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using WordWiz.Infrastructure.Data.Context;

namespace WordWiz.Infrastructure.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<WordWizDbContext>
{
    public WordWizDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<WordWizDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseNpgsql(connectionString);

        return new WordWizDbContext(builder.Options);
    }
} 