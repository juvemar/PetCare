namespace PetCare.Web.Models.Account
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using Infrastructure.Mapping;

    using Pet;
    using PetCare.Models;
    using Common;
    public class UserDetailsViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public int? ProfilePictureId { get; set; }

        public List<PetDetailsViewModel> Pets { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Display(Name = "Gender")]
        public GenderType Gender { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Sergery Location")]
        public string SergeryLocation { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, UserDetailsViewModel>("UserDetails")
                 .ForMember(m => m.ProfilePictureId, opts => opts.MapFrom(m => m.ProfilePictureId))
                 .ForMember(m => m.Gender, opts => opts.MapFrom(m => m.Gender));
        }
    }
}