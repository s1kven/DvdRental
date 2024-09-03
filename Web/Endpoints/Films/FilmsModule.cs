using Application.Services;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Web.Endpoints.Films;

public sealed class FilmsModule() : BaseModule("/Films")
{
    private const string FilmsPageError = "page must be greater than 0";

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(string.Empty, GetFilms);
    }

    #region Endpoints

    #region GET

    private async Task<IResult> GetFilms([FromQuery] int page, FilmsService filmsService)
    {
        if (page <= 0) throw new BadHttpRequestException(FilmsPageError);

        var filmsResponse = await filmsService.GetFilmsByPageAsync(page);
        return Result.Ok(filmsResponse);
    }

    #endregion GET

    #endregion Endpoints
}