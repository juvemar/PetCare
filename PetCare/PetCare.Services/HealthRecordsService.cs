namespace PetCare.Services
{
    using System.Linq;

    using Contracts;
    using Models;
    using PetCare.Data.Repositories;

    public class HealthRecordsService : IHealthRecordsService
    {
        private IRepository<HealthRecord> records;
        private IPetsService pets;

        public HealthRecordsService(IRepository<HealthRecord> records, IPetsService pets)
        {
            this.records = records;
            this.pets = pets;
        }
        public void Add(HealthRecord record)
        {
            this.records.Add(record);
            this.records.SaveChanges();
        }

        public IQueryable<HealthRecord> GetAll()
        {
            return this.records.All();
        }

        public IQueryable<HealthRecord> GetById(int id)
        {
            return this.records.All().Where(x => x.PetId == id).AsQueryable();
        }
    }
}
