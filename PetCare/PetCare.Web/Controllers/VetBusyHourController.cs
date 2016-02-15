namespace PetCare.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Models.VetVisit;
    using Services.Contracts;
    using Common;
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

        [ActionName("VetAvailableHours")]
        public ActionResult GetVetAvailableHours(string vetId, DateTime date, string description)
        {
            var availableHours = new List<VetFreeHourViewModel>();

            var currentVet = this.users.GetById(vetId.ToString());
            var allHours = this.hours.GetAll(vetId).Where(h => h.Date.Day == date.Day).Select(h => h.Date).ToList();

            var firstWorkingHour = new TimeSpan(9, 0, 0);
            var workingHour = date.Date + firstWorkingHour;
            for (int i = 0; i < GlobalConstants.VetHoursPerDay; i++)
            {
                if (allHours.Contains(workingHour))
                {
                    continue;
                }

                availableHours.Add(new VetFreeHourViewModel()
                {
                    Date = workingHour,
                    VetId = vetId,
                    VetName = currentVet.FirstName + " " + currentVet.LastName,
                    Description = description
                });

                workingHour += new TimeSpan(0, 30, 0);
            }

            return PartialView(availableHours);
        }
    }
}