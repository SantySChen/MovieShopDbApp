using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
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
        private readonly IReportRepository _reportRepository;
        public MovieService(IMovieRepository repo, IReportRepository reportRepository)
        {
            _repository = repo;
            _reportRepository = reportRepository;
        }

        public Movie GetMovieById(int id)
        {
            return _repository.GetById(id);
        }

        public Movie GetMovieDetails(int id)
        {
            var m = _repository.GetById(id);
            return new Movie
            {
                Id = m.Id,
                BackdropUrl = m.BackdropUrl,
                Budget = m.Budget,
                CreatedBy = m.CreatedBy,
                CreatedDate = m.CreatedDate,
                ImdbUrl = m.ImdbUrl,
                OriginalLanguage = m.OriginalLanguage,
                Overview = m.Overview,
                PosterUrl = m.PosterUrl,
                Price = m.Price,
                ReleaseDate = m.ReleaseDate,
                Revenue = m.Revenue,
                RunTime = m.RunTime,
                Tagline = m.Tagline,
                Title = m.Title,
                TmdbUrl = m.TmdbUrl,
                UpdatedBy = m.UpdatedBy,
                UpdatedDate = m.UpdatedDate
            };
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

        public IEnumerable<string> GetGenre(int id)
        {
            return _repository.GetGenreName(id);
        }

        public decimal GetRate(int id)
        {
            return _repository.GetRate(id);
        }

        public int AddReview(Review review)
        {
            return _reportRepository.Insert(review); 
        }

        public IEnumerable<CastWithCharacter> GetCasts(int id)
        {
            return _repository.GetCasts(id);
        }

        public IEnumerable<Trailer> GetTrailersById(int id)
        {
            return _repository.GetTrailersById(id);
        }
    }
}
