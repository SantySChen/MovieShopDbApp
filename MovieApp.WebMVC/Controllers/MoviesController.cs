using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.WebMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        private readonly IMovieServiceAsync _movieServiceAsync;
        private readonly IGenreServiceAsync _genreServiceAsync;
        public MoviesController(IMovieService movieService, IGenreService genreService, IMovieServiceAsync movieServiceAsync, IGenreServiceAsync genreServiceAsync)
        {
            _movieService = movieService;
            _genreService = genreService;
            _movieServiceAsync = movieServiceAsync;
            _genreServiceAsync = genreServiceAsync;
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
            ViewBag.CastWithCharacter = _movieServiceAsync.GetCastsAsync(1);
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
    }
}
