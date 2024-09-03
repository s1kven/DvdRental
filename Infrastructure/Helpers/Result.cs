using Domain.Entities;
using Infrastructure.Common;
using Microsoft.AspNetCore.Http;
using StatusCodes = Infrastructure.Enums.StatusCodes;

namespace Infrastructure.Helpers;

/// <summary>
///     Wrapper over Microsoft.AspNetCore.Http.Results
/// </summary>
public static class Result
{
    public static IResult Ok<TValue>(TValue? value) where TValue : IResponseData
    {
        var response = new ApiResponse<TValue>(true, StatusCodes.Status200Ok, value);

        return Results.Ok(response);
    }

    public static IResult NoContent()
    {
        return Results.NoContent();
    }
}