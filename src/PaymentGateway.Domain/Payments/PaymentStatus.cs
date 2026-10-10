namespace PaymentGateway.Domain.Payments
{
    public enum PaymentStatus
    {
        Pending,
        Captured,
        Refunded,
        Failed
    }
}
