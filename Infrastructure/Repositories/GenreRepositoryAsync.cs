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
    public class GenreRepositoryAsync : BaseRepositoryAsync<Genre>, IGenreRepositoryAsync
    {
        private MovieShopAppDbContext _context;
        public GenreRepositoryAsync(MovieShopAppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> GetIdByNameAsync(string name)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Name == name);

            return genre != null ? genre.Id : 0;
        }
    }
}
