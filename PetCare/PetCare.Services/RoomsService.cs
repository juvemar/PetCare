namespace PetCare.Services
{
    using System.Linq;

    using Contracts;
    using PetCare.Data.Repositories;
    using PetCare.Models;

    public class RoomsService : IRoomsService
    {
        private IRepository<Room> rooms;

        public RoomsService(IRepository<Room> rooms)
        {
            this.rooms = rooms;
        }

        public void Add(Room room)
        {
            this.rooms.Add(room);
            this.rooms.SaveChanges();
        }

        public IQueryable<Room> GetAll()
        {
            return this.rooms.All();
        }

        public IQueryable<Room> GetById(string id)
        {
            return this.rooms.All().Where(x => x.UserId == id).AsQueryable();
        }
    }
}
