namespace PetCare.Services.Contracts
{
    using System.Linq;

    using PetCare.Models;

    public interface IHealthRecordsService
    {
        IQueryable<HealthRecord> GetAll();

        IQueryable<HealthRecord> GetById(int id);

        void Add(HealthRecord record);
    }
}
