using Microsoft.AspNetCore.Mvc;
using ShoppingMVC.Models;
using System.Diagnostics;
using ShoppingMVC.ClientAddress;
using ShoppingMVC.Models;
using Newtonsoft.Json;

namespace ShoppingMVC.Controllers
{
    public class AdminController : Controller
    {
        HttpAddress api = new HttpAddress();
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<AdminData> admins = new List<AdminData>();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("api/admin");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                admins = JsonConvert.DeserializeObject<List<AdminData>>(result);
            }
            return View(admins);
        }
        public async Task<IActionResult> adminoptions()
        {
            return View();
        }
        public async Task<IActionResult> adminoperations()
        {
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            var admin = new AdminData();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync($"api/admin/{id}");
            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                admin = JsonConvert.DeserializeObject<AdminData>(results);
            }
            return View(admin);
        }

        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(AdminData admin)
        {
            HttpClient client = api.Initial();
            var postTask = client.PostAsJsonAsync<AdminData>("api/admin", admin);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var admin = new AdminData();
            HttpClient client = api.Initial();
            HttpResponseMessage reponse = await client.DeleteAsync($"api/admin/{id}");
            return RedirectToAction("Index");
        }








        public IActionResult Privacy()
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