using Microsoft.AspNetCore.Mvc;

namespace MovieLand.web.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
