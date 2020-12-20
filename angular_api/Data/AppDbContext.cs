using angular_models.Tabel;
using Microsoft.EntityFrameworkCore;

namespace angular_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        
        
    }
}