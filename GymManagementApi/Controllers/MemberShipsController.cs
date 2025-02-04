using GymManagementApi.Data;
using GymManagementApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //[Authorize]
    public class MemberShipsController : ControllerBase
    {
        private readonly MemberShipsRepository _memberShipsRepository;

        public MemberShipsController(MemberShipsRepository memberShipsRepository)
        {
            _memberShipsRepository = memberShipsRepository;
        }

        [HttpGet]
        public IActionResult GetAllMemberShips()
        {
            var memberShips = _memberShipsRepository.GetAllMemberShips();
            return Ok(memberShips);
        }

        [HttpGet("drp")]
        public IActionResult GetMemberShipsDropDown()
        {
            var memberShipsdrp = _memberShipsRepository.GetMemberShipsDropDown();
            return Ok(memberShipsdrp);
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetMemberShipByPK(int id)
        {

            var memberShip = _memberShipsRepository.GetMemberShipByPk(id);
            if (memberShip == null)
            {
                return NotFound();
            }
            return Ok(memberShip);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteMemberShip(int id)
        {
            var isDeleted = _memberShipsRepository.DeleteMemberShip(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddMemberShip([FromBody] MemberShipModel memberShip)
        {

            if (memberShip == null)
            {
                return BadRequest();
            }
            bool isInsert = _memberShipsRepository.AddMemberShip(memberShip);
            if (isInsert)
            {
                return Ok();
            }
            return StatusCode(500, "server error");
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateMemberShip(int id, [FromBody] MemberShipModel memberShip)
        {

            if (memberShip == null || id != memberShip.MemberShipID)
            {
                return BadRequest();
            }
            bool isUpdate = _memberShipsRepository.UpdateMemberShip(memberShip);
            if (isUpdate)
            {
                return Ok(memberShip);
            }
            return StatusCode(500, "server error");
        }
    }
}
