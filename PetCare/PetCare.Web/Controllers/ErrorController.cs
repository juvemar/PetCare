namespace UserVoiceSystem.Web.Controllers
{
    using System.Web.Mvc;

    using PetCare.Services.Contracts;
    using PetCare.Web.Controllers;

    public class ErrorController : BaseController
    {
        private IUsersService users;

        public ErrorController(IUsersService users)
            :base(users)
        {
            this.users = users;
        }

        public ViewResult NotFound()
        {
            this.Response.StatusCode = 404;
            return this.View();
        }
        
        public ViewResult ServerError()
        {
            this.Response.StatusCode = 500;
            return this.View();
        }

        public ViewResult PageForbidden()
        {
            this.Response.StatusCode = 403;
            return this.View();
        }
    }
}