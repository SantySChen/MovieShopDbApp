using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Movie> GetTopRevenueMovies(int number = 20);

        IEnumerable<Movie> GetTopMovies(int number = 20);

        Movie GetHighestGrossingMovie();

        IEnumerable<string> GetGenreName(int id);

        Decimal GetRate(int id);

    }
}
