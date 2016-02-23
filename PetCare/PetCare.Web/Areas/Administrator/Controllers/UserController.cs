namespace PetCare.Web.Areas.Administrator.Controllers
{
    using System;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Data.Repositories;
    using Models.User;
    using PetCare.Models;
    using Services.Contracts;
    using Web.Controllers;

    [Authorize(Roles = PetCare.Common.GlobalConstants.AdministratorRoleName)]
    public class UserController : BaseController
    {
        private IRepository<User> repoUsers;

        public UserController(IUsersService users, IRepository<User> repoUsers)
            : base(users)
        {
            this.repoUsers = repoUsers;
        }
        public ActionResult ManageUsers()
        {
            return View();
        }

        public ActionResult Users_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.repoUsers.All()
                .To<UserInputViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Update([DataSourceRequest]DataSourceRequest request, UserInputViewModel user)
        {
            if (ModelState.IsValid)
            {
                var entity = this.repoUsers.GetById(user.Id);
                entity.FirstName = user.FirstName;
                entity.LastName = user.LastName;
                entity.IsVet = user.IsVet;
                entity.SergeryLocation = user.SergeryLocation;

                this.repoUsers.Update(entity);
                this.repoUsers.SaveChanges();
            }

            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Destroy([DataSourceRequest]DataSourceRequest request, UserViewModel user)
        {
            var entity = this.repoUsers.GetById(user.Id);
            this.repoUsers.MarkAsDeleted(entity);
            this.repoUsers.SaveChanges();

            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            this.repoUsers.Dispose();
            base.Dispose(disposing);
        }
    }
}
