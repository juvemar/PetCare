namespace PetCare.Services.Contracts
{
    using System.Linq;

    using PetCare.Models;

    public interface IRoomsService
    {
        IQueryable<Room> GetAll();

        IQueryable<Room> GetById(string id);

        void Add(Room record);
    }
}
