using GymManagementApi.Data;
using GymManagementApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberShipWiseTrainerController : ControllerBase
    {
            private readonly MemberShipWiseTrainerRepository _memberShipWiseTrainerRepository;

            public MemberShipWiseTrainerController(MemberShipWiseTrainerRepository memberShipWiseTrainerRepository)
            {
                _memberShipWiseTrainerRepository = memberShipWiseTrainerRepository;
            }
            [HttpGet("filter")]
            public IActionResult GetAllMemberShipWiseTrainer([FromQuery] int? id = null)
            {
                var mwt = _memberShipWiseTrainerRepository.GetAllMemberShipWiseTrainer(id);
                return Ok(mwt);
            }

            [HttpGet("{id}")]
            public IActionResult GetMemberShipWiseTrainerByPK(int id)
            {

                var mwt = _memberShipWiseTrainerRepository.GetMemberShipWiseTrainerByPK(id);
                if (mwt == null)
                {
                    return NotFound();
                }
                return Ok(mwt);
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteMemberShipWiseTrainer(int id)
            {
                var isDeleted = _memberShipWiseTrainerRepository.DeleteMemberShipWiseTrainer(id);
                if (!isDeleted)
                {
                    return NotFound();
                }
                return NoContent();
            }

            [HttpPost]
            public IActionResult AddMemberShipWiseTrainer([FromBody] MemberShipWiseTrainerModel mwt)
            {

                if (mwt == null)
                {
                    return BadRequest();
                }
                bool isInsert = _memberShipWiseTrainerRepository.AddMemberShipWiseTrainer(mwt);
                if (isInsert)
                {
                    return Ok();
                }
                return StatusCode(500, "server error");
            }

            [HttpPut("{id}")]
            public IActionResult UpdateMemberShipWiseTrainer(int id, [FromBody] MemberShipWiseTrainerModel mwt)
            {

                if (mwt == null || id != mwt.MemberShipWiseTrainerID)
                {
                    return BadRequest();
                }
                bool isUpdate = _memberShipWiseTrainerRepository.UpdateMemberShipWiseTrainer(mwt);
                if (isUpdate)
                {
                    return Ok(mwt);
                }
                return StatusCode(500, "server error");
            }
        }
    }


