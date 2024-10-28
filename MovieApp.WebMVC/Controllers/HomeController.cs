using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using MovieApp.WebMVC.Models;
using System.Diagnostics;

namespace MovieApp.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;

        public HomeController(IMovieService movieService, IGenreService genreService)
        {
            _movieService = movieService;
            _genreService = genreService;
        }

        public IActionResult Index()
        {
            var result = new MovieGenreViewModel
            {
                Movies = _movieService.GetTopMovies(24),
                Genres = _genreService.GetAllGenre()
            };
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
