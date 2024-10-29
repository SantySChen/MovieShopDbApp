using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.WebMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        public MoviesController(IMovieService movieService, IGenreService genreService)
        {
            _movieService = movieService;
            _genreService = genreService;
        }

        public IActionResult Index()
        {
            ViewData["Genres"] = _genreService.GetAllGenre();
            return View();
        }

        [HttpGet]
        public IActionResult Details()
        {
            ViewData["Genres"] = _genreService.GetAllGenre();
            ViewBag.GenreNames = _movieService.GetGenre(1);
            //ViewBag.Rating = _movieService.GetRate(1);
            var movie = _movieService.GetMovieDetails(1);
            return View(movie);
        }

        [HttpGet]
        public IActionResult Review(int id)
        {
            ViewData["Genres"] = _genreService.GetAllGenre();
            return View();
        }

        [HttpPost]
        public IActionResult Review(Review review)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Buy()
        {
            return View();
        }
    }
}
