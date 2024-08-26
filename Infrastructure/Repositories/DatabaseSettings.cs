namespace Infrastructure.Repositories;

public record DatabaseSettings
{
    public string? Host { get; init; }
    
    public int Port { get; init; }
    
    public string? DatabaseName { get; init; }
    
    public string? Username { get; init; }
    
    public string? Password { get; init; }
    
    public bool? TrustCertificate { get; init; }
}