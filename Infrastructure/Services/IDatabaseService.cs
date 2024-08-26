using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services;

public interface IDatabaseService
{
    public void AddDbContext(IServiceCollection services, 
        DatabaseSettings databaseSettings);
}