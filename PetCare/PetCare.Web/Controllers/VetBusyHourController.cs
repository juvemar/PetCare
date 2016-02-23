namespace PetCare.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Common;
    using Services.Contracts;
    using Models.VetVisit;
    using Models.VetFreeHour;
    public class VetBusyHourController : BaseController
    {
        private IUsersService users;
        private IVetBusyHoursService hours;

        public VetBusyHourController(IUsersService users, IVetBusyHoursService hours)
            : base(users)
        {
            this.users = users;
            this.hours = hours;
        }

        [Authorize]
        [ActionName("_VetAvailableHoursPartial")]
        [HttpGet]
        public ActionResult GetVetAvailableHours(string vetId, DateTime date, string description, string healthRecordId)
        {
            var availableHours = new List<VetFreeHourViewModel>();

            var currentVet = this.users.GetById(vetId.ToString());
            var allHours = this.hours.GetAll(vetId).Where(h => h.Date.Day == date.Day).Select(h => h.Date).ToList();

            var firstWorkingHour = new TimeSpan(9, 0, 0);
            var workingHour = date.Date + firstWorkingHour;
            for (int i = 0; i < GlobalConstants.VetHoursPerDay; i++)
            {
                if (allHours.Contains(workingHour) || workingHour < DateTime.UtcNow + new TimeSpan(2, 0, 0) || i == 0)
                {
                    workingHour += new TimeSpan(0, 30, 0);
                    continue;
                }

                availableHours.Add(new VetFreeHourViewModel()
                {
                    Date = workingHour,
                    VetId = vetId,
                    VetName = currentVet.FirstName + " " + currentVet.LastName,
                    Description = description,
                    HealthRecordId = int.Parse(healthRecordId)
                });

                workingHour += new TimeSpan(0, 30, 0);
            }

            return PartialView(availableHours);
        }
    }
}