namespace PetCare.Web.Controllers
{
    using System.Web.Mvc;

    using PetCare.Services.Contracts;

    public class ImageController : BaseController
    {
        private IImagesService images;

        public ImageController(IImagesService images, IUsersService users)
            :base(users)
        {
            this.images = images;
        }
        
        public ActionResult GetImage(int id)
        {
            var image = this.images.GetById(id);

            if (image == null)
            {
                return this.RedirectToAction("NotFound", "Error");
            }

            return File(image.Content, "image/jpg");
        }
    }
}