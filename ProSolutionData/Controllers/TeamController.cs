using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using ProSolutionData.Models;
using ProSolutionData.Services;

namespace ProSolutionData.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly TeamService _teamService;

        public TeamController(TeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public ActionResult<List<TeamModel>?> GetAll() =>
            _teamService.GetAll();

        [HttpGet("{teamCode}")]
        public ActionResult<TeamModel> Get(string teamCode)
        {
            var team = _teamService.Get(teamCode);

            if (team == null)
                return NotFound();

            return team;
        }

        [HttpGet("Enquire")]
        public ActionResult<List<TeamModel>> GetEnquire()
        {
            var teams = _teamService.GetEnquire();

            if (teams == null)
                return NotFound();

            return teams;
        }

        [HttpGet("Apply")]
        public ActionResult<List<TeamModel>> GetApply()
        {
            var teams = _teamService.GetApply();

            if (teams == null)
                return NotFound();

            return teams;
        }

        [HttpGet("Enrol")]
        public ActionResult<List<TeamModel>> GetEnrol()
        {
            var teams = _teamService.GetEnrol();

            if (teams == null)
                return NotFound();

            return teams;
        }
    }
}
