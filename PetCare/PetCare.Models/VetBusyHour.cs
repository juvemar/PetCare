namespace PetCare.Models
{
    using System;

    public class VetBusyHour : IDeletableEntity, IAuditInfo
    {
        public VetBusyHour()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string VetId { get; set; }

        public virtual User Vet { get; set; }
    }
}
