namespace PetCare.Models
{
    using System;
    using System.Collections.Generic;

    public class Event
    {
        private ICollection<Pet> pets;

        public Event()
        {
            this.Id = Guid.NewGuid();
            this.pets = new HashSet<Pet>();
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Pet> Pets
        {
            get { return this.pets; }
            set { this.pets = value; }
        }
    }
}
