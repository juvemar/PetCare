namespace PetCare.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class VetVisit : IDeletableEntity, IAuditInfo
    {
        public VetVisit()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public string VetId { get; set; }

        public virtual User Vet { get; set; }

        public int PetId { get; set; }

        public virtual HealthRecord Pet { get; set; }

        public int NotificationId { get; set; }

        public virtual Notification Notification { get; set; }
    }
}
