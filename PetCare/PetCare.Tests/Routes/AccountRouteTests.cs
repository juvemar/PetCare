namespace PetCare.Tests.Routes
{
    using System.Web.Routing;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MvcRouteTester;

    using PetCare.Web;
    using PetCare.Web.Controllers;

    [TestClass]
    public class AccountRouteTests
    {
        [TestMethod]
        public void TestUserDetails()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Account/UserDetails";

            routeCollection
                .ShouldMap(urlForTest)
                .To<AccountController>(x => x.UserDetails());
        }
        
        [TestMethod]
        public void TestRegister()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Account/Register";

            routeCollection
                .ShouldMap(urlForTest)
                .To<AccountController>(x => x.Register());
        }

        //[TestMethod]
        //public void TestLogin()
        //{
        //    var routeCollection = new RouteCollection();
        //    RouteConfig.RegisterRoutes(routeCollection);
        //    var urlForTest = "/Account/Login";

        //    var url = "/Account/Login";
        //    routeCollection
        //        .ShouldMap(urlForTest)
        //        .To<AccountController>(x => x.Login(url));
        //}
    }
}
