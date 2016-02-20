namespace PetCare.Web.Hubs
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;

    using PetCare.Models;
    using Services.Contracts;

    public class NotifierHub : Hub
    {
        private IUsersService users;
        private IRoomsService rooms;
        
        public override Task OnConnected()
        {
            var currentUser = this.users.GetByUsername(Context.User.Identity.Name).FirstOrDefault();

            var room = this.rooms.GetById(currentUser.Id).FirstOrDefault();

            if (room == null)
            {
                this.rooms.Add(new Room()
                {
                    Name = currentUser.UserName + "Room",
                    UserId = currentUser.Id
                });
            }

            Groups.Add(Context.ConnectionId, room.Name);

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