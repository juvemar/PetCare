namespace PetCare.Models
{
    using System.Collections.Generic;

    public class Species
    {
        private ICollection<Pet> pets;

        public Species()
        {
            this.pets = new HashSet<Pet>();
        }

        public int Id { get; set; }

        public string Value { get; set; }

        public virtual ICollection<Pet> Pets
        {
            get { return this.pets; }
            set { this.pets = value; }
        }
    }
}
