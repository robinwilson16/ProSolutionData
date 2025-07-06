using System.ComponentModel.DataAnnotations;

namespace ProSolutionData.Models
{
    public class TeamModel
    {
        public string? AcademicYear { get; set; }

        [Key]
        public string? TeamCode { get; set; }
        public string? TeamName { get; set; }

        public bool? CanEnquire { get; set; }
        public bool? CanApply { get; set; }
        public bool? CanEnrol { get; set; }
        public bool? HasCourseInformation { get; set; }
        public bool? IsObsolete { get; set; }
        public bool? HasExpired { get; set; }
        public bool? IsValidOfferingType { get; set; }
        public bool? IsChild { get; set; }
    }
}
