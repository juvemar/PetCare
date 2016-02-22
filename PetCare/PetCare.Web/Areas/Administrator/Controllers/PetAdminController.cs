namespace PetCare.Web.Areas.Administrator.Controllers
{
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Models;
    using PetCare.Data.Repositories;
    using PetCare.Models;

    public class PetAdminController : Controller
    {
        private IRepository<Pet> pets;

        public PetAdminController(IRepository<Pet> pets)
        {
            this.pets = pets;
        }

        public ActionResult ManagePets()
        {
            return View();
        }

        public ActionResult Pets_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.pets.All()
                .ProjectTo<CreatePetAdminViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Pets_Create([DataSourceRequest]DataSourceRequest request, Pet pet)
        {
            if (ModelState.IsValid)
            {
                var petModel = new CreatePetAdminViewModel
                {
                    BirthPlace = pet.BirthPlace,
                    Gender = pet.Gender
                };

                var entity = new Pet
                {
                    Name = pet.Name,
                    Gender = pet.Gender,
                    DateOfBirth = pet.DateOfBirth,
                    BirthPlace = pet.BirthPlace,
                    Species = pet.Species,
                    HealthRecordId = pet.HealthRecordId
                };

                this.pets.Add(entity);
                pet.Id = entity.Id;
            }

            return Json(new[] { pet }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Pets_Update([DataSourceRequest]DataSourceRequest request, Pet pet)
        {
            if (ModelState.IsValid)
            {
                var entity = new Pet
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    Gender = pet.Gender,
                    DateOfBirth = pet.DateOfBirth,
                    BirthPlace = pet.BirthPlace,
                    Species = pet.Species,
                    HealthRecordId = pet.HealthRecordId
                };

                this.pets.Update(entity);
            }

            return Json(new[] { pet }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Pets_Destroy([DataSourceRequest]DataSourceRequest request, Pet pet)
        {
            var entity = new Pet
            {
                Id = pet.Id,
                Name = pet.Name,
                Gender = pet.Gender,
                DateOfBirth = pet.DateOfBirth,
                BirthPlace = pet.BirthPlace,
                Species = pet.Species,
                HealthRecordId = pet.HealthRecordId
            };

            this.pets.Delete(entity);

            return Json(new[] { pet }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.pets.Dispose();
            base.Dispose(disposing);
        }
    }
}
