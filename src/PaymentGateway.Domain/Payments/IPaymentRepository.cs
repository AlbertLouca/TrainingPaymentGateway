
namespace PaymentGateway.Domain.Payments
{
    public interface IPaymentRepository
    {
        Task<Payment?> GetPaymentAsync(Guid paymentId,CancellationToken ct = default);
        void AddPayment(Payment payment);
    }
}
