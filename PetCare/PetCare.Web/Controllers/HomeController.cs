namespace PetCare.Web.Controllers
{
    using System.Web.Mvc;

    using PetCare.Services.Contracts;

    public class HomeController : BaseController
    {
        public HomeController(IUsersService users)
            : base(users)
        {

        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}