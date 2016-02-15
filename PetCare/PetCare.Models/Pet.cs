namespace PetCare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Pet
    {
        private ICollection<Event> events;

        public Pet()
        {
            this.events = new HashSet<Event>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; }

        public string Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public string BirthPlace { get; set; }

        public string Species { get; set; }

        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }

        public int HealthRecordId { get; set; }
        
        public virtual HealthRecord HealthRecord { get; set; }

        public virtual ICollection<Event> Events
        {
            get { return this.events; }
            set { this.events = value; }
        }
    }
}
