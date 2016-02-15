namespace PetCare.Services
{
    using System.Linq;

    using Data.Repositories;
    using Models;
    using PetCare.Services.Contracts;

    public class VetBusyHoursService : IVetBusyHoursService
    {
        private IRepository<VetBusyHour> hours;

        public VetBusyHoursService(IRepository<VetBusyHour> hours)
        {
            this.hours = hours;
        }

        public void Add(VetBusyHour hour)
        {
            this.hours.Add(hour);
            this.hours.SaveChanges();
        }

        public IQueryable<VetBusyHour> GetAll(string Id)
        {
            return this.hours.All().Where(h => h.VetId.ToString() == Id).AsQueryable();
        }

        public IQueryable<VetBusyHour> GetById(int id)
        {
            return this.hours.All().AsQueryable();
        }
    }
}
