namespace PetCare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Pet
    {
        private ICollection<Event> events;

        public Pet()
        {
            this.Id = Guid.NewGuid();
            this.events = new HashSet<Event>();
        }

        public Guid Id { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(2)]
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string BirthPlace { get; set; }

        public string Species { get; set; }

        public int OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public int HealthRecordId { get; set; }

        public virtual HealthRecord HealthRecord { get; set; }

        public virtual ICollection<Event> Events
        {
            get { return this.events; }
            set { this.events = value; }
        }
    }
}
