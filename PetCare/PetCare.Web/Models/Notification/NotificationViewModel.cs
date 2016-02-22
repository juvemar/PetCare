namespace PetCare.Web.Models.Notification
{
    using System;

    using PetCare.Web.Infrastructure.Mapping;
    using PetCare.Models;

    public class NotificationViewModel : IMapFrom<Notification>
    {
        public int VetVisitId { get; set; }

        public string Message { get; set; }

        public bool IsSeen { get; set; }

        public DateTime DateTime { get; set; }

        public User User { get; set; }
    }
}