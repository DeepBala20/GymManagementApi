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
    public class MembersController : ControllerBase
    {
        private readonly MembersRepository _membersRepository;

        public MembersController(MembersRepository membersRepository)
        {
            _membersRepository = membersRepository;
        }

        [HttpGet]
        public IActionResult GetAllMembers()
        {
            var members = _membersRepository.GetAllMembers();
            return Ok(members);
        }

        [HttpGet("drp")]
        public IActionResult GetMembersDropDown()
        {
            var membersdrp = _membersRepository.GetMembersDropDown();
            return Ok(membersdrp);
        }

        [HttpGet("{id}")]
        public IActionResult GetMemberByPK(int id)
        {

            var member = _membersRepository.GetMeberByPk(id);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMember(int id)
        {
            var isDeleted = _membersRepository.DeleteMember(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult AddMember([FromBody] MemberModel member)
        {

            if (member == null)
            {
                return BadRequest();
            }
            bool isInsert = _membersRepository.AddMember(member);
            if (isInsert)
            {
                return Ok();
            }
            return StatusCode(500, "server error");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMember(int id, [FromBody] MemberModel member)
        {

            if (member == null || id != member.MemberID)
            {
                return BadRequest();
            }
            bool isUpdate = _membersRepository.UpdateMember(member);
            if (isUpdate)
            {
                return Ok(member);
            }
            return StatusCode(500, "server error");
        }
    }
}
