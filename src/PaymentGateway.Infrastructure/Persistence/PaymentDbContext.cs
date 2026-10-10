using Microsoft.EntityFrameworkCore;
using PaymentGateway.Domain.Payments;

namespace PaymentGateway.Infrastructure.Persistence
{
    public class PaymentDbContext(DbContextOptions<PaymentDbContext> options) : DbContext(options)
    {
        public DbSet<Payment> Payments => Set<Payment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PaymentDbContext).Assembly);    
        }
    }
}
