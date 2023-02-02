using Microsoft.EntityFrameworkCore;
using ShoppingApi.DataLayer;
using ShoppingApi.IRepository;
using ShoppingApi.Models;

namespace ShoppingApi.Repository
{
    public class AdminRepository:IAdminRepository
    {
        DataAccessLayer Dal;
        public async Task<int> AddAdmin(Admin admin)
        {
            if (Dal != null)
            {
                await Dal.admins.AddAsync(admin);
                await Dal.SaveChangesAsync();
                return admin.AdminID;
            }
            return 0;
        }
    }
}
