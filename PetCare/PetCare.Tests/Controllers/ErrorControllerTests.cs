namespace PetCare.Tests
{
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    using Data;
    using Data.Repositories;
    using Models;
    using Services;
    using TestStack.FluentMVCTesting;
    using UserVoiceSystem.Web.Controllers;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ActionNotFoundShoudReturnPageNotFoundView()
        {
            var mockHttpContext = new Mock<HttpContextBase>();
            var response = new Mock<HttpResponseBase>();
            mockHttpContext.SetupGet(x => x.Response).Returns(response.Object);

            var db = new PetCareDbContext();
            var repo = new Repository<User>(db);
            var users = new UsersService(repo);
            var controller = new ErrorController(users)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = mockHttpContext.Object
                }
            };

            controller.WithCallTo(x => x.NotFound())
                .ShouldRenderView("NotFound");
        }
    }
}
