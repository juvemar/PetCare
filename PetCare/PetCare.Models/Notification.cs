namespace PetCare.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Notification : IDeletableEntity, IAuditInfo
    {
        public Notification()
        {
            this.CreatedOn = DateTime.UtcNow;
        }
        
        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Key, ForeignKey("VetVisit")]
        public int VetVisitId { get; set; }

        public string Message { get; set; }

        public bool IsSeen { get; set; }

        public DateTime DateTime { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual VetVisit VetVisit { get; set; }
    }
}
