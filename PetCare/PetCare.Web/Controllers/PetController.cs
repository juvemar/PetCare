namespace PetCare.Web.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;

    using Models.Pet;
    using PetCare.Models;
    using Services.Contracts;

    public class PetController : BaseController
    {
        private IUsersService users;
        private IPetsService pets;

        public PetController(IUsersService users, IPetsService pets)
            : base(users)
        {
            this.users = users;
            this.pets = pets;
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddPet()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddPet(AddPetViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var mapper = AutoMapperConfig.Configuration.CreateMapper();
            var dataModel = mapper.Map<PetCare.Models.Pet>(model);

            Image image = null;
            if (model.ProfilePicture != null)
            {
                using (var memory = new MemoryStream())
                {
                    model.ProfilePicture.InputStream.CopyTo(memory);
                    var content = memory.GetBuffer();

                    image = new Image
                    {
                        Content = content,
                        Extension = model.ProfilePicture.FileName.Split(new[] { '.' }).Last()
                    };
                }
            }

            dataModel.Image = image;
            var currentUser = this.users.GetByUsername(this.User.Identity.Name).FirstOrDefault();
            dataModel.Owner = currentUser;
            dataModel.HealthRecordId = 0;

            this.pets.Add(dataModel);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult PetDetails(int id)
        {
            var pet = this.pets.GetById(id);
            if (pet == null)
            {
                return this.RedirectToAction("NotFound", "Error");
            }

            var model = pet.To<PetDetailsViewModel>()
                .FirstOrDefault();

            return this.View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult ListPets()
        {
            var currentUser = this.users.GetByUsername(this.User.Identity.Name).FirstOrDefault();

            var pets = this.pets.GetAll()
                .Where(x => x.OwnerId == currentUser.Id)
                .OrderBy(p => p.Name)
                .ToList();

            var petsModel = new List<ListPetsViewModel>();
            if (pets.Count() == 0)
            {
                return this.View(petsModel);
            }

            foreach (var pet in pets)
            {
                var newPet = new ListPetsViewModel()
                {
                    Name = pet.Name,
                    Id = pet.Id,
                    ImageId = pet.ImageId
                };

                petsModel.Add(newPet);
            }

            return this.View(petsModel);
        }
    }
}