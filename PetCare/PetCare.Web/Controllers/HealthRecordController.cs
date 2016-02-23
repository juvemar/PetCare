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
        [Authorize]
        public ActionResult CreateHealthRecord()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
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
        [Authorize]
        public ActionResult HealthRecordDetails(int id)
        {
            var record = this.records.GetById(id);
            if (record == null)
            {
                return this.RedirectToAction("NotFound", "Error");
            }
            var model = record.ProjectTo<HealthRecordDetails>()
                .FirstOrDefault();

            var getAllVisits = this.vetVisits.GetAll().Where(v => v.PetId == id);
            model.PassedVetVisits = getAllVisits.Where(v => v.DateTime < DateTime.UtcNow).ToList();
            model.UpcomingVetVisits = getAllVisits.Where(v => v.DateTime > DateTime.UtcNow).OrderBy(v => v.DateTime).ToList();

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult EditHealthRecord(int id)
        {
            var record = this.records.GetById(id).FirstOrDefault();
            if (record == null)
            {
                return this.RedirectToAction("NotFound", "Error");
            }

            var model = new CreateHealthRecordViewModel();
            model.PetId = id;

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditHealthRecord(CreateHealthRecordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dataModel = AutoMapper.Mapper.Map<CreateHealthRecordViewModel, PetCare.Models.HealthRecord>(model);

            this.records.UpdateRecord(dataModel, model.PetId);

            return RedirectToAction("HealthRecordDetails", new { id = model.PetId });
        }
    }
}