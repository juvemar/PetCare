namespace PetCare.Web.Controllers
{
    using System.Web.Mvc;

    using Models.HealthRecord;
    using PetCare.Services.Contracts;

    public class HealthRecordController : BaseController
    {
        public HealthRecordController(IUsersService users)
            :base(users)
        {

        }

        // GET: HealthRecord
        public ActionResult CreateHealthRecord()
        {
            return View();
        }

        // GET: 
        [HttpPost]
        public ActionResult CreateHealthRecord(CreateHealthRecordViewModel model)
        {
            return View(model);
        }
    }
}