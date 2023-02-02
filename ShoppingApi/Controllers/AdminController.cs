using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingApi.DataLayer;
using ShoppingApi.IRepository;
using ShoppingApi.Models;

namespace ShoppingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IAdminRepository repository;
        public AdminController(IAdminRepository _repository)
        {
            repository = _repository;

        }
        [HttpPost]
        [Route("AddAdmin")]
        public async Task<IActionResult> AddAdmin([FromBody] Admin admin)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    var Id = await repository.AddAdmin(admin);
                    if (Id > 0)
                    {
                        return Ok(Id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

    }
}
