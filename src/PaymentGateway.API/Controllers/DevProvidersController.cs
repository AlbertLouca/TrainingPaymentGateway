using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Domain.Providers;

namespace PaymentGateway.API.Controllers
{


    [ApiController]
    [Route("dev/providers")]
    public class DevProvidersController : ControllerBase
    {
        private readonly IPaymentProvider _paymentProvider;

        //TODO;

        public DevProvidersController(IPaymentProvider paymentProvider)
        {
            _paymentProvider = paymentProvider;
        }

        [HttpPost("charge")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Charge(ProviderChargeRequest request)
        {
            ProviderResult result = _paymentProvider.ChargeAsync(request).Result;
            return Ok(result);
        }
    }
}
