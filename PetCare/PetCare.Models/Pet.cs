namespace PetCare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        public DateTime DateOfBirth { get; set; }

        public string BirthPlace { get; set; }

        [Required]
        public string Species { get; set; }

        public Guid OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }

        public Guid HealthRecordId { get; set; }

        [ForeignKey("HealthRecordId")]
        public virtual HealthRecord HealthRecord { get; set; }

        public virtual ICollection<Event> Events
        {
            get { return this.events; }
            set { this.events = value; }
        }
    }
}
