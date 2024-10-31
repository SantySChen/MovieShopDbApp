using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieServiceAsync
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<Movie> GetMovieDetailsAsync(int id);
        Task<IEnumerable<Movie>> GetTopMoviesAsync(int num = 20);

        Task<IEnumerable<string>> GetGenreAsync(int id);
        Task<decimal> GetRateAsync(int id);

        Task<int> AddReviewAsync(Review review);

        Task<IEnumerable<Trailer>> GetTrailersByIdAsync(int id);

        Task<IEnumerable<CastWithCharacter>> GetCastsAsync(int id);
    }
}
