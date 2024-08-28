using Application.Dtos.Responses;
using Infrastructure.Data;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Modules.Films;

public sealed class FilmsModule() : BaseModule("/Films")
{
    private const int PageSize = 10;

    private const string FilmsPageError = "page must be greater than 0";
    
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(string.Empty, GetFilms);
    }
    
    #region Endpoints
    
    #region GET

    private async Task<IResult> GetFilms([FromQuery] int page, ApplicationDbContext dbContext)
    {
        if (page <= 0)
        {
            throw new BadHttpRequestException(FilmsPageError);
        }
        var currentPosition = (page - 1) * PageSize;
        var films = await dbContext.Films.Skip(currentPosition).Take(PageSize).
            ToListAsync();
        var responseData = new GetFilmsResponseData() { Films = films };
        return Result.Ok(responseData);
    }
    
    #endregion GET
    
    #endregion Endpoints
}