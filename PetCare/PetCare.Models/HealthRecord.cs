namespace PetCare.Models
{
    using System;
    using System.Collections.Generic;

    public class HealthRecord
    {
        private ICollection<VetVisit> vetVisits;

        public HealthRecord()
        {
            this.Id = Guid.NewGuid();
            this.vetVisits = new HashSet<VetVisit>();
        }

        public Guid Id { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public int PersonalVetId { get; set; }

        public virtual User PersonalVet { get; set; }

        public int PetId { get; set; }

        public virtual Pet Pet { get; set; }

        public virtual ICollection<VetVisit> VetVisits
        {
            get { return this.vetVisits; }
            set { this.vetVisits = value; }
        }
    }
}
