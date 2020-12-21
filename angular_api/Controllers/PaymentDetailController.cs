using System.Collections.Generic;
using System.Threading.Tasks;
using angular_api.Data.IPaymentRepo;
using angular_models.Tabel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace angular_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : Controller
    {
        private readonly IPaymentRepository context;

        public PaymentDetailController(IPaymentRepository context)
        {
            this.context = context; 
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetails()
        {
            return Ok(await context.GetsPayment());
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PaymentDetail>> GetPaymentDetail(int id)
        {
            var payment = await context.GetPayment(id);
            if(payment == null)
            {
                return NotFound();
            }
            return payment;
        }
        [HttpPost]
        public async Task<ActionResult<PaymentDetail>> PostPaymentDetail(PaymentDetail payment)
        {
            var result = await context.PostPayment(payment);
            return result;
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<PaymentDetail>> PutPaymentDetail(int id, PaymentDetail payment)
        {
            if(id != payment.PaymentDetailId)
            {
                return BadRequest();
            }
            var result = await context.UpdatePayment(payment);
            return result;
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PaymentDetail>> DeletePaymentDetail(int id)
        {
            var result = await context.GetPayment(id);
            if(result == null)
            {
                return NotFound();
            }
            await context.Deletepayment(result.PaymentDetailId);
            return NoContent();
        }
    }
}