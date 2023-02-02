using Microsoft.EntityFrameworkCore;
using ShoppingApi.Models;

namespace ShoppingApi.DataLayer
{
    public class DataAccessLayer:DbContext
    {
        public DataAccessLayer()
        {

        }

        public DataAccessLayer(DbContextOptions<DataAccessLayer> options):base(options)
        {

        }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<OrderDetails> orderdetails { get; set; }
        public DbSet<Product> products { get; set; }
        public virtual DbSet<User> users { get; set; }
      

    }
}
