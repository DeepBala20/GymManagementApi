using GymManagementApi.Data;
using GymManagementApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentsRepository _paymentsRepository;

        public PaymentsController(PaymentsRepository paymentsRepository)
        {
            _paymentsRepository = paymentsRepository;
        }

        [HttpGet]
        public IActionResult GetAllPayments()
        {
            var payments = _paymentsRepository.GetAllPayments();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public IActionResult GetPaymentByPK(int id)
        {

            var payment = _paymentsRepository.GetPaymentByPk(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePayment(int id)
        {
            var isDeleted = _paymentsRepository.DeletePayment(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPost]
        public IActionResult AddPayment([FromBody] PaymentModel payment)
        {

            if (payment == null)
            {
                return BadRequest();
            }
            bool isInsert = _paymentsRepository.AddPayment(payment);
            if (isInsert)
            {
                return Ok();
            }
            return StatusCode(500, "server error");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMemberShip(int id, [FromBody] PaymentModel payment)
        {

            if (payment == null || id != payment.PaymentID)
            {
                return BadRequest();
            }
            bool isUpdate = _paymentsRepository.UpdatePayment(payment);
            if (isUpdate)
            {
                return Ok(payment);
            }
            return StatusCode(500, "server error");
        }
    }
}
