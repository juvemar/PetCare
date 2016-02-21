namespace PetCare.Web.Models.VetVisit
{
    using System;

    using AutoMapper;
    using Infrastructure.Mapping;

    public class VetVisitDetailsViewModel : IMapFrom<PetCare.Models.VetVisit>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Description { get; set; }

        public string VetId { get; set; }

        public int HealthRecordId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<PetCare.Models.VetVisit, AddVetVisitViewModel>("VetVisitDetails")
                   .ForMember(m => m.HealthRecordId, opts => opts.MapFrom(m => m.PetId))
                   .ForMember(m => m.VetId, opts => opts.MapFrom(m => m.VetId));
        }
    }
}