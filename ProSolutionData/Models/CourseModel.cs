using System.ComponentModel.DataAnnotations;

namespace ProSolutionData.Models
{
    public class CourseModel
    {
        public string? AcademicYear { get; set; }
        public string? FacultyCode { get; set; }
        public string? FacultyName { get; set; }
        public string? TeamCode { get; set; }
        public string? TeamName { get; set; }
        public string? SiteCode { get; set; }
        public string? SiteName { get; set; }

        [Key]
        public int CourseID { get; set; }
        public string? CourseCode { get; set; }
        public string? CourseTitle { get; set; }
        public string? CourseInformationCode { get; set; }
        public string? CourseInformationTitle { get; set; }
        public int? OfferingTypeCode { get; set; }
        public string? OfferingTypeName { get; set; }
        public int? EnrolmentTypeCode { get; set; }
        public string? EnrolmentTypeName { get; set; }
        public string? SuitableFor { get; set; }
        public string? AimCode { get; set; }
        public string? AimTitle { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? CanEnquire { get; set; }
        public bool? CanApply { get; set; }
        public bool? CanEnrol { get; set; }
        public bool? HasCourseInformation { get; set; }
        public bool? IsObsolete { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool? HasExpired { get; set; }
        public bool? IsValidOfferingType { get; set; }
        public bool? IsChild { get; set; }
    }
}
