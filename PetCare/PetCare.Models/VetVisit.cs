namespace PetCare.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class VetVisit
    {
        public VetVisit()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public Guid VetId { get; set; }

        public virtual User Vet { get; set; }

        [Required]
        public Guid HealthRecordId { get; set; }

        public virtual HealthRecord HealthRecord { get; set; }
    }
}
