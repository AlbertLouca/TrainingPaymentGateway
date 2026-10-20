using PaymentGateway.Domain.Providers;
namespace PaymentGateway.Infrastructure.Providers.NileTelco;


internal class NileTelcoProvider : IPaymentProvider
{

    public string Name => "NileTelco";

    public async Task<ProviderResult> ChargeAsync(ProviderChargeRequest request, CancellationToken ct = default)
    {
        await Task.Delay(300, ct);
        if(request.Amount % 1 == 0.13m)
        {
            return ProviderResult.Failed("Insufficient balance");
        }

        return ProviderResult.Succeeded("NT-" + Guid.NewGuid().ToString("N")[..10]);
    }
}
