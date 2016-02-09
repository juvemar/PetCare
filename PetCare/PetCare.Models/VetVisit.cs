namespace PetCare.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class VetVisit
    {
        public VetVisit()
        {
            //this.Id = Guid.NewGuid();
        }

        public int Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public string VetId { get; set; }

        public virtual User Vet { get; set; }

        public int HealthRecordId { get; set; }

        public virtual HealthRecord HealthRecord { get; set; }
    }
}
