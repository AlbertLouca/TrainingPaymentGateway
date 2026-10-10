using PaymentGateway.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Domain.Payments
{
    public class Payment
    {

        public Guid Id { get;private set; }
        public string MerchantId { get;private set; }
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }
        public PaymentStatus Status { get; private set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;

        private Payment() { }

        public static Payment Create(string merchantId, decimal amount, string currency)
        {
            if (string.IsNullOrWhiteSpace(merchantId))
                throw new DomainException("MerchantId cannot be null or empty.");
            if (amount < 0)
            {
                throw new DomainException("Amount cannot be negative.");
            }
            if (currency.Length != 3)
            {
                throw new DomainException("Currency must be a 3-letter ISO code.");
            }
            return new Payment
            {
                Id = Guid.NewGuid(),
                MerchantId = merchantId,
                Amount = amount,
                Currency = currency.ToUpper(),
                Status = PaymentStatus.Pending
            };

        }


        public bool Capture()
        {
            if (Status != PaymentStatus.Pending)
            {
                throw new DomainException("Only pending payments can be captured.");
            }
            Status = PaymentStatus.Captured;
            return true;
        }
        public bool Refund()
        {
            if (Status != PaymentStatus.Captured)
            {
                throw new DomainException("Only captured payments can be refunded.");
            }
            Status = PaymentStatus.Refunded;
            return true;
        }
        public bool Fail()
        {
            if (Status != PaymentStatus.Pending)
            {
                throw new DomainException("Only pending payments can be failed.");
            }
            Status = PaymentStatus.Failed;
            return true;
        }

    }
}
