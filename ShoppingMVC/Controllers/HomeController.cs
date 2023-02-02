using Microsoft.AspNetCore.Mvc;
using ShoppingMVC.Models;
using System.Diagnostics;
using ShoppingMVC.ClientAddress;
using ShoppingMVC.Models;
using Newtonsoft.Json;

namespace ShoppingMVC.Controllers
{
    
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return Redirect("/Product");
        }


        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult LoginOption()
        {
            return View();
        }
        public IActionResult CreateOption()
        {
            return View();
        }
        public IActionResult Success()
        {
            return View();
        }
        
        public IActionResult AdminLogin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}