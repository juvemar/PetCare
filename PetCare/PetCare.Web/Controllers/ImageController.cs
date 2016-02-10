namespace PetCare.Web.Controllers
{
    using PetCare.Services.Contracts;
    using System.Web.Mvc;

    public class ImageController : BaseController
    {
        private IImagesService images;

        public ImageController(IImagesService images, IUsersService users)
            :base(users)
        {
            this.images = images;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetImage(int id)
        {
            var imageData = this.images.GetById(id).Content;
            return File(imageData, "image/jpg");
        }
    }
}