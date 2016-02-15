namespace PetCare.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Models.VetVisit;
    using PetCare.Services.Contracts;

    public class VetVisitController : BaseController
    {
        private IUsersService users;

        public VetVisitController(IUsersService users)
            : base(users)
        {
            this.users = users;
        }

        [HttpGet]
        public ActionResult VetVisitDetails()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddVetVisit(int id)
        {
            var model = new AddVetVisitViewModel();
            var vets = this.users.GetAll().Where(x => x.SergeryLocation != null).ToList();

            model.Vets = new List<SelectListItem>();

            foreach (var vet in vets)
            {
                model.Vets.Add(new SelectListItem
                {
                    Text = vet.FirstName + " " + vet.LastName,
                    Value = vet.Id
                });
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult AddVetVisit(AddVetVisitViewModel model)
        {
            

            return View();
        }

        public ActionResult GetVetHours(int vetId, DateTime date)
        {


            return PartialView();
        }
    }
}