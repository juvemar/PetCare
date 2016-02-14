namespace PetCare.Services
{
    using System.Linq;

    using PetCare.Data.Repositories;
    using PetCare.Models;
    using PetCare.Services.Contracts;

    public class VetVisitsService : IVetVisitsService
    {
        private IRepository<VetVisit> vetVisits;

        public VetVisitsService(IRepository<VetVisit> vetVisits)
        {
            this.vetVisits = vetVisits;
        }

        public void Add(VetVisit vetVisit)
        {
            this.vetVisits.Add(vetVisit);
            this.vetVisits.SaveChanges();
        }

        public IQueryable<VetVisit> GetAll()
        {
            return this.vetVisits.All();
        }

        public IQueryable<VetVisit> GetById(int id)
        {
            return this.vetVisits.All().Where(x => x.Id == id).AsQueryable();
        }

        public void UpdatePet(int id)
        {
            var currentPet = this.vetVisits.GetById(id);
            currentPet.HealthRecordId = id;

            this.vetVisits.Update(currentPet);
            this.vetVisits.SaveChanges();
        }
    }
}
