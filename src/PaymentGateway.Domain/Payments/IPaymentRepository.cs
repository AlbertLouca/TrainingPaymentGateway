using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Domain.Payments
{
    public interface IPaymentRepository
    {
        Task<Payment?> GetPaymentAsync(Guid paymentId,CancellationToken ct = default);
        void AddPayment(Payment payment);
    }
}
