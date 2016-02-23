namespace PetCare.Web.Areas.Administrator.Models.Pet
{
    using System;

    using AutoMapper;

    using PetCare.Models;
    using PetCare.Web.Infrastructure.Mapping;

    public class PetAdminViewModel : IMapFrom<Pet>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string BirthPlace { get; set; }

        public string Species { get; set; }

        public string OwnerId { get; set; }

        public int? ImageId { get; set; }

        public int HealthRecordId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<PetAdminViewModel, Pet>("AddPet")
                .ForMember(m => m.OwnerId, opts => opts.MapFrom(m => m.OwnerId))
                .ForMember(m => m.HealthRecordId, opts => opts.MapFrom(m => m.HealthRecordId));
        }
    }
}