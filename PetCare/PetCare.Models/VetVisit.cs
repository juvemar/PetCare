namespace PetCare.Models
{
    using System;

    public class VetVisit
    {
        public VetVisit()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Description { get; set; }

        public int VetId { get; set; }

        public virtual User Vet { get; set; }

        public int HealthRecordId { get; set; }

        public virtual HealthRecord HealthRecord { get; set; }
    }
}
