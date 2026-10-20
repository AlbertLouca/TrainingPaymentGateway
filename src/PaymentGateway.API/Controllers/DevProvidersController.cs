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
        public async Task<IActionResult> Charge(ProviderChargeRequest request,CancellationToken ct)
        {
            ProviderResult result = await _paymentProvider.ChargeAsync(request,ct);
            return Ok(result);
        }
    }
}
