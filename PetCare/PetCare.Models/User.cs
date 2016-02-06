namespace PetCare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Common;

    public class User : IdentityUser
    {
        private ICollection<Pet> pets;

        public User()
        {
            this.pets = new HashSet<Pet>();
        }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int ForumPoints { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public override string Email { get; set; }

        public override string PhoneNumber { get; set; }

        public string SergeryLocation { get; set; }

        public virtual ICollection<Pet> Pets
        {
            get { return this.pets; }
            set { this.pets = value; }
        }

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}
