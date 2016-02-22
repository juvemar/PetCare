namespace PetCare.Web.Areas.Administrator.Models.Pet
{
    using System.ComponentModel.DataAnnotations;

    using PetCare.Models;
    using PetCare.Web.Infrastructure.Mapping;

    public class PetAdminInputViewModel : IMapFrom<Pet>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; }
        
        [Display(Name = "Gender")]
        [UIHint("GenderInputForm")]
        public string Gender { get; set; }

        [Required]
        public string BirthPlace { get; set; }

        [Required]
        [Display(Name = "Species")]
        [UIHint("SpeciesInputForm")]
        public string Species { get; set; }
    }
}