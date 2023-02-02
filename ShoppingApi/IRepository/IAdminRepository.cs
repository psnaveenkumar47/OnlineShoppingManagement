using ShoppingApi.Models;

namespace ShoppingApi.IRepository
{
    public interface IAdminRepository
    {
        Task<int> AddAdmin(Admin adminDetails);
    }
}
