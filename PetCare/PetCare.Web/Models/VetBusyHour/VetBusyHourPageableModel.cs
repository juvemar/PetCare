namespace PetCare.Web.Models.VetBusyHour
{
    using System.Collections.Generic;

    public class VetBusyHourPageableModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<VetBusyHourViewModel> VetBusyHours { get; set; }
    }
}