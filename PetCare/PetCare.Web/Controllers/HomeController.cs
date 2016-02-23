namespace PetCare.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    
    using Models.Home;
    using Models.Pet;
    using PetCare.Services.Contracts;

    public class HomeController : BaseController
    {
        private IPetsService pets;

        public HomeController(IUsersService users, IPetsService pets)
            : base(users)
        {
            this.pets = pets;
        }

        public ActionResult Index()
        {
            var model = new HomePetMixViewModel()
            {
                AddPetViewModel = new AddPetViewModel(),
                ListPetsViewModel = new List<ListPetsViewModel>()
            };

            var allPets = this.pets.GetAll()
                .To<ListPetsViewModel>()
                .ToList();
            foreach (var pet in allPets)
            {
                model.ListPetsViewModel.Add(pet);
            }

            return this.View(model);
        }
    }
}