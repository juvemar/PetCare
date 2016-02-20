namespace PetCare.Models
{
    using System;

    public class Notification
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public bool IsSeen { get; set; }

        public DateTime DateTime { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
