namespace PetCare.Web.Controllers
{
    using System.Web.Mvc;

    using PetCare.Services.Contracts;

    public class HomeController : Controller
    {
        private IUsersService users;

        public HomeController(IUsersService users)
            : base()
        {
            this.users = users;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public int? GetUserPictureId(string id)
        {
            var userPic = this.users.GetById(id).ProfilePictureId;

            return userPic;
        }
    }
}