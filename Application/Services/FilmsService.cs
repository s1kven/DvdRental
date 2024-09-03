using Application.Dtos.Responses;
using Domain.Films;

namespace Application.Services;

public class FilmsService(IFilmsRepository filmsRepository) : IFilmsService
{
    public async Task<GetFilmsResponseData> GetFilmsByPageAsync(int page)
    {
        var films = await filmsRepository.GetFilmsByPageAsync(page);
        return new GetFilmsResponseData { Films = films };
    }
}