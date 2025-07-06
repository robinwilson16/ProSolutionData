using ProSolutionData.Models;
using ProSolutionData.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProSolutionData.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public ActionResult<List<CourseModel>?> GetAll() =>
            _courseService.GetAll();

        [HttpGet("{courseCode}")]
        public ActionResult<CourseModel> Get(string courseCode)
        {
            var course = _courseService.Get(courseCode);

            if (course == null)
                return NotFound();

            return course;
        }

        [HttpGet("team/{teamCode}")]
        public ActionResult<List<CourseModel>> GetAll(string teamCode) =>
            _courseService.GetAll(teamCode);


        [HttpGet("{teamCode}/{courseCode}")]
        public ActionResult<CourseModel> Get(string teamCode, string courseCode)
        {
            var course = _courseService.Get(teamCode, courseCode);

            if (course == null)
                return NotFound();

            return course;
        }

        [HttpGet("OfferingID/{courseID}")]
        public ActionResult<CourseModel> Get(int courseID)
        {
            var course = _courseService.GetByID(courseID);

            if (course == null)
                return NotFound();

            return course;
        }

        [HttpGet("Enquire")]
        public ActionResult<List<CourseModel>> GetEnquire()
        {
            var courses = _courseService.GetEnquire();

            if (courses == null)
                return NotFound();

            return courses;
        }

        [HttpGet("Enquire/{teamCode}")]
        public ActionResult<List<CourseModel>> GetEnquire(string teamCode)
        {
            var courses = _courseService.GetEnquire(teamCode);

            if (courses == null)
                return NotFound();

            return courses;
        }

        [HttpGet("Apply")]
        public ActionResult<List<CourseModel>> GetApply()
        {
            var courses = _courseService.GetApply();

            if (courses == null)
                return NotFound();

            return courses;
        }

        [HttpGet("Apply/{teamCode}")]
        public ActionResult<List<CourseModel>> GetApply(string teamCode)
        {
            var courses = _courseService.GetApply(teamCode);

            if (courses == null)
                return NotFound();

            return courses;
        }

        [HttpGet("Enrol")]
        public ActionResult<List<CourseModel>> GetEnrol()
        {
            var courses = _courseService.GetEnrol();

            if (courses == null)
                return NotFound();

            return courses;
        }

        [HttpGet("Enrol/{teamCode}")]
        public ActionResult<List<CourseModel>> GetEnrol(string teamCode)
        {
            var courses = _courseService.GetEnrol(teamCode);

            if (courses == null)
                return NotFound();

            return courses;
        }

        [HttpGet("Search/{search}")]
        public ActionResult<List<CourseModel>> Search(string search)
        {
            var courses = _courseService.Search(search);

            if (courses == null)
                return NotFound();

            return courses;
        }

        [HttpGet("Search/{teamCode}/{search}")]
        public ActionResult<List<CourseModel>> Search(string teamCode, string search)
        {
            var courses = _courseService.Search(search);

            if (courses == null)
                return NotFound();

            return courses;
        }

        [HttpGet("Search/Enquire/{search}")]
        public ActionResult<List<CourseModel>> SearchEnquire(string search)
        {
            var courses = _courseService.SearchEnquire(search);

            if (courses == null)
                return NotFound();

            return courses;
        }

        [HttpGet("Search/Enquire/{teamCode}/{search}")]
        public ActionResult<List<CourseModel>> SearchEnquire(string teamCode, string search)
        {
            var courses = _courseService.SearchEnquire(search);

            if (courses == null)
                return NotFound();

            return courses;
        }

        [HttpGet("Search/Apply/{search}")]
        public ActionResult<List<CourseModel>> SearchApply(string search)
        {
            var courses = _courseService.SearchApply(search);

            if (courses == null)
                return NotFound();

            return courses;
        }

        [HttpGet("Search/Apply/{teamCode}/{search}")]
        public ActionResult<List<CourseModel>> SearchApply(string teamCode, string search)
        {
            var courses = _courseService.SearchApply(search);

            if (courses == null)
                return NotFound();

            return courses;
        }

        [HttpGet("Search/Enrol/{search}")]
        public ActionResult<List<CourseModel>> SearchEnrol(string search)
        {
            var courses = _courseService.SearchEnrol(search);

            if (courses == null)
                return NotFound();

            return courses;
        }

        [HttpGet("Search/Enrol/{teamCode}/{search}")]
        public ActionResult<List<CourseModel>> SearchEnrol(string teamCode, string search)
        {
            var courses = _courseService.SearchEnrol(search);

            if (courses == null)
                return NotFound();

            return courses;
        }
    }
}
