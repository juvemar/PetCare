﻿namespace PetCare.Models
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
            //this.Id = Guid.NewGuid();
            this.vetVisits = new HashSet<VetVisit>();
        }

        public int Id { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public double Height { get; set; }

        public string PersonalVetId { get; set; }

        public virtual User PersonalVet { get; set; }

        public int? PetId { get; set; }

        //[ForeignKey("PetId")]
        public virtual Pet Pet { get; set; }

        public virtual ICollection<VetVisit> VetVisits
        {
            get { return this.vetVisits; }
            set { this.vetVisits = value; }
        }
    }
}
