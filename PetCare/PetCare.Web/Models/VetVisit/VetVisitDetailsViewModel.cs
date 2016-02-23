namespace PetCare.Web.Models.VetVisit
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using Infrastructure.Mapping;

    using PetCare.Models;

    public class VetVisitDetailsViewModel : IMapFrom<VetVisit>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Display(Name = "Date of Visit")]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateTime { get; set; }

        [Display(Name = "Visit Description")]
        public string Description { get; set; }

        [Display(Name = "Vet Name")]
        public string VetName { get; set; }

        public int HealthRecordId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<VetVisit, VetVisitDetailsViewModel>("VetVisitDetails")
                   .ForMember(m => m.HealthRecordId, opts => opts.MapFrom(m => m.PetId))
                   .ForMember(m => m.VetName, opts => opts.MapFrom(m => m.Vet.FirstName + " " + m.Vet.LastName));
        }
    }
}