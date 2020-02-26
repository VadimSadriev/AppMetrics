using AppMetrics.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppMetrics.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
