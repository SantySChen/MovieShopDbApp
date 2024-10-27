using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        
        public MovieService(IMovieRepository repo)
        {
            _repository = repo;
        }

        public IEnumerable<Movie> GetTopMovies(int num = 20)
        {
            var movies = _repository.GetTopMovies(num);
            return movies.Select(m => new Movie
            {
                Id = m.Id,
                ImdbUrl = m.ImdbUrl,
                PosterUrl = m.PosterUrl
            }).ToList();
        }
    }
}
