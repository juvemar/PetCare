namespace PetCare.Web.Areas.Administrator.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using PetCare.Models;
    using PetCare.Web.Infrastructure.Mapping;

    public class CreatePetAdminViewModel : IMapFrom<Pet>, IHaveCustomMappings
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; }

        public string Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public string BirthPlace { get; set; }

        [Required]
        public string Species { get; set; }

        public string OwnerId { get; set; }

        public int? ImageId { get; set; }

        public int HealthRecordId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<CreatePetAdminViewModel, Pet>("AddPet")
                .ForMember(m => m.OwnerId, opts => opts.MapFrom(m => m.OwnerId))
                .ForMember(m => m.HealthRecordId, opts => opts.MapFrom(m => m.HealthRecordId));
        }
    }
}