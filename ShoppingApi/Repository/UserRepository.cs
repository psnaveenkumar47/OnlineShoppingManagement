
using Microsoft.EntityFrameworkCore;
using ShoppingApi.DataLayer;
using ShoppingApi.IRepository;
using ShoppingApi.Models;

namespace ShoppingApi.Repository
{
    public class UserRepository : IUserRepository
    {
        DataAccessLayer DAL;
        //private int _nextId = 1;
        public UserRepository(DataAccessLayer _DAL)
        {
            DAL = _DAL;
        }
        public async Task<List<User>> GetAll()
        {
            if (DAL != null)
            {
                return await DAL.users.ToListAsync();
            }
            return null;
        }
        public async Task<int> AddUser(User user)
        {
            if (DAL != null)
            {
                await DAL.users.AddAsync(user);
                await DAL.SaveChangesAsync();
                return user.UserID;
            }
            return 0;
        }
        public async Task<User> GetUser(int? userid)
        {
            if (DAL != null)
            {
                return await (from u in DAL.users where u.UserID == userid select u).FirstOrDefaultAsync();


            }
            return null;
        }
        public async Task<int> DeleteUser(int? userid)
        {
            int result = 0;
            if (DAL != null)
            {
                var user = await DAL.users.FirstOrDefaultAsync(x => x.UserID == userid);
                if (userid != null)
                {
                    DAL.users.Remove(user);
                    result = await DAL.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }
        public async Task UpdateUser(User user)
        {
            if (DAL != null)
            {
                DAL.users.Update(user);
                await DAL.SaveChangesAsync();
            }
        }

      
        
    }
       
}
