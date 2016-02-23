namespace PetCare.Web.Models.VetFreeHour
{
    using System;

    using AutoMapper;

    using PetCare.Web.Infrastructure.Mapping;

    public class VetFreeHourViewModel : IMapFrom<PetCare.Models.VetBusyHour>, IHaveCustomMappings
    {
        public int HealthRecordId { get; set; }

        public string Description { get; set; }

        public string VetName { get; set; }

        public DateTime Date { get; set; }

        public string VetId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<PetCare.Models.VetBusyHour, VetFreeHourViewModel>("VetBusyHourDetails")
                 .ForMember(m => m.VetId, opts => opts.MapFrom(m => m.VetId));
        }
    }
}