using PetCare.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetCare.Web.Controllers
{
    public class ImageController : Controller
    {
        private IImagesService images;

        public ImageController(IImagesService images)
            :base()
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