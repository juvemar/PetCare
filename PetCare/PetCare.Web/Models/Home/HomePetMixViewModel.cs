namespace PetCare.Web.Models.Home
{
    using System.Collections.Generic;

    using PetCare.Web.Models.Pet;

    public class HomePetMixViewModel
    {
        public AddPetViewModel AddPetViewModel { get; set; }

        public List<ListPetsViewModel> ListPetsViewModel { get; set; }
    }
}