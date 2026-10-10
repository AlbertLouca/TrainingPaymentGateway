using Microsoft.EntityFrameworkCore;
using PaymentGateway.Domain.Payments;
using PaymentGateway.Infrastructure.Persistence;


namespace PaymentGateway.Infrastructure.Repositories
{
    internal class PaymentRepository : IPaymentRepository
    {
        private PaymentDbContext _context;
        public PaymentRepository(PaymentDbContext context) {
            _context = context;
        }
       public Task<Payment?> GetPaymentAsync(Guid paymentId, CancellationToken ct = default)
        {
         Task<Payment?> extractedPayment=   _context.Set<Payment>().FirstOrDefaultAsync(p => p.Id == paymentId, ct);
         return extractedPayment;
        }
      public  void AddPayment(Payment payment)
        {
            _context.Add(payment);
        }

    }
}
