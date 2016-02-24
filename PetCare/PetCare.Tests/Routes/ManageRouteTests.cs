namespace PetCare.Tests.Routes
{
    using System.Web.Routing;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MvcRouteTester;

    using PetCare.Web;
    using PetCare.Web.Controllers;

    [TestClass]
    public class ManageRouteTests
    {
        [TestMethod]
        public void TestEditUserProfile()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Manage/EditUserProfile";

            routeCollection
                .ShouldMap(urlForTest)
                .To<ManageController>(x => x.EditUserProfile());
        }
        
        [TestMethod]
        public void TestUserDetails()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Manage/ChangePassword";

            routeCollection
                .ShouldMap(urlForTest)
                .To<ManageController>(x => x.ChangePassword());
        }
    }
}
