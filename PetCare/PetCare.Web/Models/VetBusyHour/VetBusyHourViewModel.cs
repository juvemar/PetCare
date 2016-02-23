namespace PetCare.Web.Models.VetBusyHour
{
    using System;

    using AutoMapper;

    using PetCare.Web.Infrastructure.Mapping;

    public class VetBusyHourViewModel : IMapFrom<PetCare.Models.VetVisit>, IHaveCustomMappings
    {
        public DateTime DateTime { get; set; }

        public string Description { get; set; }

        public string VetId { get; set; }

        public int PetId { get; set; }

        public virtual PetCare.Models.HealthRecord Pet { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<VetBusyHourViewModel, PetCare.Models.VetVisit>("PetDetails")
                .ForMember(m => m.Pet, opts => opts.MapFrom(m => m.Pet))
                .ForMember(m => m.PetId, opts => opts.MapFrom(m => m.PetId));
        }
    }
}