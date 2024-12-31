using GymManagementApi.Data;
using GymManagementApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentsController : ControllerBase
    {
        private readonly EquipmentsRepository _equipmentsRepository;

        public EquipmentsController(EquipmentsRepository equipmentsRepository)
        {
            _equipmentsRepository = equipmentsRepository;
        }

        [HttpGet]
        public IActionResult GetAllEquipments() 
        {
            var equipments = _equipmentsRepository.GetAllEquipments();
            return Ok(equipments);
        }

        [HttpGet("{id}")]
        public IActionResult GetEquipmentByPK(int id)
        {

            var equipment = _equipmentsRepository.GetEquipmentByPk(id);
            if (equipment == null)
            {
                return NotFound();
            }
            return Ok(equipment);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEquipment(int id)
        {
            var isDeleted = _equipmentsRepository.DeleteEquipment(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPost]
        public IActionResult AddEquipment([FromBody] EquipmentModel equipment)
        {

            if (equipment == null)
            {
                return BadRequest();
            }
            bool isInsert = _equipmentsRepository.AddEquipment(equipment);
            if (isInsert)
            {
                return Ok();
            }
            return StatusCode(500, "server error");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEquipment(int id, [FromBody] EquipmentModel equipment)
        {

            if (equipment == null || id != equipment.EquipmentID)
            {
                return BadRequest();
            }
            bool isUpdate = _equipmentsRepository.UpdateEquipment(equipment);
            if (isUpdate)
            {
                return Ok(equipment);
            }
            return StatusCode(500, "server error");
        }
    }
}
