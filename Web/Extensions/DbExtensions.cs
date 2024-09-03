using Persistence.Config;
using Web.Services;

namespace Web.Extensions;

public static class DbExtensions
{
    public static IServiceCollection AddDbContext(this IServiceCollection services, DatabaseSettings databaseSettings)
    {
        DatabaseService.Instance.AddDbContext(services, databaseSettings);
        return services;
    }
}