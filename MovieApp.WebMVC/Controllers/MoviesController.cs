using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using MovieApp.WebMVC.Models;

namespace MovieApp.WebMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        private readonly IMovieServiceAsync _movieServiceAsync;
        private readonly IGenreServiceAsync _genreServiceAsync;
        private readonly IMovieRepositoryAsync _movieRepository;
        public MoviesController(IMovieService movieService, IGenreService genreService, IMovieServiceAsync movieServiceAsync, IGenreServiceAsync genreServiceAsync, IMovieRepositoryAsync movieRepositoryAsync)
        {
            _movieService = movieService;
            _genreService = genreService;
            _movieServiceAsync = movieServiceAsync;
            _genreServiceAsync = genreServiceAsync;
            _movieRepository = movieRepositoryAsync;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            ViewBag.GenreNames = await _movieServiceAsync.GetGenreAsync(1);
            ViewBag.Trailers = await _movieServiceAsync.GetTrailersByIdAsync(1);
            ViewBag.CastWithCharacter = await _movieServiceAsync.GetCastsAsync(1);
            //ViewBag.Rating = _movieService.GetRate(1);
            var movie = await _movieServiceAsync.GetMovieDetailsAsync(1);
            return View(movie);
        }

        [HttpGet]
        public async Task<IActionResult> Review(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Review(Review review)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Buy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Genre(string genreName, int pageNumber = 1, int pageSize = 30)
        {
            try
            {
                int id = await _genreServiceAsync.GetIdByNameAsync(genreName);
                var moviesQuery = await MoviesByGenreAsync(id, pageSize, pageNumber);
                var movies = moviesQuery
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
                var totalMovies = moviesQuery.Count();

                var result = new MoviesByGenreModel
                {
                    Movies = movies,
                    CurrentPage = pageNumber,
                    TotalPages = (int)Math.Ceiling(totalMovies / (double)pageSize) < 1 ? 1 : (int)Math.Ceiling(totalMovies / (double)pageSize),
                    Genre = genreName
                };


                return View(result);


            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("Error");
            }
        }

        public async Task<IEnumerable<Movie>> MoviesByGenreAsync(int id, int pageSize = 30, int pageNumber = 1)
        {
            var genre = await _genreServiceAsync.GetGerneByIdAsync(id);
            return await _movieRepository.GetMoviesByGenreAsync(genre, pageNumber, pageSize);

        }
    }
}
