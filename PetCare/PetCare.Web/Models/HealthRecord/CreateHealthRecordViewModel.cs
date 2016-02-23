namespace PetCare.Web.Models.HealthRecord
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using PetCare.Models;
    using PetCare.Web.Infrastructure.Mapping;

    public class CreateHealthRecordViewModel : IMapFrom<HealthRecord>, IHaveCustomMappings
    {
        [Required]
        [Display(Name ="Weight (in kilograms)")]
        public double Weight { get; set; }

        [Required]
        [Display(Name = "Height (in centimeters)")]
        public double Height { get; set; }

        public string FurColor { get; set; }

        public string Coat { get; set; }

        public int PetId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<CreateHealthRecordViewModel, HealthRecord>("CreateHealthRecord")
                .ForMember(m => m.PetId, opts => opts.MapFrom(m => m.PetId));
        }
    }
}