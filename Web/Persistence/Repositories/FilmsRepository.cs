using Domain.Entities;
using Domain.Films;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public sealed class FilmsRepository(ApplicationDbContext dbContext) : IFilmsRepository
{
    private const int PageSize = 10;

    public async Task<IEnumerable<Film>> GetFilmsByPageAsync(int page)
    {
        var currentPosition = (page - 1) * PageSize;
        return await dbContext.Films.Skip(currentPosition).Take(PageSize).ToListAsync();
    }
}