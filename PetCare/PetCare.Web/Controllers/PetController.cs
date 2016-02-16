namespace PetCare.Web.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

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

        // GET: Pet/AddPet
        [Authorize]
        [HttpGet]
        public ActionResult AddPet()
        {
            return View();
        }

        // POST: Pet/AddPet
        [Authorize]
        [HttpPost]
        public ActionResult AddPet(AddPetViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var dataModel = AutoMapper.Mapper.Map<AddPetViewModel, PetCare.Models.Pet>(model);

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
            var pet = this.pets
                .GetById(id)
                .ProjectTo<PetDetailsViewModel>()
                .FirstOrDefault();

            return this.View(pet);
        }

        [HttpGet]
        [Authorize]
        public ActionResult ListMyPets()
        {
            var currentUser = this.users.GetByUsername(User.Identity.Name).FirstOrDefault();

            var myPets = this.pets.GetAll()
                .Where(p => p.OwnerId == currentUser.Id)
                .OrderBy(p => p.Name)
                .ToList();
            var myPetsModel = new List<ListPetsViewModel>();

            foreach (var pet in myPets)
            {
                var newPet = new ListPetsViewModel()
                {
                    Name = pet.Name,
                    Id = pet.Id,
                    ImageId = pet.ImageId
                };

                myPetsModel.Add(newPet);
            }

            return this.View(myPetsModel);
        }
    }
}