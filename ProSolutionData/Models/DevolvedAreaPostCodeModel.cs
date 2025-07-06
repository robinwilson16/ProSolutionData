using System.ComponentModel.DataAnnotations;

namespace ProSolutionData.Models
{
    public class DevolvedAreaPostCodeModel
    {
        [Key]
        public int DevolvedAreaPostCodeID { get; set; }

        public string? PostCode { get; set; }

        public string? FundingSourceCode { get; set; }

        public string? FundingSourceName { get; set; }

        public DateTime? EffectiveStartDate { get; set; }

        public DateTime? EffectiveEndDate { get; set; }

        public bool IsSOFOffered { get; set; }
    }
}
