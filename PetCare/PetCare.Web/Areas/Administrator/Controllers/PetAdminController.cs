namespace PetCare.Web.Areas.Administrator.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Models.Pet;
    using PetCare.Data.Repositories;
    using PetCare.Models;
    using Services.Contracts;
    using Web.Controllers;

    [Authorize(Roles = PetCare.Common.GlobalConstants.AdministratorRoleName)]
    public class PetAdminController : BaseController
    {
        private IRepository<Pet> pets;

        public PetAdminController(IUsersService users, IRepository<Pet> pets)
            : base(users)
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
                .ProjectTo<PetAdminViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Pets_Update([DataSourceRequest]DataSourceRequest request, PetAdminInputViewModel pet)
        {
            if (ModelState.IsValid)
            {
                var entity = this.pets.GetById(pet.Id);
                entity.Name = pet.Name;
                entity.BirthPlace = pet.BirthPlace;
                entity.Gender = pet.Gender;
                entity.Species = pet.Species;

                this.pets.Update(entity);
                this.pets.SaveChanges();
            }

            var petToDisplay = this.pets.All()
                .ProjectTo<PetAdminViewModel>()
                .FirstOrDefault(x => x.Id == pet.Id);

            return Json(new[] { petToDisplay }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Pets_Destroy([DataSourceRequest]DataSourceRequest request, PetAdminInputViewModel pet)
        {
            var entity = this.pets.GetById(pet.Id);
            this.pets.MarkAsDeleted(entity);
            this.pets.SaveChanges();

            return Json(new[] { pet }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.pets.Dispose();
            base.Dispose(disposing);
        }
    }
}
