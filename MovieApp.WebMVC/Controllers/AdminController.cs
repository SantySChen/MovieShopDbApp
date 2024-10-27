using Microsoft.AspNetCore.Mvc;

namespace MovieApp.WebMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
