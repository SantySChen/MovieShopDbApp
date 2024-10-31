using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepositoryAsync : BaseRepositoryAsync<Movie>, IMovieRepositoryAsync
    {
        private readonly MovieShopAppDbContext _context;
        public MovieRepositoryAsync(MovieShopAppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CastWithCharacter>> GetCastsAsync(int id)
        {
            var casts = from mc in _context.MovieCasts
                        join c in _context.Casts on mc.CastId equals c.Id
                        where mc.MovieId == id
                        select new CastWithCharacter
                        {
                            Cast = c,
                            Character = mc.Character
                        };
            return await casts.ToListAsync();
        }

        public async Task<IEnumerable<string>> GetGenreNameAsync(int id)
        {
            var genreNames = from mg in _context.MovieGenres
                            join g in _context.Genres on mg.GenreId equals g.Id
                            where mg.MovieId == id
                            select g.Name;
            return await genreNames.Distinct().ToListAsync();
        }

        public async Task<Movie> GetHighestGrossingMovieAsync()
        {
            return await _context.Movies.OrderByDescending(x => x.Revenue).FirstOrDefaultAsync();
        }

        public async Task<decimal> GetRateAsync(int id)
        {
            return await _context.Reviews.Where(x => x.MovieId == id).AverageAsync(x => x.Rating);
        }

        public async Task<IEnumerable<Movie>> GetTopMoviesAsync(int number = 20)
        {
            return await _context.Movies.OrderBy(x => x.Id).Take(number).ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetTopRevenueMoviesAsync(int number = 20)
        {
            return await _context.Movies.OrderByDescending(x => x.Revenue).Take(number).ToListAsync();
        }

        public async Task<IEnumerable<Trailer>> GetTrailersByIdAsync(int id)
        {
            return await _context.Trailers.Where(t => t.Movie.Id == id).ToListAsync();
        }
    }
}
