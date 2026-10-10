using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
