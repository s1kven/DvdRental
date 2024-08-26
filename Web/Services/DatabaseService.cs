using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Web.Services;

public sealed class DatabaseService : IDatabaseService
{
    private const string ConnectionStringTemplate =
        "Host={HOST};Port={PORT};Database={DATABASE};" +
        "Username={USERNAME};Password={PASSWORD};Trust Server Certificate={TRUSTCERTIFICATE};";

    public void AddDbContext(IServiceCollection services, DatabaseSettings databaseSettings)
    {
        services.AddDbContext<ApplicationDbContext>(
            opt => BuildDbContext(opt, databaseSettings));
    }

    private void BuildDbContext(DbContextOptionsBuilder optionsBuilder, DatabaseSettings settings)
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

    #region Instance

    private static IDatabaseService _instance;

    public static IDatabaseService Instance => _instance ??= new DatabaseService();

    #endregion Instance
}