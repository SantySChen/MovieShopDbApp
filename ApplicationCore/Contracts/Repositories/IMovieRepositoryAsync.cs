using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IMovieRepositoryAsync : IRepositoryAsync<Movie>
    {
        Task<IEnumerable<Movie>> GetTopRevenueMoviesAsync(int number = 20);

        Task<IEnumerable<Movie>> GetTopMoviesAsync(int number = 20);

        Task<Movie> GetHighestGrossingMovieAsync();

        Task<IEnumerable<string>> GetGenreNameAsync(int id);

        Task<Decimal> GetRateAsync(int id);

        Task<IEnumerable<Trailer>> GetTrailersByIdAsync(int id);

        Task<IEnumerable<CastWithCharacter>> GetCastsAsync(int id);
    }
}
