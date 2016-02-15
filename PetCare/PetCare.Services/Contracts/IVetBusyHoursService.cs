namespace PetCare.Services.Contracts
{
    using System.Linq;

    using PetCare.Models;

    public interface IVetBusyHoursService
    {
        IQueryable<VetBusyHour> GetAll(string Id);

        IQueryable<VetBusyHour> GetById(int id);

        void Add(VetBusyHour hour);
    }
}
