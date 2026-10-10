using PaymentGateway.Domain.Payments;

namespace PaymentGateway.API.Contracts
{
    public record PaymentResponse(Guid Id,string MerchantId, decimal Amount, string Currency,string Status,DateTime CreatedAt)
    {

        public static PaymentResponse FromDomain(Payment payment) => new(

                payment.Id,
                payment.MerchantId,
                payment.Amount,
                payment.Currency,
                payment.Status.ToString(),
                payment.CreatedAt
            );
    }


}
