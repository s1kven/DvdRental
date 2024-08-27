using Infrastructure.Enums;

namespace Infrastructure.Common;

public sealed record ApiResponse<T>
{
    public bool Success { get; init; }
    
    public StatusCodes StatusCode { get; init; }
    
    public string? ErrorMessage { get; init; }
    
    public T? Data { get; init; }

    public ApiResponse(bool success, StatusCodes statusCode, T? data = default, string? errorMessage = default)
    {
        Success = success;
        StatusCode = statusCode;
        Data = data;
        ErrorMessage = errorMessage;
    }
}