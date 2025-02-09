using GymManagementApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardRepository _dashboardRepository;

        public DashboardController(DashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        [HttpGet("totalMembers")]
        public IActionResult GetTotalMembers()
        {
            var totalmembers = _dashboardRepository.GetTotalMembers();
            return Ok(totalmembers);
        }
        [HttpGet("totalTrainers")]
        public IActionResult GetTotalTrainers()
        {
            var totaltrainers = _dashboardRepository.GetTotalTrainer();
            return Ok(totaltrainers);
        }
        [HttpGet("totalEquipments")]
        public IActionResult GetTotalEquipments()
        {
            var totalequipments= _dashboardRepository.GetTotalEquipments();
            return Ok(totalequipments);
        }

        [HttpGet("totalMemberShipPlans")]
        public IActionResult GetTotalMemberShipPlans()
        {
            var totalmembershipplans = _dashboardRepository.GetTotalMemberShipPlans();
            return Ok(totalmembershipplans);
        }
        [HttpGet("totalMemberShipTrainerWise/{id}")]
        public IActionResult GetTotalMemberTrainerWise(int id)
        {
            var totalmembershipplans = _dashboardRepository.GetTotalMemberTrainerWise(id);
            return Ok(totalmembershipplans);
        }
    }
}
