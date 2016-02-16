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

        public void UpdateRecord(HealthRecord record, int id)
        {
            var currentRecord = this.GetById(id).FirstOrDefault();

            currentRecord.Coat = record.Coat == null ? currentRecord.Coat : record.Coat;
            currentRecord.FurColor = record.FurColor == null ? currentRecord.FurColor : record.FurColor;
            currentRecord.Height = record.Height == 0 ? currentRecord.Height : record.Height;
            currentRecord.Weight = record.Weight == 0 ? currentRecord.Weight : record.Weight;

            this.records.Update(currentRecord);
            this.records.SaveChanges();
        }
    }
}
