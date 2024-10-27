using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Movie> GetTopMovies(int number = 20)
        {
            return _context.Movies.OrderBy(x => x.Id).Take(number).ToList();
        }

        public IEnumerable<Movie> GetTopRevenueMovies(int number = 20)
        {
            return _context.Movies.OrderByDescending(x => x.Revenue).Take(number).Include(x => x.Genres).ToList();
        }
    }
}
