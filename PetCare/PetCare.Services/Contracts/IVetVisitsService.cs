namespace PetCare.Services.Contracts
{
    using System.Linq;

    using Models;

    public interface IVetVisitsService
    {
        IQueryable<VetVisit> GetAll();

        IQueryable<VetVisit> GetById(int id);

        void Add(VetVisit vetVisit);

        void UpdatePet(int id);
    }
}
