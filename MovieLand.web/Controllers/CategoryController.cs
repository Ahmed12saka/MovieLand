using Microsoft.AspNetCore.Mvc;

namespace MovieLand.web.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
