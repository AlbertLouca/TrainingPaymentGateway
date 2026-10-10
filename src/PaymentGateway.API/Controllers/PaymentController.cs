using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.API.Contracts;
using PaymentGateway.Domain.Common;
using PaymentGateway.Domain.Payments;

namespace PaymentGateway.API.Controllers
{
    [ApiController]
    [Route("Payments")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PaymentController(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork)
        {
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<IActionResult> Create( CreatePaymentRequest request, CancellationToken ct)
        {
            Payment payment;

            try
            {
                payment=Payment.Create(request.MerchantId, request.Amount, request.Currency);
            }
            catch (DomainException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            _paymentRepository.AddPayment(payment);
            await _unitOfWork.SaveChangesAsync(ct);

            return CreatedAtAction(nameof(GetById), new { id = payment.Id }, PaymentResponse.FromDomain(payment));
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
        {
            var payment = await _paymentRepository.GetPaymentAsync(id, ct);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(PaymentResponse.FromDomain(payment));
        }
        [HttpPost("{id:guid}/capture")]
        public async Task<IActionResult> Capture(Guid id, CancellationToken ct)
        {
            var payment = await _paymentRepository.GetPaymentAsync(id, ct);
            if (payment == null)
            {
                return NotFound();
            }
            try
            {
                payment.Capture();
            }
            catch (DomainException ex)
            {
                return Conflict(new { error = ex.Message });
            }
            await _unitOfWork.SaveChangesAsync(ct);
            return Ok(PaymentResponse.FromDomain(payment));
        }
        [HttpPost("{id:guid}/refund")]
        public async Task<IActionResult> Refund(Guid id, CancellationToken ct)
        {
            var payment = await _paymentRepository.GetPaymentAsync(id, ct);
            if (payment == null)
            {
                return NotFound();
            }
            try
            {
                payment.Refund();
            }
            catch (DomainException ex)
            {
                return Conflict(new { error = ex.Message });
            }
            await _unitOfWork.SaveChangesAsync(ct);
            return Ok(PaymentResponse.FromDomain(payment));
        }
    }
}
