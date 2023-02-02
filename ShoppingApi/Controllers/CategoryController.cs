using Microsoft.AspNetCore.Mvc;

namespace ShoppingApi.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
