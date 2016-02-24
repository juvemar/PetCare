namespace PetCare.Tests.Routes
{
    using System.Web.Routing;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MvcRouteTester;

    using PetCare.Web;
    using PetCare.Web.Controllers;

    [TestClass]
    public class PetRoutesTests
    {
        [TestMethod]
        public void TestPetDetailsWithValue()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Pet/PetDetails/1";

            routeCollection
                .ShouldMap(urlForTest)
                .To<PetController>(x => x.PetDetails(1));
        }

        [TestMethod]
        public void TestPetDetailsWithWrongValue()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Pet/PetDetails/-1";

            routeCollection
                .ShouldMap(urlForTest)
                .To<PetController>(x => x.PetDetails(-1));
        }

        [TestMethod]
        public void TestListPets()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Pet/ListPets";

            routeCollection
                .ShouldMap(urlForTest)
                .To<PetController>(x => x.ListPets());
        }

        [TestMethod]
        public void TestAddPet()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Pet/AddPet";

            routeCollection
                .ShouldMap(urlForTest)
                .To<PetController>(x => x.AddPet());
        }
    }
}
