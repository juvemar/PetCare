namespace PetCare.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using TestStack.FluentMVCTesting;

    using PetCare.Models;
    using PetCare.Services.Contracts;
    using PetCare.Web;
    using PetCare.Web.Controllers;

    [TestClass]
    public class PetControllerTests
    {
        private AutoMapperConfig autoMapperConfig;

        public PetControllerTests()
        {
            this.autoMapperConfig = new AutoMapperConfig(typeof(PetController).Assembly);
            this.autoMapperConfig.Execute();
        }

        //[TestMethod]
        //public void ActionAllShoudWorkCorrectly()
        //{
        //    var userServerce = new Mock<IUsersService>();
        //    var petService = new Mock<IPetsService>();

        //    petService.Setup(x => x.GetAll())
        //        .Returns(new List<Pet>().AsQueryable());

        //    var controller = new PetController(userServerce.Object, petService.Object);
        //    controller.WithCallTo(x => x.ListPets())
        //        .ShouldRenderView("ListPets");
        //}
    }
}
