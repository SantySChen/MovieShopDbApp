using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MovieApp.WebMVC.Models;
using System.Diagnostics;

namespace MovieApp.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IMovieServiceAsync _movieServiceAsync;

        public HomeController(IMovieService movieService, IMovieServiceAsync movieServiceAsync)
        {
            _movieService = movieService;
            _movieServiceAsync = movieServiceAsync;
        }
    
        public async Task<IActionResult> Index()
        {
            var result = await _movieServiceAsync.GetTopMoviesAsync(24);
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
