namespace PetCare.Web.Models.Account
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    using AutoMapper;

    using Infrastructure.Mapping;
    using PetCare.Models;

    public class UserDetailsViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public HttpPostedFileBase ProfilePicture { get; set; }

        //public List<Pet> Pets { get; set; }

        public bool IsVet { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string SergeryLocation { get; set; }

        public string Email { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            throw new NotImplementedException();
        }
    }
}