using Microsoft.AspNetCore.Mvc;

namespace MovieApp.WebMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
