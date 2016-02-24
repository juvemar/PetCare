namespace PetCare.Tests.Routes
{
    using System.Web.Routing;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MvcRouteTester;

    using PetCare.Web;
    using PetCare.Web.Controllers;

    [TestClass]
    public class VetVisitRouteTests
    {
        [TestMethod]
        public void TestVetVisitDetailsWithValue()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/VetVisit/VetVisitDetails/1";

            routeCollection
                .ShouldMap(urlForTest)
                .To<VetVisitController>(x => x.VetVisitDetails(1));
        }

        [TestMethod]
        public void TestVetVisitDetailsWithWrongValue()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/VetVisit/VetVisitDetails/-1";

            routeCollection
                .ShouldMap(urlForTest)
                .To<VetVisitController>(x => x.VetVisitDetails(-1));
        }

        [TestMethod]
        public void TestAddVetVisit()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var healthRecordId = 1;
            var urlForTest = "/VetVisit/AddVetVisit/" + healthRecordId;

            routeCollection
                .ShouldMap(urlForTest)
                .To<VetVisitController>(x => x.AddVetVisit(healthRecordId));
        }
    }
}
