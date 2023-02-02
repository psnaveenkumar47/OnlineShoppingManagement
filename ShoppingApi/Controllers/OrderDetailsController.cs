using Microsoft.AspNetCore.Mvc;

namespace ShoppingApi.Controllers
{
    public class OrderDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
