using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApi.DataLayer;

namespace ShoppingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private DataAccessLayer dal;
        public SearchController(DataAccessLayer dal)
        {
            this.dal = dal;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
           
            var result = dal.users.Where(x => x.FirstName.StartsWith(searchString) || searchString == null).ToList();

            return Ok(result);
        }
    }
}
