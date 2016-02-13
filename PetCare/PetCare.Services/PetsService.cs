namespace PetCare.Services
{
    using System;
    using System.Linq;

    using Contracts;
    using PetCare.Data.Repositories;
    using PetCare.Models;

    public class PetsService : IPetsService
    {
        private IRepository<Pet> pets;

        public PetsService(IRepository<Pet> pets)
        {
            this.pets = pets;
        }

        public void Add(Pet pet)
        {
            this.pets.Add(pet);
            this.pets.SaveChanges();
        }

        public IQueryable<Pet> GetAll()
        {
            return this.pets.All();
        }

        public IQueryable<Pet> GetById(int id)
        {
            return this.pets.All().Where(x => x.Id == id).AsQueryable();
        }
    }
}
