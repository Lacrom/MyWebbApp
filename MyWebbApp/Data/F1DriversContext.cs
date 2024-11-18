using Microsoft.EntityFrameworkCore;
using MyWebbApp.Models;

namespace MyWebbApp.Data
{
    public class F1DriversContext : DbContext
    {
        public F1DriversContext(DbContextOptions<F1DriversContext> options)
        : base(options)
        {
        }
        public DbSet<MyWebbApp.Models.Drivers_Model>? Drivers { get; set; }
        
    }
}
