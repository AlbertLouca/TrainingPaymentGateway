namespace PaymentGateway.Domain.Providers;

public interface IPaymentProvider
{
    string Name { get; }
    Task<ProviderResult> ChargeAsync(ProviderChargeRequest request, CancellationToken ct = default);
}