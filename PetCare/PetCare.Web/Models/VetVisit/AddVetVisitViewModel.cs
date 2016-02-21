namespace PetCare.Web.Models.VetVisit
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;
    using Infrastructure.Mapping;

    using PetCare.Models;

    public class AddVetVisitViewModel : IMapFrom<VetVisit>, IHaveCustomMappings
    {
        [Required]
        public DateTime DateTime { get; set; }

        public string VetName { get; set; }

        [StringLength(500)]
        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name ="Vet")]
        public string VetId { get; set; }

        public List<SelectListItem> Vets { get; set; }

        [Required]
        //[HiddenInput(DisplayValue = false)]
        public int HealthRecordId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<AddVetVisitViewModel, VetVisit>("CreateHealthRecord")
                   .ForMember(m => m.PetId, opts => opts.MapFrom(m => m.HealthRecordId))
                   .ForMember(m => m.VetId, opts => opts.MapFrom(m => m.VetId));
        }
    }
}