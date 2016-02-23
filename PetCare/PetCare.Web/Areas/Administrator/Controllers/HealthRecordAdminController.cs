namespace PetCare.Web.Areas.Administrator.Controllers
{
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Infrastructure.Mapping;
    using Kendo.Mvc.UI;

    using PetCare.Data.Repositories;
    using PetCare.Models;
    using PetCare.Services.Contracts;
    using PetCare.Web.Areas.Administrator.Models.HealthRecord;
    using PetCare.Web.Controllers;

    [Authorize(Roles = PetCare.Common.GlobalConstants.AdministratorRoleName)]
    public class HealthRecordAdminController : BaseController
    {
        private IRepository<HealthRecord> records;

        public HealthRecordAdminController(IUsersService users, IRepository<HealthRecord> records)
            : base(users)
        {
            this.records = records;
        }

        public ActionResult ManageHealthRecords()
        {
            return View();
        }

        public ActionResult HealthRecords_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.records.All()
                .To<HealthRecordAdminViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult HealthRecords_Update([DataSourceRequest]DataSourceRequest request, HealthRecordAdminInputViewModel healthRecord)
        {
            if (ModelState.IsValid)
            {
                var entity = this.records.GetById(healthRecord.PetId);
                entity.Coat = healthRecord.Coat;
                entity.FurColor = healthRecord.FurColor;
                entity.Height = healthRecord.Height;
                entity.Weight = healthRecord.Weight;

                this.records.Update(entity);
                this.records.SaveChanges();
            }

            return Json(new[] { healthRecord }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult HealthRecords_Destroy([DataSourceRequest]DataSourceRequest request, HealthRecordAdminViewModel healthRecord)
        {
            var entity = this.records.GetById(healthRecord.PetId);
            this.records.MarkAsDeleted(entity);
            this.records.SaveChanges();

            return Json(new[] { healthRecord }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.records.Dispose();
            base.Dispose(disposing);
        }
    }
}
