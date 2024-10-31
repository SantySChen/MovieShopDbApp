using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.WebMVC.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastService _castService;
        private readonly ICastServiceAsync _castServiceAsync;

        public CastController(ICastService castService, ICastServiceAsync castServiceAsync)
        {
            _castService = castService;
            _castServiceAsync = castServiceAsync;
        }

        
        public async Task<IActionResult> Details(int id)
        {
            var CastDetails = await _castServiceAsync.GetByIdAsync(id);
            return View(CastDetails);
        }
    }
}
