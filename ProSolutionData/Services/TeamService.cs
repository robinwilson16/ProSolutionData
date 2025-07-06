using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using ProSolutionData.Data;
using ProSolutionData.Models;
using ProSolutionData.Shared;

namespace ProSolutionData.Services
{
    public class TeamService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public List<TeamModel>? Teams { get; }

        public TeamService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            string? academicYear = _configuration.GetSection("Settings")["DefaultAcademicYearID"];

            Teams = _context.Team!
                .FromSqlInterpolated($"EXEC SPR_API_Team @AcademicYear = {academicYear}, @Faculty = 'ALL', @Team = 'ALL'")
                .ToList();
        }

        public List<TeamModel> GetAll() => Teams ?? new List<TeamModel>();
        public TeamModel? Get(string teamCode) => (Teams ?? new List<TeamModel>()).FirstOrDefault(a => a.TeamCode == StringFunctions.URLDecode(teamCode));
        public List<TeamModel> GetEnquire() => Teams ?? new List<TeamModel>()
            .Where(a => a.CanEnquire == true)
            .Where(a => a.HasCourseInformation == true)
            .Where(a => a.IsObsolete == false)
            .Where(a => a.HasExpired == false)
            .Where(a => a.IsValidOfferingType == true)
            .ToList();

        public List<TeamModel> GetApply() => Teams ?? new List<TeamModel>()
            .Where(a => a.CanApply == true)
            .Where(a => a.HasCourseInformation == true)
            .Where(a => a.IsObsolete == false)
            .Where(a => a.HasExpired == false)
            .Where(a => a.IsValidOfferingType == true)
            .ToList();

        public List<TeamModel> GetEnrol() => Teams ?? new List<TeamModel>()
            .Where(a => a.CanEnrol == true)
            .Where(a => a.HasCourseInformation == true)
            .Where(a => a.IsObsolete == false)
            .Where(a => a.HasExpired == false)
            .Where(a => a.IsValidOfferingType == true)
            .ToList();
    }
}
