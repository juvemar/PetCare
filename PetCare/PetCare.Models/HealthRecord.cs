namespace PetCare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class HealthRecord
    {
        private ICollection<VetVisit> vetVisits;

        public HealthRecord()
        {
            this.vetVisits = new HashSet<VetVisit>();
        }

        [Key, ForeignKey("Pet")]
        public int PetId { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public double Height { get; set; }

        public virtual Pet Pet { get; set; }

        public virtual ICollection<VetVisit> VetVisits
        {
            get { return this.vetVisits; }
            set { this.vetVisits = value; }
        }
    }
}
