namespace PetCare.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Models.HealthRecord;
    using PetCare.Services.Contracts;

    public class HealthRecordController : BaseController
    {
        private IHealthRecordsService records;
        private IPetsService pets;
        private IVetVisitsService vetVisits;

        public HealthRecordController(IUsersService users, IHealthRecordsService records, IPetsService pets, IVetVisitsService vetVisits)
            : base(users)
        {
            this.records = records;
            this.pets = pets;
            this.vetVisits = vetVisits;
        }

        [HttpGet]
        public ActionResult CreateHealthRecord()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateHealthRecord(int id, CreateHealthRecordViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var dataModel = AutoMapper.Mapper.Map<CreateHealthRecordViewModel, PetCare.Models.HealthRecord>(model);

            dataModel.PetId = id;

            this.records.Add(dataModel);
            this.pets.UpdatePet(id);

            return RedirectToAction("PetDetails", "Pet", new { id = id });
        }

        [HttpGet]
        public ActionResult HealthRecordDetails(int id)
        {
            var record = this.records.GetById(id)
                .ProjectTo<HealthRecordDetails>()
                .FirstOrDefault();

            record.PetName = this.pets.GetById(id).FirstOrDefault().Name;
            record.PassedVetVisits = this.vetVisits.GetAll().Where(v => v.DateTime < DateTime.Now);

            return View(record);
        }
    }
}