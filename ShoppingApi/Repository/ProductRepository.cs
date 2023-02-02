
using Microsoft.EntityFrameworkCore;
using ShoppingApi.DataLayer;
using ShoppingApi.IRepository;
using ShoppingApi.Models;
namespace ShoppingApi.Repository
{
    public class ProductRepository :IProductRepository
    {
        DataAccessLayer DAL;
        //private int _nextId = 1;
        public ProductRepository(DataAccessLayer _DAL)
        {
            DAL = _DAL;
        }
        public async Task<List<Product>> GetAll()
        {
            if (DAL != null)
            {
                return await DAL.products.ToListAsync();
            }
            return null;
        }
        public async Task<int> AddProduct(Product prod)
        {
            if (DAL != null)
            {
                await DAL.products.AddAsync(prod);
                await DAL.SaveChangesAsync();
                return prod.ProductID;
            }
            return 0;
        }
        public async Task<Product> GetProduct(int? prodid)
        {
            if (DAL != null)
            {
                return await (from u in DAL.products where u.ProductID == prodid select u).FirstOrDefaultAsync();


            }
            return null;
        }
        public async Task<int> DeleteProduct(int? proid)
        {
            int result = 0;
            if (DAL != null)
            {
                var prod = await DAL.products.FirstOrDefaultAsync(x => x.ProductID == proid);
                if (proid != null)
                {
                    Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Product> entityEntry = DAL.products.Remove(prod);
                    result = await DAL.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

       
    }
}
