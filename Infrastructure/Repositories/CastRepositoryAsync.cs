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
    public class CastRepositoryAsync : BaseRepositoryAsync<Cast>, ICastRepositoryAsync
    {
        private readonly MovieShopAppDbContext _context;
        public CastRepositoryAsync(MovieShopAppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Cast> GetCastDetailsAsync(int id)
        {
            return await _context.Set<Cast>().FindAsync(id);
        }

        async Task<CastWithMovies> ICastRepositoryAsync.GetByIdAsync(int id)
        {
            var cast = await _context.Set<Cast>().FirstOrDefaultAsync(x => x.Id == id);
            var moives = from mc in _context.MovieCasts
                         join m in _context.Movies on mc.MovieId equals m.Id
                         where mc.CastId == id
                         select m;
            return new CastWithMovies
            {
                Cast = cast,
                Movies = await moives.ToListAsync()
            };
        }
    }
}
