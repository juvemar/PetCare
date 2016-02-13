﻿namespace PetCare.Web.Models.Pet
{
    using System;

    using AutoMapper;
    using Infrastructure.Mapping;

    using PetCare.Models;
    using System.ComponentModel.DataAnnotations;
    public class PetDetailsViewModel : IMapFrom<Pet>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Gender { get; set; }

        [Display (Name="Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0}dd/MM/yy")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Place of Birth")]
        public string BirthPlace { get; set; }

        public string Species { get; set; }

        public string OwnerId { get; set; }

        public int? ImageId { get; set; }

        public int HealthRecordId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<PetDetailsViewModel, Pet>("PetDetails")
                .ForMember(m => m.OwnerId, opts => opts.MapFrom(m => m.OwnerId))
                .ForMember(m => m.HealthRecordId, opts => opts.MapFrom(m => m.HealthRecordId))
                 .ForMember(m => m.ImageId, opts => opts.MapFrom(m => m.ImageId));
        }
    }
}