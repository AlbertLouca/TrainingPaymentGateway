namespace PaymentGateway.Domain.Providers;

public record ProviderResult(bool IsSuccess, string? ProviderReference, string? FailureReason)
{

    public static ProviderResult Succeeded(string reference) => new(true, reference, null);
    public static ProviderResult Failed(string reason) => new(false, null, reason);
}