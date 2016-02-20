namespace PetCare.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Room
    {
        private ICollection<Notification> notifications;

        public Room()
        {
            this.notifications = new HashSet<Notification>();
        }

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
