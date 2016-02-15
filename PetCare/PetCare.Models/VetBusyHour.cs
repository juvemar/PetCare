namespace PetCare.Models
{
    using System;

    public class VetBusyHour
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string VetId { get; set; }

        public virtual User Vet { get; set; }
    }
}
