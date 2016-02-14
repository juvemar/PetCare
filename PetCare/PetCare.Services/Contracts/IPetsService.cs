namespace PetCare.Services.Contracts
{
    using PetCare.Models;
    using System.Linq;

    public interface IPetsService
    {
        IQueryable<Pet> GetAll();

        IQueryable<Pet> GetById(int id);

        void Add(Pet pet);

        void UpdatePet(int id);
    }
}
