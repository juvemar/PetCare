namespace PetCare.Web.Hubs
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;

    using Data;
    using PetCare.Models;
    using System;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Data;
    using System.Collections.Generic;
    using Common;
    using System.Web.Script.Serialization;
    public class NotifierHub : Hub
    {
        [Authorize]
        public void OnConnectedCall()
        {
            using (var db = new PetCareDbContext())
            {
                var currentUser = db.Users.FirstOrDefault(x => x.UserName == Context.User.Identity.Name);

                var room = db.Rooms.Where(x => x.UserId == currentUser.Id).FirstOrDefault();

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
            }

            var notifications = this.CheckForVetVisits();

            var anonymous = notifications.Select(x => new { DateTime = x.DateTime, IsSeen = x.IsSeen, Message = x.Message }).ToList();

            //if (DateTime.UtcNow.Minute % 2 == 0)
            {
                var jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(anonymous);
                Clients.Caller.notify(json);
            }
        }

        private ICollection<Notification> CheckForVetVisits()
        {
            using (var db = new PetCareDbContext())
            {
                var currentUser = db.Users.FirstOrDefault(x => x.UserName == Context.User.Identity.Name);

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

            //using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PetCareConnectionString"].ConnectionString))
            //{
            //    connection.Open();
            //    using (SqlCommand command = new SqlCommand(@"SELECT [UserId],[Name] FROM [dbo].[Rooms]", connection))
            //    {
            //        // Make sure the command object does not already have
            //        // a notification object associated with it.
            //        command.Notification = null;

            //        SqlDependency dependency = new SqlDependency(command);
            //        dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

            //        if (connection.State == ConnectionState.Closed)
            //            connection.Open();

            //        using (var reader = command.ExecuteReader())
            //            return reader.Cast<IDataRecord>()
            //                .Select(x => new Room()
            //                {
            //                    UserId = x.GetString(0),
            //                    Name = x.GetString(1)
            //                }).FirstOrDefault();
            //    }
            //}
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            this.SendMessage("ASD");
        }

        public override Task OnConnected()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                using (var db = new PetCareDbContext())
                {
                    var currentUser = db.Users.FirstOrDefault(x => x.UserName == Context.User.Identity.Name);

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
                }
            }

            return base.OnConnected();
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
