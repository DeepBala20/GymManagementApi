using GymManagementApi.Data;
using GymManagementApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly AttendanceRepository _attendanceRepository;

        public AttendanceController(AttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        [HttpGet("report")]
        public IActionResult AttendanceReport()
        {
            var report = _attendanceRepository.AttendanceReport();
            return Ok(report);
        }
        [HttpGet("report/{id}")]
        public IActionResult AttendanceReport(int id)
        {
            var report = _attendanceRepository.AttendanceReportByPK(id);
            return Ok(report);
        }
        [HttpGet("membersreport")]
        public IActionResult MembersAttendanceReport()
        {
            var report = _attendanceRepository.MembersAttendanceReport();
            return Ok(report);
        }
        [HttpGet("trainersreport")]
        public IActionResult TrainersAttendanceReport()
        {
            var report = _attendanceRepository.TrainersAttendanceReport();
            return Ok(report);
        }
        [HttpPost("fillMembersAttendance")]
        public IActionResult FillMembersAttendence([FromBody] FillAttendanceModel attendance)
        {
            if (attendance == null)
            {
                return BadRequest();
            }
            bool isInsert = _attendanceRepository.FillMembersAttendence(attendance);
            if (isInsert)
            {
                return Ok();
            }
            return StatusCode(500, "server error");
        }
        [HttpPost("fillTrainersAttendance")]
        public IActionResult FillTrainersAttendence([FromBody] FillAttendanceModel attendance)
        {
            if (attendance == null)
            {
                return BadRequest();
            }
            bool isInsert = _attendanceRepository.FillTrainersAttendence(attendance);
            if (isInsert)
            {
                return Ok();
            }
            return StatusCode(500, "server error");
        }
        [HttpPut("updateMembersAttendance/{id}")]
        public IActionResult UpdateMembersAttendance(int id, [FromBody] UpdateAttendanceModelForMember attendance)
        {

            if (attendance == null || id != attendance.AttendanceID)
            {
                return BadRequest();
            }
            bool isUpdate = _attendanceRepository.UpdateMembersAttendance(attendance);
            if (isUpdate)
            {
                return Ok(attendance);
            }
            return StatusCode(500, "server error");
        }
        [HttpPut("updateTrainersAttendance/{id}")]
        public IActionResult UpdateTrainersAttendance(int id, [FromBody] UpdateAttendanceModelForTrainer attendance)
        {

            if (attendance == null || id != attendance.AttendanceID)
            {
                return BadRequest();
            }
            bool isUpdate = _attendanceRepository.UpdateTrainersAttendance(attendance);
            if (isUpdate)
            {
                return Ok(attendance);
            }
            return StatusCode(500, "server error");
        }
    }
}
