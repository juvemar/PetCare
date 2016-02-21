namespace PetCare.Web.Hubs
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Script.Serialization;

    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;

    using Common;
    using Data;
    using PetCare.Models;
    using Newtonsoft.Json;
    using Models.Notification;
    using Models.HealthRecord;
    using AutoMapper.QueryableExtensions;
    using System.Data.Entity;
    public class NotifierHub : Hub
    {
        //[Authorize]
        //public void OnConnectedCall()
        //{
        //    User currentUser;

        //    using (var db = new PetCareDbContext())
        //    {
        //        currentUser = db.Users.FirstOrDefault(x => x.UserName == Context.User.Identity.Name);
        //        if (currentUser.IsVet)
        //        {
        //            return;
        //        }

        //        var room = db.Rooms.Where(x => x.UserId == currentUser.Id).FirstOrDefault();

        //        if (room == null)
        //        {
        //            db.Rooms.Add(room = new Room()
        //            {
        //                Name = currentUser.UserName + "Room",
        //                UserId = currentUser.Id
        //            });

        //            db.SaveChanges();
        //        }

        //        Groups.Add(Context.ConnectionId, room.Name);
        //    }

        //    var notifications = this.CheckForVetVisits(currentUser);

        //    var anonymous = notifications.Select(x => new { DateTime = x.DateTime, IsSeen = x.IsSeen, Message = x.Message }).ToList();

        //    //if (DateTime.UtcNow.Minute % 2 == 0)
        //    {
        //        var jsonSerialiser = new JavaScriptSerializer();
        //        var json = jsonSerialiser.Serialize(anonymous);
        //        Clients.Caller.notify(json);
        //    }
        //}

        private ICollection<Notification> CheckForVetVisits(User currentUser)
        {
            using (var db = new PetCareDbContext())
            {
                var visits = currentUser.Pets
                    .Select(x => x.HealthRecord)
                    .FirstOrDefault()
                    .VetVisits
                    //.Where(x => x.DateTime > DateTime.UtcNow.AddDays(2) && x.DateTime < DateTime.UtcNow.AddDays(-3))
                    .ToList();

                var notifications = new List<Notification>();

                foreach (var visit in visits)
                {
                    var notification = new Notification()
                    {
                        DateTime = DateTime.UtcNow,
                        Message = string.Format(GlobalConstants.VetVisitNotificationInThreeDays, visit.Pet.Pet.Name, visit.Vet.FirstName, visit.Vet.LastName),
                        User = currentUser
                    };

                    notifications.Add(notification);
                    db.Notifications.Add(notification);
                }
                db.SaveChanges();

                return notifications;
            }
        }

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
                    .Select(x => x.HealthRecord)
                    .FirstOrDefault()
                    .VetVisits
                    .Where(x => x.DateTime.Day > DateTime.UtcNow.Day && x.DateTime.Day <= DateTime.UtcNow.AddDays(2).Day)
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

                    db.Notifications.Add(notification);
                    notifications.Add(notification);
                }
                db.SaveChanges();
                
                recordedNotifications = notifications
                    .Where(x => x.User.Id == currentUser.Id && !x.IsSeen)
                    .AsQueryable()
                    .ProjectTo<NotificationViewModel>().ToList();
            }

            var anonymous = recordedNotifications.Select(x => new
            {
                DateTime = x.DateTime,
                IsSeen = x.IsSeen,
                Message = x.Message,
                Id = x.Id,
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
                var notificationsToUpdate = db.Notifications.Where(x => ids.Contains(x.Id)).ToList();

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
