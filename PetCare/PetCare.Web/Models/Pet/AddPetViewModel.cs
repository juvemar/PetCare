﻿namespace PetCare.Web.Models.Pet
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using PetCare.Common;
    using PetCare.Models;
    using PetCare.Web.Infrastructure.Mapping;

    public class AddPetViewModel : IMapFrom<Pet>, IHaveCustomMappings
    {
        [Required]
        [StringLength(30, MinimumLength = 2)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Town of Birth")]
        public string BirthPlace { get; set; }

        [Required]
        [Display(Name = "Species")]
        public string Species { get; set; }

        public string OwnerId { get; set; }

        public int? ImageId { get; set; }

        public int? HealthRecordId { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<AddPetViewModel, Pet>("AddPet")
                .ForMember(m => m.OwnerId, opts => opts.MapFrom(m => m.OwnerId))
                .ForMember(m => m.HealthRecordId, opts => opts.MapFrom(m => m.HealthRecordId))
                .ForMember(m => m.ImageId, opts => opts.MapFrom(m => m.ImageId));
        }
    }
}