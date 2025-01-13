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
    public class TrainersController : ControllerBase
    {
        private readonly TrainersRepository _trainersRepository;

        public TrainersController(TrainersRepository trainersRepository)
        {
            _trainersRepository = trainersRepository;
        }
        [HttpGet]
        public IActionResult GetAllTrainers()
        {
            var trainers = _trainersRepository.GetAllTrainers();
            return Ok(trainers);
        }
        [HttpGet("drp")]
        public IActionResult GetTrainersDropDown()
        {
            var trainersdrp = _trainersRepository.GetTrainersDropDown();
            return Ok(trainersdrp);
        }

        [HttpGet("{id}")]
        public IActionResult GetTrainerByPK(int id)
        {

            var trainer = _trainersRepository.GetTrainerByPK(id);
            if (trainer == null)
            {
                return NotFound();
            }
            return Ok(trainer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTrainer(int id)
        {
            var isDeleted = _trainersRepository.DeleteTrainer(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult AddTrainer([FromBody] TrainerModel trainer)
        {

            if (trainer == null)
            {
                return BadRequest();
            }
            bool isInsert = _trainersRepository.AddTrainer(trainer);
            if (isInsert)
            {
                return Ok();
            }
            return StatusCode(500, "server error");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTrainer(int id, [FromBody] TrainerModel trainer)
        {

            if (trainer == null || id != trainer.TrainerID)
            {
                return BadRequest();
            }
            bool isUpdate = _trainersRepository.UpdateTrainer(trainer);
            if (isUpdate)
            {
                return Ok(trainer);
            }
            return StatusCode(500, "server error");
        }
    }
}
