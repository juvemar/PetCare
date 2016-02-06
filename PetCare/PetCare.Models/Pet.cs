namespace PetCare.Models
{
    using System;

    using Common;

    public class Pet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string BirthPlace { get; set; }

        public Species MyProperty { get; set; }
    }
}
