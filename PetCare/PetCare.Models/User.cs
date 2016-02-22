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

    public class User : IdentityUser, IDeletableEntity, IAuditInfo
    {
        private ICollection<Pet> pets;
        private ICollection<VetVisit> vetVisits;
        private ICollection<VetBusyHour> vetBusyHours;

        public User()
        {
            this.pets = new HashSet<Pet>();
            this.vetVisits = new HashSet<VetVisit>();
            this.vetBusyHours = new HashSet<VetBusyHour>();
            this.CreatedOn = DateTime.UtcNow;
        }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }

        public bool IsVet { get; set; }

        public int? ForumPoints { get; set; }

        public GenderType Gender { get; set; }

        public string SergeryLocation { get; set; }

        public int? ProfilePictureId { get; set; }

        public virtual Image ProfilePicture { get; set; }

        public virtual Room Room { get; set; }

        public virtual ICollection<Pet> Pets
        {
            get { return this.pets; }
            set { this.pets = value; }
        }

        public virtual ICollection<VetVisit> VetVisits
        {
            get { return this.vetVisits; }
            set { this.vetVisits = value; }
        }

        public virtual ICollection<VetBusyHour> VetBusyHours
        {
            get { return this.vetBusyHours; }
            set { this.vetBusyHours = value; }
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
