using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        Movie GetMovieById(int id); 
        Movie GetMovieDetails(int id);
        IEnumerable<Movie> GetTopMovies(int num = 20);

        IEnumerable<string> GetGenre(int id);
        decimal GetRate(int id);

        int AddReview(Review review);

        IEnumerable<Trailer> GetTrailersById(int id);

        IEnumerable<CastWithCharacter> GetCasts(int id);

    }
}
