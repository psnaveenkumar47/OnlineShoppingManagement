using ShoppingApi.Models;
using System.Threading.Tasks;

namespace ShoppingApi.IRepository
{
    public interface IUserRepository
    {
        
        Task<int> AddUser(User User);
        Task<List<User>> GetAll();

        Task UpdateUser(User User);
        Task<int> DeleteUser(int? id);
        Task<User> GetUser(int? id);
    }

}
