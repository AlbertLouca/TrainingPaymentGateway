namespace PaymentGateway.Domain.Providers;

public record ProviderResult
{

    bool IsSuccess;
    string? ProviderReference;
    string? FailureReason;


    public static ProviderResult Succeeded(string reference) => new()
    {
        IsSuccess = true,
        ProviderReference = reference,
        FailureReason = null
    };

    public static ProviderResult Failed(string reason) => new()
    {
        IsSuccess = false,
        ProviderReference = null,
        FailureReason = reason
    };
}