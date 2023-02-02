using Microsoft.AspNetCore.Mvc;
using ShoppingMVC.Models;
using System.Diagnostics;
using ShoppingMVC.ClientAddress;
using ShoppingMVC.Models;
using Newtonsoft.Json;

namespace ShoppingMVC.Controllers
{
    public class UserController : Controller
    {
        HttpAddress api = new HttpAddress();
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        List<UserData> users = new List<UserData>();
        HttpClient client = api.Initial();
        HttpResponseMessage response = await client.GetAsync("api/user");
        if (response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadAsStringAsync().Result;
            users = JsonConvert.DeserializeObject<List<UserData>>(result);
        }
        return View(users);
    }
       
        public async Task<IActionResult> Details(int id)
    {
        var user = new UserData();
        HttpClient client = api.Initial();
        HttpResponseMessage response = await client.GetAsync($"api/user/{id}");
        if (response.IsSuccessStatusCode)
        {
            var results = response.Content.ReadAsStringAsync().Result;
            user = JsonConvert.DeserializeObject<UserData>(results);
        }
        return View(user);
    }
        public ActionResult UserOperations()
        {
            return View();
        }
        public ActionResult create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult create(UserData user)
    {
        HttpClient client = api.Initial();
        var postTask = client.PostAsJsonAsync<UserData>("api/user", user);
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
        var user = new AdminData();
        HttpClient client = api.Initial();
        HttpResponseMessage reponse = await client.DeleteAsync($"api/user/{id}");
        return RedirectToAction("Index");
    }
        public IActionResult UserLogin(string username, string password)
        {
            return View();
        }
            /*
            [HttpGet]
            public IActionResult UserLogin(string username,string password)
            {

                var optionsBuilder = new DataAccessLayer<UserData>();
                optionsBuilder.UseSqlServer("Data Source=PRSQL;Initial Catalog=OnlineShopping;User ID=labuser;Password=Welcome123$; TrustServerCertificate=True");
                db = new UserData(optionsBuilder.Options);
                DataAccessLayer dl = new DataAccessLayer();
                username = Request.Form["txtusername"];
                password = Request.Form["txtpassword"];
                var role = (from x in    where (x.UserName == username && x.Password == password) select x.UserID).SingleOrDefault();
                if (role != null)
                {
                    return View(role);
                }
                else
                     ModelState.AddModelError("", "Invalid username");
                return View();
            }
            /*
            [HttpPost]
            public string GetUserByFname(string searchString)
            {
                var user = new AdminData();
                HttpClient client = api.Initial();
                HttpResponseMessage reponse = await client.GetStringAsync($"api/user/{searchString}");
                return "From [HttpPost]Index: filter on " + searchString;
            }



            public ActionResult GetUserByFname(string search)
            {
                IEnumerable<UserData> obj = null;
                HttpClient client = api.Initial();
                var consumeapi = client.GetAsync("");
                return View();
            }

            */





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
