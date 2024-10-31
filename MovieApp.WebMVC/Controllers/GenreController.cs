using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.WebMVC.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IGenreServiceAsync _genreServiceAsync;
        public GenreController(IGenreService genreService, IGenreServiceAsync genreServiceAsync)
        {
            _genreService = genreService;
            _genreServiceAsync = genreServiceAsync;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _genreServiceAsync.GetAllGenreAsync();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Genre genre)
        {
            if(ModelState.IsValid)
            {
                await _genreServiceAsync.AddGenreAsync(genre);
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _genreServiceAsync.GetGerneByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Genre genre)
        {
            if(ModelState.IsValid)
            {
                await _genreServiceAsync.UpdateGenreAsync(genre, genre.Id);
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _genreServiceAsync.DeleteGenreAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Genre genre)
        {
            await _genreServiceAsync.DeleteGenreAsync(genre.Id);
            return RedirectToAction("Index");
        }   

        
    }
}
