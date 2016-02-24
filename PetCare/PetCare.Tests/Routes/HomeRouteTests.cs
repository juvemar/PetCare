namespace PetCare.Tests.Routes
{
    using System.Web.Routing;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MvcRouteTester;

    using PetCare.Web;
    using PetCare.Web.Controllers;

    [TestClass]
    public class HomeRouteTests
    {
        [TestMethod]
        public void TestHome()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Home/Index";

            routeCollection
                .ShouldMap(urlForTest)
                .To<HomeController>(x => x.Index());
        }
    }
}
