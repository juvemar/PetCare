namespace PetCare.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

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

        [HttpGet]
        public ActionResult Index()
        {
            return this.View(new HomePetMixViewModel()
            {
                AddPetViewModel = new AddPetViewModel(),
                ListPetsViewModel = new List<ListPetsViewModel>()
            });
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60 * 30)]
        public ActionResult CachedData()
        {
            var model = new HomePetMixViewModel()
            {
                AddPetViewModel = new AddPetViewModel(),
                ListPetsViewModel = new List<ListPetsViewModel>()
            };

            var allPets = this.pets.GetAll()
                .ProjectTo<ListPetsViewModel>()
                .ToList();
            foreach (var pet in allPets)
            {
                model.ListPetsViewModel.Add(pet);
            }

            return this.PartialView("_HomeCachedDataPartial", model);
        }
    }
}