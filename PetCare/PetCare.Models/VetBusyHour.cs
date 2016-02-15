namespace PetCare.Models
{
    using System;

    public class VetBusyHour
    {
        public int Id { get; set; }

        public DateTime Day { get; set; }

        public string Hour { get; set; }

        public int VetId { get; set; }

        public virtual User Vet { get; set; }
    }
}
