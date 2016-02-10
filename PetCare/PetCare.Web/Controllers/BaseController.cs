namespace PetCare.Web.Controllers
{
    using System.Web.Mvc;

    using PetCare.Services.Contracts;

    public class BaseController : Controller
    {
        private IUsersService users;

        public BaseController(IUsersService users)
            : base()
        {
            this.users = users;
        }

        public int? GetUserPictureId(string id)
        {
            var userPic = this.users.GetById(id).ProfilePictureId;

            return userPic;
        }
    }
}