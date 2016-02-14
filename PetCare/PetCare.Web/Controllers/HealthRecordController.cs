namespace PetCare.Web.Controllers
{
    using System.Web.Mvc;

    using Models.HealthRecord;
    using PetCare.Services.Contracts;

    public class HealthRecordController : BaseController
    {
        private IHealthRecordsService records;

        public HealthRecordController(IUsersService users, IHealthRecordsService records)
            : base(users)
        {
            this.records = records;
        }

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

            return RedirectToAction("PetDetails", "Pet", new { id = id });
        }
    }
}