namespace PetCare.Web.Controllers
{
    using System.Web.Mvc;

    using Models.Pet;
    using Services.Contracts;
    using Common;
    public class PetController : BaseController
    {
        public PetController(IUsersService users)
            : base(users)
        {

        }

        // GET: Pet/AddPet
        [HttpGet]
        public ActionResult AddPet()
        {
            return View();
        }

        // POST: Pet/AddPet
        [HttpPost]
        public ActionResult AddPet(AddPetViewModel model)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}