namespace PaymentGateway.Domain.Providers;

public record ProviderChargeRequest(Guid PaymentId,decimal Amount,string Currency);
