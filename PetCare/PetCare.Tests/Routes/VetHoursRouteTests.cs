namespace PetCare.Tests.Routes
{
    using System.Web.Routing;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MvcRouteTester;

    using PetCare.Web;
    using PetCare.Web.Controllers;

    [TestClass]
    public class VetHoursRouteTests
    {

        [TestMethod]
        public void TestUserDetails()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/VetBusyHour/MyBusyHours";

            routeCollection
                .ShouldMap(urlForTest)
                .To<VetBusyHourController>(x => x.MyBusyHours());
        }
    }
}
