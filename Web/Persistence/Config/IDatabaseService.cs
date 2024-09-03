using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Config;

public interface IDatabaseService
{
    public void AddDbContext(IServiceCollection services,
        DatabaseSettings databaseSettings);
}