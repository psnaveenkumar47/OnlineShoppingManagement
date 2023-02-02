using Microsoft.AspNetCore.Mvc;
using ShoppingMVC.Models;
using System.Diagnostics;
using ShoppingMVC.ClientAddress;
using ShoppingMVC.Models;
using Newtonsoft.Json;

namespace ShoppingMVC.Controllers
{
    public class ProductController : Controller
    {
        HttpAddress api = new HttpAddress();
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductData> products = new List<ProductData>();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("api/product");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<ProductData>>(result);
            }
            return View(products);
        }
        public async Task<IActionResult> Details(int id)
        {
            var product = new ProductData();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync($"api/product/{id}");
            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<ProductData>(results);
            }
            return View(product);
        }

        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(ProductData product)
        {
            HttpClient client = api.Initial();
            var postTask = client.PostAsJsonAsync<ProductData>("api/product", product);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var product = new ProductData();
            HttpClient client = api.Initial();
            HttpResponseMessage reponse = await client.DeleteAsync($"api/product/{id}");
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
