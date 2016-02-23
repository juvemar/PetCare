namespace PetCare.Web.Models.HealthRecord
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using PetCare.Web.Infrastructure.Mapping;
    using PetCare.Models;

    public class HealthRecordDetails : IMapFrom<HealthRecord>, IHaveCustomMappings
    {
        [Display(Name = "{0}")]
        public string PetName { get; set; }

        [Display(Name = "Weight:")]
        public double Weight { get; set; }

        [Display(Name = "Height:")]
        public double Height { get; set; }

        [Display(Name = "Fur Color:")]
        public string FurColor { get; set; }

        [Display(Name = "Coat:")]
        public string Coat { get; set; }

        public virtual IEnumerable<VetVisit> UpcomingVetVisits { get; set; }

        public virtual IEnumerable<VetVisit> PassedVetVisits { get; set; }

        public int PetId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<CreateHealthRecordViewModel, HealthRecord>("CreateHealthRecord")
                .ForMember(m => m.PetId, opts => opts.MapFrom(m => m.PetId));
        }
    }
}