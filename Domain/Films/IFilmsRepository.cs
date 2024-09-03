using Domain.Entities;

namespace Domain.Films;

public interface IFilmsRepository
{
    public Task<IEnumerable<Film>> GetFilmsByPageAsync(int page);
}