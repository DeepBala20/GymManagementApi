using GymManagementApi.Data;
using GymManagementApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {

        
            private readonly RequestRepository _requestRepository;

            public  RequestController(RequestRepository requestRepository)
            {
                _requestRepository = requestRepository;
            }
            [HttpGet]
            public IActionResult GetAllRequest()
            {
                var requests = _requestRepository.GetAllRequest();
                return Ok(requests);
            }

            [HttpGet("{id}")]
            public IActionResult GetRequestByPK(int id)
            {

                var request = _requestRepository.GetRequestByPK(id);
                if (request == null)
                {
                    return NotFound();
                }
                return Ok(request);
            }

        [HttpGet("member/{id}")]
        public IActionResult GetRequestByMember(int id)
        {

            var request = _requestRepository.GetAllRequestByMember(id);
            if (request == null)
            {
                return NotFound();
            }
            return Ok(request);
        }

        [HttpGet("trainer/{id}")]
        public IActionResult GetRequestByTrainer(int id)
        {

            var request = _requestRepository.GetAllRequestByTrainer(id);
            if (request == null)
            {
                return NotFound();
            }
            return Ok(request);
        }

        [HttpDelete("{id}")]
            public IActionResult DeleteRequest(int id)
            {
                var isDeleted = _requestRepository.DeleteRequest(id);
                if (!isDeleted)
                {
                    return NotFound();
                }
                return NoContent();
            }

            [HttpPost]
            public IActionResult AddRequest([FromBody] RequestModel request)
            {

                if (request == null)
                {
                    return BadRequest();
                }
                bool isInsert = _requestRepository.AddRequest(request);
                if (isInsert)
                {
                    return Ok();
                }
                return StatusCode(500, "server error");
            }

            [HttpPut("{id}")]
            public IActionResult UpdateRequest(int id, [FromBody] RequestModel request)
            {

                if (request == null || id != request.RequestID)
                {
                    return BadRequest();
                }
                bool isUpdate = _requestRepository.UpdateRequest(request);
                if (isUpdate)
                {
                    return Ok(request);
                }
                return StatusCode(500, "server error");
            }
        [HttpPut("status/{id}")]
        public IActionResult UpdateRequestStatus(int id, [FromBody] RequestModel request)
        {

            if (request == null || id != request.RequestID)
            {
                return BadRequest();
            }
            bool isUpdate = _requestRepository.UpdateRequestStatus(request);
            if (isUpdate)
            {
                return Ok(request);
            }
            return StatusCode(500, "server error");
        }
    }
    }




