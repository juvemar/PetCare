namespace PetCare.Web.Models.Pet
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using AutoMapper;

    using PetCare.Common;
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
        public GenderType Gender { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Town of Birth")]
        public string BirthPlace { get; set; }

        [Required]
        [Display(Name = "Species")]
        [UIHint("SpeciesInputForm")]
        public string Species { get; set; }

        public string OwnerId { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<AddPetViewModel, Pet>("AddPet")
                .ForMember(m => m.OwnerId, opts => opts.MapFrom(m => m.OwnerId));
        }
    }
}