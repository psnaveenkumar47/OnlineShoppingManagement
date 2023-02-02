using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ShoppingApi.IRepository;
using ShoppingApi.Models;
using System.Data.SqlClient;

namespace ShoppingApi.Controllers
{
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        IProductRepository repository;
        public ProductController(IProductRepository _rep)
        {
            repository = _rep;
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
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Product prod)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    var prodd = await repository.AddProduct(prod);
                    if (prodd > 0)
                    {
                        return Ok(prodd);
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
        [Route("GetProduct/{productid}")]
        public async Task<IActionResult> GetProduct(int? prodid)
        {
            if (prodid == null)
            {
                return BadRequest();
            }
            try
            {
                var prods = await repository.GetProduct(prodid);
                if (prods == null)
                {
                    return NotFound();
                }
                return Ok(prods);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteProduct/{productid}")]
        public async Task<IActionResult> DeleteProduct(int? prodid)
        {
            int result = 0;
            if (prodid == null)
            {
                return BadRequest();
            }
            try
            {

                result = await repository.DeleteProduct(prodid);
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
