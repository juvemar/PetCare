namespace PetCare.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Models.VetVisit;
    using PetCare.Services.Contracts;
    using PetCare.Models;
    public class VetVisitController : BaseController
    {
        private IUsersService users;
        private IVetBusyHoursService hours;
        private IVetVisitsService visits;

        public VetVisitController(IUsersService users, IVetBusyHoursService hours, IVetVisitsService visits)
            : base(users)
        {
            this.users = users;
            this.hours = hours;
            this.visits = visits;
        }

        [Authorize]
        [HttpGet]
        public ActionResult VetVisitDetails()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddVetVisit(int id)
        {
            var model = new AddVetVisitViewModel();
            model.HealthRecordId = id;

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

        [Authorize]
        [HttpPost]
        public ActionResult AddVetVisit(string vetId, DateTime date, string description, int healthRecordId)
        {
            var model = new AddVetVisitViewModel()
            {
                VetId = vetId,
                DateTime = date,
                Description = description,
                HealthRecordId = healthRecordId
            };

            var dataModel = AutoMapper.Mapper.Map<AddVetVisitViewModel, PetCare.Models.VetVisit>(model);

            var currentVet = this.users.GetById(vetId);
            var busyHour = new VetBusyHour()
            {
                Date = date,
                VetId = vetId
            };

            this.hours.Add(busyHour);
            this.visits.Add(dataModel);

            //currentVet.VetBusyHours.Add(busyHour);
            //currentVet.VetVisits.Add(dataModel);

            //this.users.UpdateUser(currentVet, vetId);

            return RedirectToAction("HealthRecordDetails", "HealthRecord", new { id = healthRecordId });
        }
    }
}