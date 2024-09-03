using Domain.Films;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Config;
using Persistence.Repositories;

namespace Persistence;

public static class DependencyInjection
{
    private const string ConnectionStringTemplate =
        "Host={HOST};Port={PORT};Database={DATABASE};" +
        "Username={USERNAME};Password={PASSWORD};Trust Server Certificate={TRUSTCERTIFICATE};";
    
    public static IServiceCollection AddPersistence(this IServiceCollection services, 
        DatabaseSettings databaseSettings)
    {
        AddDbContext(services, databaseSettings);

        services.AddScoped<IFilmsRepository, FilmsRepository>();
        
        return services;
    }

    public static void AddDbContext(IServiceCollection services, DatabaseSettings databaseSettings)
    {
        services.AddDbContext<ApplicationDbContext>(
            opt => BuildDbContext(opt, databaseSettings));
    }

    private static void BuildDbContext(DbContextOptionsBuilder optionsBuilder, DatabaseSettings settings)
    {
        var connectionString = ConnectionStringTemplate
            .Replace("{HOST}", settings.Host)
            .Replace("{PORT}", settings.Port.ToString())
            .Replace("{DATABASE}", settings.DatabaseName)
            .Replace("{USERNAME}", settings.Username)
            .Replace("{PASSWORD}", settings.Password)
            .Replace("{TRUSTCERTIFICATE}", settings.TrustCertificate.ToString());

        optionsBuilder.UseNpgsql(connectionString);
    }
}