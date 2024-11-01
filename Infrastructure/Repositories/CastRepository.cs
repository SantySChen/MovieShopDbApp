﻿using ApplicationCore.Contracts.Repositories;
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

        public CastWithMovies GetById(int id)
        {
            var cast = _context.Casts.FirstOrDefault(c => c.Id == id);
            var movies = from mc in _context.MovieCasts
                         join m in _context.Movies on mc.MovieId equals m.Id
                         where mc.CastId == id
                         select m;

            return new CastWithMovies
            {
                Cast = cast,
                Movies = movies.ToList()
            };
                
        }
    }
}
