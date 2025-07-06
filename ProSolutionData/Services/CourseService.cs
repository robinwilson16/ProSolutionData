using ProSolutionData.Data;
using ProSolutionData.Models;
using Microsoft.EntityFrameworkCore;
using ProSolutionData.Shared;

namespace ProSolutionData.Services
{
    public class CourseService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public List<CourseModel>? Courses { get; }

        public CourseService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            string? academicYear = _configuration.GetSection("Settings")["DefaultAcademicYearID"];

            Courses = _context.Course!
                .FromSqlInterpolated($"EXEC SPR_API_Course @AcademicYear = {academicYear}, @Faculty = 'ALL', @Team = 'ALL'")
                .ToList();
        }

        public List<CourseModel> GetAll() => Courses ?? new List<CourseModel>();
        public List<CourseModel> GetAll(string teamCode) => Courses ?? new List<CourseModel>().Where(a => a.TeamCode == StringFunctions.URLDecode(teamCode)).ToList();
        public CourseModel? Get(string courseCode) => (Courses ?? new List<CourseModel>()).FirstOrDefault(a => a.CourseCode == StringFunctions.URLDecode(courseCode));
        public CourseModel? Get(string teamCode, string courseCode) => Courses.FirstOrDefault(a => a.TeamCode == StringFunctions.URLDecode(teamCode) && a.CourseCode == StringFunctions.URLDecode(courseCode));
        public CourseModel? GetByCode(string courseCode) => (Courses ?? new List<CourseModel>()).FirstOrDefault(a => a.CourseCode == StringFunctions.URLDecode(courseCode));
        public CourseModel? GetByID(int courseID) => (Courses ?? new List<CourseModel>()).FirstOrDefault(a => a.CourseID == courseID);

        public List<CourseModel> GetEnquire() => Courses ?? new List<CourseModel>()
            .Where(a => a.CanEnquire == true)
            .Where(a => a.HasCourseInformation == true)
            .Where(a => a.IsObsolete == false)
            .Where(a => a.HasExpired == false)
            .Where(a => a.IsValidOfferingType == true)
            .ToList();

        public List<CourseModel> GetEnquire(string teamCode) => Courses ?? new List<CourseModel>()
            .Where(a => a.TeamCode == StringFunctions.URLDecode(teamCode))
            .Where(a => a.CanEnquire == true)
            .Where(a => a.HasCourseInformation == true)
            .Where(a => a.IsObsolete == false)
            .Where(a => a.HasExpired == false)
            .Where(a => a.IsValidOfferingType == true)
            .ToList();

        public List<CourseModel> GetApply() => Courses ?? new List<CourseModel>()
            .Where(a => a.CanApply == true)
            .Where(a => a.HasCourseInformation == true)
            .Where(a => a.IsObsolete == false)
            .Where(a => a.HasExpired == false)
            .Where(a => a.IsValidOfferingType == true)
            .ToList();

        public List<CourseModel> GetApply(string teamCode) => Courses ?? new List<CourseModel>()
            .Where(a => a.TeamCode == StringFunctions.URLDecode(teamCode))
            .Where(a => a.CanApply == true)
            .Where(a => a.HasCourseInformation == true)
            .Where(a => a.IsObsolete == false)
            .Where(a => a.HasExpired == false)
            .Where(a => a.IsValidOfferingType == true)
            .ToList();

        public List<CourseModel> GetEnrol() => Courses ?? new List<CourseModel>()
            .Where(a => a.CanEnrol == true)
            .Where(a => a.HasCourseInformation == true)
            .Where(a => a.IsObsolete == false)
            .Where(a => a.HasExpired == false)
            .Where(a => a.IsValidOfferingType == true)
            .ToList();

        public List<CourseModel> GetEnrol(string teamCode) => Courses ?? new List<CourseModel>()
            .Where(a => a.TeamCode == StringFunctions.URLDecode(teamCode))
            .Where(a => a.CanEnrol == true)
            .Where(a => a.HasCourseInformation == true)
            .Where(a => a.IsObsolete == false)
            .Where(a => a.HasExpired == false)
            .Where(a => a.IsValidOfferingType == true)
            .ToList();

        //public List<Course> Search(string search) => Courses.Where(a => EF.Functions.Like(a.CourseTitle, $"%{search}%")).ToList();
        public List<CourseModel> Search(string search) => Courses ?? new List<CourseModel>()
            .Where(a => a.CourseTitle!.ToLower().Contains(search.ToLower()))
            .Where(a => a.HasCourseInformation == true)
            .Where(a => a.IsObsolete == false)
            .Where(a => a.HasExpired == false)
            .Where(a => a.IsValidOfferingType == true)
            .ToList();

        public List<CourseModel> Search(string teamCode, string search) => Courses ?? new List<CourseModel>()
            .Where(a => a.TeamCode == StringFunctions.URLDecode(teamCode))
            .Where(a => a.CourseTitle!.ToLower().Contains(search.ToLower()))
            .Where(a => a.HasCourseInformation == true)
            .Where(a => a.IsObsolete == false)
            .Where(a => a.HasExpired == false)
            .Where(a => a.IsValidOfferingType == true)
            .ToList();

        public List<CourseModel> SearchEnquire(string search) => Courses ?? new List<CourseModel>()
            .Where(a => a.CourseTitle!.ToLower().Contains(search.ToLower()))
            .Where(a => a.CanEnquire == true)
            .Where(a => a.HasCourseInformation == true)
            .Where(a => a.IsObsolete == false)
            .Where(a => a.HasExpired == false)
            .Where(a => a.IsValidOfferingType == true)
            .ToList();

        public List<CourseModel> SearchEnquire(string teamCode, string search) => Courses ?? new List<CourseModel>()
            .Where(a => a.TeamCode == StringFunctions.URLDecode(teamCode))
            .Where(a => a.CourseTitle!.ToLower().Contains(search.ToLower()))
            .Where(a => a.CanEnquire == true)
            .Where(a => a.HasCourseInformation == true)
            .Where(a => a.IsObsolete == false)
            .Where(a => a.HasExpired == false)
            .Where(a => a.IsValidOfferingType == true)
            .ToList();

        public List<CourseModel> SearchApply(string search) => Courses ?? new List<CourseModel>()
            .Where(a => a.CourseTitle!.ToLower().Contains(search.ToLower()))
            .Where(a => a.CanApply == true)
            .Where(a => a.HasCourseInformation == true)
            .Where(a => a.IsObsolete == false)
            .Where(a => a.HasExpired == false)
            .Where(a => a.IsValidOfferingType == true)
            .ToList();

        public List<CourseModel> SearchApply(string teamCode, string search) => Courses ?? new List<CourseModel>()
            .Where(a => a.TeamCode == StringFunctions.URLDecode(teamCode))
            .Where(a => a.CourseTitle!.ToLower().Contains(search.ToLower()))
            .Where(a => a.CanApply == true)
            .Where(a => a.HasCourseInformation == true)
            .Where(a => a.IsObsolete == false)
            .Where(a => a.HasExpired == false)
            .Where(a => a.IsValidOfferingType == true)
            .ToList();

        public List<CourseModel> SearchEnrol(string search) => Courses ?? new List<CourseModel>()
            .Where(a => a.CourseTitle!.ToLower().Contains(search.ToLower()))
            .Where(a => a.CanEnrol == true)
            .Where(a => a.HasCourseInformation == true)
            .Where(a => a.IsObsolete == false)
            .Where(a => a.HasExpired == false)
            .Where(a => a.IsValidOfferingType == true)
            .ToList();

        public List<CourseModel> SearchEnrol(string teamCode, string search) => Courses ?? new List<CourseModel>()
            .Where(a => a.TeamCode == StringFunctions.URLDecode(teamCode))
            .Where(a => a.CourseTitle!.ToLower().Contains(search.ToLower()))
            .Where(a => a.CanEnrol == true)
            .Where(a => a.HasCourseInformation == true)
            .Where(a => a.IsObsolete == false)
            .Where(a => a.HasExpired == false)
            .Where(a => a.IsValidOfferingType == true)
            .ToList();
    }
}
