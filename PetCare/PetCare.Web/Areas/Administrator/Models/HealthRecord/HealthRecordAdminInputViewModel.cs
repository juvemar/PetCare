namespace PetCare.Web.Areas.Administrator.Models.HealthRecord
{
    using System.ComponentModel.DataAnnotations;

    using PetCare.Web.Infrastructure.Mapping;

    public class HealthRecordAdminInputViewModel : IMapFrom<PetCare.Models.HealthRecord>
    {
        [Key]
        public int PetId { get; set; }

        [Required]
        [Display(Name = "Weight (in kilograms)")]
        public double Weight { get; set; }

        [Required]
        [Display(Name = "Height (in centimeters)")]
        public double Height { get; set; }

        public string FurColor { get; set; }

        public string Coat { get; set; }
    }
}