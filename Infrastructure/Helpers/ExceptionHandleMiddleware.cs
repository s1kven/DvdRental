using Application.Dtos.Responses;
using Infrastructure.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using StatusCodes = Infrastructure.Enums.StatusCodes;

namespace Infrastructure.Helpers;

public class ExceptionHandleMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandleMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleException(ex, httpContext);
        }
    }

    private async Task HandleException(Exception ex, HttpContext httpContext)
    {
        //can be specified handling custom exception.
        if (ex is BadHttpRequestException httpRequestException)
        {
            await HandleException(httpRequestException, httpContext, StatusCodes.Status400BadRequest);
        }
        else
        {
            await HandleException(ex, httpContext, StatusCodes.Status500Internal);
        }
    }

    private async Task HandleException(Exception ex, HttpContext httpContext, 
        StatusCodes statusCode, string? errorMessage = null)
    {
        httpContext.Response.StatusCode = (int)statusCode;
        await httpContext.Response.WriteAsJsonAsync(new ApiResponse<ErrorResponseData>(false,
            statusCode, errorMessage: errorMessage ?? ex.Message));
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class ExceptionHandleMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandleMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandleMiddleware>();
    }
}