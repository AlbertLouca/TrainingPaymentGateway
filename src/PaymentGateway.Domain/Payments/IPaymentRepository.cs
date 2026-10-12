
namespace PaymentGateway.Domain.Payments
{
    public interface IPaymentRepository
    {
        Task<Payment?> GetByIdAsync(Guid paymentId,CancellationToken ct = default);
        Task<Payment?> GetByIdForReadAsync(Guid paymentId, CancellationToken ct = default);
        void AddPayment(Payment payment);
    }
}
