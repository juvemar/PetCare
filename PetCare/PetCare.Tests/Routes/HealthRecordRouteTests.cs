namespace PetCare.Tests.Routes
{
    using System.Web.Routing;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MvcRouteTester;
    using Web;

    using Web.Controllers;

    [TestClass]
    public class HealthRecordRouteTests
    {
        [TestMethod]
        public void TestHealthRecordDetailsWithValue()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/HealthRecord/HealthRecordDetails/1";

            routeCollection
                .ShouldMap(urlForTest)
                .To<HealthRecordController>(x => x.HealthRecordDetails(1));
        }

        [TestMethod]
        public void TestHealthRecordDetailsWithWrongValue()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/HealthRecord/HealthRecordDetails/-1";

            routeCollection
                .ShouldMap(urlForTest)
                .To<HealthRecordController>(x => x.HealthRecordDetails(-1));
        }

        [TestMethod]
        public void TestGetAddHealthRecord()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/HealthRecord/CreateHealthRecord";

            routeCollection
                .ShouldMap(urlForTest)
                .To<HealthRecordController>(x => x.CreateHealthRecord());
        }

        [TestMethod]
        public void TestEditHealthRecord()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/HealthRecord/EditHealthRecord/1";

            routeCollection
                .ShouldMap(urlForTest)
                .To<HealthRecordController>(x => x.EditHealthRecord(1));
        }
    }
}
