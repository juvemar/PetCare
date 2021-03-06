﻿namespace PetCare.Web.Models.Pet
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using AutoMapper;
    
    using PetCare.Models;
    using PetCare.Web.Infrastructure.Mapping;

    public class AddPetViewModel : IMapFrom<Pet>, IHaveCustomMappings
    {
        [UIHint("ProfilePictureInputForm")]
        public HttpPostedFileBase ProfilePicture { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Gender")]
        [UIHint("GenderInputForm")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Town of Birth")]
        public string BirthPlace { get; set; }

        [Required]
        [Display(Name = "Species")]
        [UIHint("SpeciesInputForm")]
        public string Species { get; set; }

        public string OwnerId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<AddPetViewModel, Pet>("AddPet")
                .ForMember(m => m.OwnerId, opts => opts.MapFrom(m => m.OwnerId));
        }
    }
}