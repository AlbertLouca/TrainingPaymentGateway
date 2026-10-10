using PaymentGateway.Domain.Common;

namespace PaymentGateway.Domain.Payments
{
    public class Payment
    {

        public Guid Id { get;private set; }
        public string MerchantId { get;private set; } = null!;
        public decimal Amount { get; private set; }
        public string Currency { get; private set; } = null!;
        public PaymentStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; } 

        private Payment() { }

        public static Payment Create(string merchantId, decimal amount, string currency)
        {
            if (string.IsNullOrWhiteSpace(merchantId))
                throw new DomainException("MerchantId cannot be null or empty.");
            if (amount <= 0)
            {
                throw new DomainException("Amount cannot be zero or negative.");
            }
            if(String.IsNullOrEmpty(currency))
            {
                throw new DomainException("Currency cannot be null or empty.");
            }
            if (currency.Length != 3 || !currency.All(char.IsLetter) )
            {
                throw new DomainException("Currency must be a 3-letter ISO code.");
            }
            return new Payment
            {
                Id = Guid.NewGuid(),
                MerchantId = merchantId,
                Amount = amount,
                Currency = currency.ToUpperInvariant(),
                Status = PaymentStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

        }


        public void Capture()
        {
            if (Status != PaymentStatus.Pending)
            {
                throw new DomainException("Only pending payments can be captured.");
            }
            Status = PaymentStatus.Captured;
        }
        public void Refund()
        {
            if (Status != PaymentStatus.Captured)
            {
                throw new DomainException("Only captured payments can be refunded.");
            }
            Status = PaymentStatus.Refunded;
        }
        public void Fail()
        {
            if (Status != PaymentStatus.Pending)
            {
                throw new DomainException("Only pending payments can be failed.");
            }
            Status = PaymentStatus.Failed;
        }

    }
}
