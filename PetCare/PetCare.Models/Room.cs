namespace PetCare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Room : IDeletableEntity, IAuditInfo
    {
        private ICollection<Notification> notifications;

        public Room()
        {
            this.notifications = new HashSet<Notification>();
            this.CreatedOn = DateTime.UtcNow;
        }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Key, ForeignKey("User")]
        public string UserId { get; set; }

        public string Name { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Notification> Notifications
        {
            get { return this.notifications; }
            set { this.notifications = value; }
        }
    }
}
