using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Modules.Films;

public sealed class FilmsModule() : BaseModule("/Films")
{
    private const int PageSize = 10;
    
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(string.Empty, GetFilms);
    }
    
    #region Endpoints
    
    #region GET

    private async Task<IResult> GetFilms([FromQuery] int page, ApplicationDbContext dbContext)
    {
        var currentPosition = (page - 1) * PageSize;
        var films = await dbContext.Films.Skip(currentPosition).Take(PageSize).
            ToListAsync();
        if (films.Count == 0)
        {
            return Results.NoContent();
        }
        return Results.Ok(films);
    }
    
    #endregion GET
    
    #endregion Endpoints
}