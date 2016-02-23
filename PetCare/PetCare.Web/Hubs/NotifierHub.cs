namespace PetCare.Web.Hubs
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;
    using Newtonsoft.Json;

    using Common;
    using Data;
    using Models.Notification;
    using PetCare.Models;
    

    public class NotifierHub : Hub
    {

        private static System.Runtime.Caching.MemoryCache asd;
        public override Task OnConnected()
        {
           

            if (!Context.User.Identity.IsAuthenticated)
            {
                return base.OnConnected();
            }

            User currentUser = new User();
            var notifications = new List<Notification>();
            var recordedNotifications = new List<NotificationViewModel>();
            using (var db = new PetCareDbContext())
            {
                currentUser = db.Users.FirstOrDefault(x => x.UserName == Context.User.Identity.Name);
                if (currentUser.IsVet || currentUser.Pets.Count == 0)
                {
                    return base.OnConnected();
                }

                var room = db.Rooms.FirstOrDefault(x => x.UserId == currentUser.Id);
                if (room == null)
                {
                    db.Rooms.Add(room = new Room()
                    {
                        Name = currentUser.UserName + "Room",
                        UserId = currentUser.Id
                    });
                    db.SaveChanges();
                }

                Groups.Add(Context.ConnectionId, room.Name);

                var pets = currentUser.Pets.Where(x => x.HealthRecord != null).ToList();

                if (pets.Count == 0)
                {
                    return base.OnConnected();
                }

                var visits = pets
                    .SelectMany(x => x.HealthRecord.VetVisits)
                    .Where(x => x.DateTime.Day > DateTime.UtcNow.Day && x.DateTime.Day <= DateTime.UtcNow.AddDays(1).Day)
                    .ToList();
                
                foreach (var visit in visits)
                {
                    var viewModel = new NotificationViewModel()
                    {
                        DateTime = DateTime.UtcNow,
                        Message = string.Format(GlobalConstants.VetVisitNotificationInThreeDays, visit.Pet.Pet.Name, visit.Vet.FirstName, visit.Vet.LastName),
                        User = currentUser,
                        IsSeen = false,
                        VetVisitId = visit.Id
                    };

                    var notification = AutoMapper.Mapper.Map<NotificationViewModel, Notification>(viewModel);

                    if (visit.Notification == null)
                    {
                        db.Notifications.Add(notification);
                    }

                    if (!visit.Notification.IsSeen)
                    {
                        notifications.Add(notification);
                    }
                }
                db.SaveChanges();

                recordedNotifications = notifications
                    .Where(x => x.User.Id == currentUser.Id && !x.IsSeen)
                    .AsQueryable()
                    .ProjectTo<NotificationViewModel>()
                    .ToList();
            }

            var anonymous = recordedNotifications.Select(x => new
            {
                DateTime = x.DateTime,
                IsSeen = x.IsSeen,
                Message = x.Message,
                VetVisitId = x.VetVisitId
            }).ToList();

            var json = JsonConvert.SerializeObject(anonymous);
            Clients.Caller.notify(json);

            return base.OnConnected();
        }

        public void SetNotificationsSeen(ICollection<int> ids)
        {
            using (var db = new PetCareDbContext())
            {
                var notificationsToUpdate = db.Notifications.Where(x => ids.Contains(x.VetVisitId)).ToList();

                foreach (var item in notificationsToUpdate)
                {
                    item.IsSeen = true;
                    db.Notifications.Attach(item);
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        [HubMethodName("sendMessage")]
        public void SendMessage(string message)
        {
            var msg = string.Format("{0}: {1}", Context.ConnectionId, message);
            Clients.All.addMessage(msg);
        }

        public void JoinRoom(string room)
        {
            Groups.Add(Context.ConnectionId, room);
            Clients.Caller.joinRoom(room);
        }
    }
}
