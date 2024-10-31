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
    public class MovieServiceAsync : IMovieServiceAsync
    {
        private readonly IMovieRepositoryAsync _movieRepository;
        private readonly IReportRepositoryAsync _reportRepository;
        public MovieServiceAsync(IMovieRepositoryAsync movieRepository, IReportRepositoryAsync reportRepository)
        {
            _movieRepository = movieRepository;
            _reportRepository = reportRepository;
        }

        public Task<int> AddReviewAsync(Review review)
        {
            return _reportRepository.InsertAsync(review);
        }

        public async Task<IEnumerable<CastWithCharacter>> GetCastsAsync(int id)
        {
            return await _movieRepository.GetCastsAsync(id);
        }

        public async Task<IEnumerable<string>> GetGenreAsync(int id)
        {
            return await _movieRepository.GetGenreNameAsync(id);
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task<Movie> GetMovieDetailsAsync(int id)
        {
            var m = await _movieRepository.GetByIdAsync(id);
            return m;
        }

        public async Task<decimal> GetRateAsync(int id)
        {
            return await _movieRepository.GetRateAsync(id);
        }

        public async Task<IEnumerable<Movie>> GetTopMoviesAsync(int num = 20)
        {
            var movies = await _movieRepository.GetTopMoviesAsync(num);
            return movies;
        }
            

        public Task<IEnumerable<Trailer>> GetTrailersByIdAsync(int id)
        {
            return _movieRepository.GetTrailersByIdAsync(id);
        }
    }
}
