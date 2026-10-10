namespace PaymentGateway.API.Contracts
{
    public record CreatePaymentRequest(string MerchantId, decimal Amount, string Currency);
}
