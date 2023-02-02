using ShoppingApi.Models;
namespace ShoppingApi.IRepository
{
    public interface IProductRepository
    {
        Task<int> AddProduct(Product prod);
        Task<List<Product>> GetAll();

        
        Task<int> DeleteProduct(int? id);
        Task<Product> GetProduct(int? id);
    }
}
