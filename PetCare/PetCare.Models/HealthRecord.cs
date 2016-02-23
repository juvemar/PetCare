namespace PetCare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class HealthRecord : IDeletableEntity, IAuditInfo
    {
        private ICollection<VetVisit> vetVisits;

        public HealthRecord()
        {
            this.vetVisits = new HashSet<VetVisit>();
            this.CreatedOn = DateTime.UtcNow;
        }

        [Key, ForeignKey("Pet")]
        public int PetId { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public double Height { get; set; }

        public string FurColor { get; set; }

        public string Coat { get; set; }

        public virtual Pet Pet { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<VetVisit> VetVisits
        {
            get { return this.vetVisits; }
            set { this.vetVisits = value; }
        }
    }
}
