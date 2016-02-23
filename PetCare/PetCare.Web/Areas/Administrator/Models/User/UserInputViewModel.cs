namespace PetCare.Web.Areas.Administrator.Models.User
{
    using System.ComponentModel.DataAnnotations;

    using Infrastructure.Mapping;

    public class UserInputViewModel: IMapFrom<PetCare.Models.User>
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }

        public bool IsVet { get; set; }

        public string SergeryLocation { get; set; }
    }
}