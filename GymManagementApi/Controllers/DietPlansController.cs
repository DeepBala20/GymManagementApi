using GymManagementApi.Data;
using GymManagementApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietPlansController : ControllerBase
    {
        private readonly DietPlansRepository _dietPlansRepository;

        public DietPlansController(DietPlansRepository dietPlansRepository)
        {
            _dietPlansRepository = dietPlansRepository;
        }

        [HttpGet]
        public IActionResult GetAllDietPlans() 
        {
            var dietPlans = _dietPlansRepository.GetAllDietPlans();
            return Ok(dietPlans);
        }

        [HttpGet("drp")]
        public IActionResult GetDietPlansDropDown()
        {
            var dietPlansdrp = _dietPlansRepository.GetDropDownDietPlans();
            return Ok(dietPlansdrp);
        }

        [HttpGet("{id}")]
        public IActionResult GetDietPlanByPK(int id)
        {

            var dietPlan = _dietPlansRepository.GetDietPlanByPk(id);
            if (dietPlan == null)
            {
                return NotFound();
            }
            return Ok(dietPlan);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDietPlan(int id)
        {
            var isDeleted = _dietPlansRepository.DeleteDietPlan(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult AddDietPlan([FromBody] DietPlanModel dietPlan)
        {

            if (dietPlan == null)
            {
                return BadRequest();
            }
            bool isInsert = _dietPlansRepository.AddDietPlan(dietPlan);
            if (isInsert)
            {
                return Ok();
            }
            return StatusCode(500, "server error");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBill(int id, [FromBody] DietPlanModel dietPlan)
        {

            if (dietPlan == null || id != dietPlan.DietPlanID)
            {
                return BadRequest();
            }
            bool isUpdate = _dietPlansRepository.UpdateDietPlan(dietPlan);
            if (isUpdate)
            {
                return Ok(dietPlan);
            }
            return StatusCode(500, "server error");
        }
    }
}
