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
    public class CastRepository : BaseRepository<Cast>, ICastRepository
    {
        private readonly MovieShopAppDbContext _context;
        public CastRepository(MovieShopAppDbContext c) : base(c)
        {
            _context = c;
        }

        public Cast GetCastDetails(int id)
        {
            return _context.Set<Cast>().Find(id);
        }

        IEnumerable<Movie> ICastRepository.GetById(int id)
        {
            return _context.MovieCasts
            .Where(mc => mc.CastId == id)       
            .Include(mc => mc.Movie)
            .Include(mc => mc.Cast)
            .Select(mc => mc.Movie)             
            .ToList();
        }
    }
}
