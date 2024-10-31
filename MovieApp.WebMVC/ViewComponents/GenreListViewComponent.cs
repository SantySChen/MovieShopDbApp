using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.WebMVC.ViewComponents
{
    public class GenreListViewComponent : ViewComponent
    {
        private readonly IGenreServiceAsync _genreService;
        public GenreListViewComponent(IGenreServiceAsync genreService)
        {
            _genreService = genreService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var genres = await _genreService.GetAllGenreAsync();
            return View(genres);
        }
    }
}
