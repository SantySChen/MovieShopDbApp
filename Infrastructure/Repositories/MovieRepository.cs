using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        private readonly MovieShopAppDbContext _context;
        public MovieRepository(MovieShopAppDbContext c) : base(c)
        {
            _context = c;
        }

        public IEnumerable<CastWithCharacter> GetCasts(int id)
        {
            var casts = from mc in _context.MovieCasts
                        join c in _context.Casts on mc.CastId equals c.Id
                        where mc.MovieId == id
                        select new CastWithCharacter
                        {
                            Cast = c,
                            Character = mc.Character
                        };
            return casts.ToList();
        }

        public IEnumerable<string> GetGenreName(int id)
        {
            var genreNames = from mg in _context.MovieGenres
                             join g in _context.Genres on mg.GenreId equals g.Id
                             where mg.MovieId == id
                             select g.Name;
            return genreNames.Distinct().ToList();
        }

        public Movie GetHighestGrossingMovie()
        {
            return _context.Movies.OrderByDescending(x => x.Revenue).FirstOrDefault();
        }

        public decimal GetRate(int id)
        {
            return _context.Reviews.Where(x => x.MovieId == id).Average(x => x.Rating);
        }

        public IEnumerable<Movie> GetTopMovies(int number = 20)
        {
            return _context.Movies.OrderBy(x => x.Id).Take(number).ToList();
        }

        public IEnumerable<Movie> GetTopRevenueMovies(int number = 20)
        {
            return _context.Movies.OrderByDescending(x => x.Revenue).Take(number).ToList();
        }

        public IEnumerable<Trailer> GetTrailersById(int id)
        {
            return _context.Trailers.Where(t => t.Movie.Id == id).ToList();
        }
    }
}
