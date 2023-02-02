using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ShoppingApi.IRepository;
using ShoppingApi.Models;
using System.Data.SqlClient;

namespace ShoppingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //  public readonly IConfiguration _configuration;
        IUserRepository repository;
        public UserController(IUserRepository _repository)
        {
            repository = _repository;

        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var userr = await repository.GetAll();
                if (userr == null)
                {
                    return NotFound();
                }

                return Ok(userr);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    var userId = await repository.AddUser(user);
                    if (userId > 0)
                    {
                        return Ok(userId);
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

        [HttpGet]
        [Route("GetUser/{userid}")]
        public async Task<IActionResult> GetUser(int? userid)
        {
            if (userid == null)
            {
                return BadRequest();
            }
            try
            {
                var users = await repository.GetUser(userid);
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteUser/{userid}")]
        public async Task<IActionResult> DeleteUser(int? userid)
        {
            int result = 0;
            if (userid == null)
            {
                return BadRequest();
            }
            try
            {

                result = await repository.DeleteUser(userid);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}