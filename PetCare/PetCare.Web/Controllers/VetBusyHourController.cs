namespace PetCare.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Common;
    using Models.VetBusyHour;
    using Models.VetFreeHour;
    using Services.Contracts;

    public class VetBusyHourController : BaseController
    {
        private IUsersService users;
        private IVetBusyHoursService hours;
        private IVetVisitsService visits;

        public VetBusyHourController(IUsersService users, IVetBusyHoursService hours, IVetVisitsService visits)
            : base(users)
        {
            this.users = users;
            this.hours = hours;
            this.visits = visits;
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

        [Authorize]
        [Authorize(Roles = PetCare.Common.GlobalConstants.VetRoleName)]
        public ActionResult MyBusyHours(int id = 1)
        {
            var currentUser = this.users.GetByUsername(this.User.Identity.Name).FirstOrDefault();

            var visits = this.visits.GetAll();
            var totalPages = (int)Math.Ceiling(visits.Count() / ((decimal)GlobalConstants.BusyHoursPerPage));

            if (id - 1 >= totalPages)
            {
                id = totalPages;
            }

            var itemsToSkip = (id - 1) * GlobalConstants.BusyHoursPerPage;
            
            var pagedVisits = visits
                .Where(x => x.VetId == currentUser.Id)
                .OrderBy(x => x.DateTime)
                .Skip(itemsToSkip)
                .Take(GlobalConstants.BusyHoursPerPage)
                .ProjectTo<VetBusyHourViewModel>()
                .ToList();

            var model = new VetBusyHourPageableModel()
            {
                CurrentPage = id,
                TotalPages = totalPages,
                VetBusyHours = pagedVisits
            };

            return this.View(model);
        }
    }
}