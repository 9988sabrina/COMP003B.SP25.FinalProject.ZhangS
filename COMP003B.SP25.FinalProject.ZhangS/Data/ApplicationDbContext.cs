using Microsoft.EntityFrameworkCore;
using COMP003B.SP25.FinalProject.ZhangS.Models;

namespace COMP003B.SP25.FinalProject.ZhangS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car>? Cars { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Mechanic>? Mechanics { get; set; }
        public DbSet<ServiceType>? ServiceTypes { get; set; }
        public DbSet<ServiceBooking>? ServiceBookings { get; set; }
    }
}
