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
    public class JoiningReasonsController : ControllerBase
    {
        private readonly JoiningReasonsRepository _joiningRepository;
        
        public JoiningReasonsController(JoiningReasonsRepository joiningReasonsRepository)
        {
            _joiningRepository = joiningReasonsRepository;
        }

        [HttpGet]
        public IActionResult GetAllJoiningReasons() 
        {
            var joiningReasons = _joiningRepository.GetAllJoiningReasons();
            return Ok(joiningReasons);
        }
        [HttpGet("drp")]
        public IActionResult GetJoiningReasonsDropDown()
        {
            var joiningReasonsdrp = _joiningRepository.GetJoiningReasonsDropDown();
            return Ok(joiningReasonsdrp);
        }

        [HttpGet("{id}")]
        public IActionResult GetJoiningReasonByPK(int id)
        {

            var joiningReason = _joiningRepository.GetJoiningReasonByPk(id);
            if (joiningReason == null)
            {
                return NotFound();
            }
            return Ok(joiningReason);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteJoiningReason(int id)
        {
            var isDeleted = _joiningRepository.DeleteJoiningReason(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPost]
        public IActionResult AddJoiningReason([FromBody] JoiningReasonModel joiningReason)
        {

            if (joiningReason == null)
            {
                return BadRequest();
            }
            bool isInsert = _joiningRepository.AddJoinigReason(joiningReason);
            if (isInsert)
            {
                return Ok();
            }
            return StatusCode(500, "server error");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateJoiningReason(int id, [FromBody] JoiningReasonModel joiningReason)
        {

            if (joiningReason == null || id != joiningReason.JoiningReasonID)
            {
                return BadRequest();
            }
            bool isUpdate = _joiningRepository.UpdateJoinigReason(joiningReason);
            if (isUpdate)
            {
                return Ok(joiningReason);
            }
            return StatusCode(500, "server error");
        }
    }
}
